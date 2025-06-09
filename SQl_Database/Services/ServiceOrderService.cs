using System;
using System.Data;
using System.Data.SqlClient;
using SQl_Database.Models;
using System.Collections.Generic;

namespace SQl_Database.Services
{
    public class ServiceOrderService
    {
        private readonly Database _db;

        public ServiceOrderService()
        {
            _db = new Database();
        }

        /// <summary>
        /// Get all available services
        /// </summary>
        /// <returns>List of services</returns>
        public List<Service> GetAllServices()
        {
            string query = "SELECT MaDichVu, TenDichVu, Gia, Anh, TonKho, MaLoai FROM DichVu WHERE TonKho > 0";

            DataTable result = _db.GetData(query);
            List<Service> services = new List<Service>();

            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    Service service = new Service
                    {
                        MaDichVu = Convert.ToInt32(row["MaDichVu"]),
                        TenDichVu = row["TenDichVu"].ToString(),
                        Gia = Convert.ToDecimal(row["Gia"]),
                        Anh = row["Anh"].ToString(),
                        TonKho = Convert.ToInt32(row["TonKho"]),
                        MaLoai = Convert.ToInt32(row["MaLoai"])
                    };

                    services.Add(service);
                }
            }

            return services;
        }

        /// <summary>
        /// Create a new service order
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <param name="orderDetails">List of order details</param>
        /// <returns>Order ID if successful, -1 otherwise</returns>
        public int CreateServiceOrder(int customerId, List<ServiceOrderDetail> orderDetails)
        {
            if (orderDetails == null || orderDetails.Count == 0)
                return -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(_db.GetConnection().ConnectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Step 1: Create the order
                        string orderQuery = @"INSERT INTO HoaDon (NgayLap, MaKH, MaNhanVien)
                                            VALUES (@NgayLap, @MaKH, NULL);
                                            SELECT SCOPE_IDENTITY();";

                        SqlCommand orderCmd = new SqlCommand(orderQuery, conn, transaction);
                        orderCmd.Parameters.AddWithValue("@NgayLap", DateTime.Now);
                        orderCmd.Parameters.AddWithValue("@MaKH", customerId);

                        // Get the new order ID
                        decimal orderId = (decimal)orderCmd.ExecuteScalar();
                        int newOrderId = (int)orderId;

                        // Step 2: Create order details
                        foreach (var detail in orderDetails)
                        {
                            string detailQuery = @"INSERT INTO ChiTietDichVu (MaHD, MaDichVu, SoLuong, DonGia, ThanhTien)
                                                VALUES (@MaHD, @MaDichVu, @SoLuong, @DonGia, @ThanhTien);";

                            SqlCommand detailCmd = new SqlCommand(detailQuery, conn, transaction);
                            detailCmd.Parameters.AddWithValue("@MaHD", newOrderId);
                            detailCmd.Parameters.AddWithValue("@MaDichVu", detail.MaDichVu);
                            detailCmd.Parameters.AddWithValue("@SoLuong", detail.SoLuong);
                            detailCmd.Parameters.AddWithValue("@DonGia", detail.DonGia);
                            detailCmd.Parameters.AddWithValue("@ThanhTien", detail.ThanhTien);

                            detailCmd.ExecuteNonQuery();

                            // Update inventory
                            string updateInventoryQuery = "UPDATE DichVu SET TonKho = TonKho - @SoLuong WHERE MaDichVu = @MaDichVu";
                            SqlCommand updateCmd = new SqlCommand(updateInventoryQuery, conn, transaction);
                            updateCmd.Parameters.AddWithValue("@SoLuong", detail.SoLuong);
                            updateCmd.Parameters.AddWithValue("@MaDichVu", detail.MaDichVu);
                            updateCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return newOrderId;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        System.Windows.Forms.MessageBox.Show("Lỗi khi tạo đơn hàng: " + ex.Message);
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Get customer's total service cost for the current session
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <returns>Total service cost</returns>
        public decimal GetCustomerServiceCost(int customerId)
        {
            string query = @"SELECT SUM(ctdv.ThanhTien) AS TotalCost
                            FROM HoaDon hd
                            INNER JOIN ChiTietDichVu ctdv ON hd.MaHD = ctdv.MaHD
                            WHERE hd.MaKH = @MaKH
                            AND hd.MaHD = (
                                SELECT TOP 1 h.MaHD
                                FROM HoaDon h
                                WHERE h.MaKH = @MaKH
                                AND NOT EXISTS (
                                    SELECT 1 FROM ThanhToan t
                                    WHERE t.MaHD = h.MaHD
                                )
                                ORDER BY h.NgayLap DESC
                            )";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaKH", customerId)
            };

            DataTable result = _db.GetData(query, parameters);

            if (result != null && result.Rows.Count > 0 && result.Rows[0]["TotalCost"] != DBNull.Value)
            {
                return Convert.ToDecimal(result.Rows[0]["TotalCost"]);
            }

            return 0;
        }

        /// <summary>
        /// Get all orders for a specific customer for the current day
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <returns>List of service orders</returns>
        public List<ServiceOrder> GetCustomerOrders(int customerId)
        {
            string query = @"SELECT hd.MaHD, hd.NgayLap, hd.MaKH, hd.MaNhanVien,
                            SUM(ctdv.ThanhTien) AS TongTien,
                            CASE WHEN EXISTS (SELECT 1 FROM ThanhToan tt WHERE tt.MaHD = hd.MaHD)
                                THEN N'Đã thanh toán'
                                ELSE N'Chờ thanh toán'
                            END AS TrangThai
                            FROM HoaDon hd
                            LEFT JOIN ChiTietDichVu ctdv ON hd.MaHD = ctdv.MaHD
                            WHERE hd.MaKH = @MaKH
                            AND CONVERT(date, hd.NgayLap) = CONVERT(date, GETDATE())
                            GROUP BY hd.MaHD, hd.NgayLap, hd.MaKH, hd.MaNhanVien
                            ORDER BY hd.NgayLap DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaKH", customerId)
            };

            DataTable result = _db.GetData(query, parameters);
            List<ServiceOrder> orders = new List<ServiceOrder>();

            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    ServiceOrder order = new ServiceOrder
                    {
                        MaHD = Convert.ToInt32(row["MaHD"]),
                        NgayLap = Convert.ToDateTime(row["NgayLap"]),
                        MaKH = Convert.ToInt32(row["MaKH"]),
                        MaNhanVien = row["MaNhanVien"] != DBNull.Value ? Convert.ToInt32(row["MaNhanVien"]) : 0,
                        TongTien = Convert.ToDecimal(row["TongTien"]),
                        TrangThai = row["TrangThai"].ToString()
                    };

                    orders.Add(order);
                }
            }

            return orders;
        }

        /// <summary>
        /// Get details for a specific order
        /// </summary>
        /// <param name="orderId">Order ID</param>
        /// <returns>List of order details</returns>
        public List<ServiceOrderDetail> GetOrderDetails(int orderId)
        {
            string query = @"SELECT ctdv.MaChiTiet, ctdv.MaHD, ctdv.MaDichVu, dv.TenDichVu,
                            ctdv.SoLuong, ctdv.DonGia, ctdv.ThanhTien
                            FROM ChiTietDichVu ctdv
                            INNER JOIN DichVu dv ON ctdv.MaDichVu = dv.MaDichVu
                            WHERE ctdv.MaHD = @MaHD";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHD", orderId)
            };

            DataTable result = _db.GetData(query, parameters);
            List<ServiceOrderDetail> details = new List<ServiceOrderDetail>();

            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    ServiceOrderDetail detail = new ServiceOrderDetail
                    {
                        MaChiTiet = Convert.ToInt32(row["MaChiTiet"]),
                        MaHD = Convert.ToInt32(row["MaHD"]),
                        MaDichVu = Convert.ToInt32(row["MaDichVu"]),
                        SoLuong = Convert.ToInt32(row["SoLuong"]),
                        DonGia = Convert.ToDecimal(row["DonGia"]),
                        ThanhTien = Convert.ToDecimal(row["ThanhTien"])
                    };

                    details.Add(detail);
                }
            }

            return details;
        }
    }
}
