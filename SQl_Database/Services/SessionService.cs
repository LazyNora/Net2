using System;
using System.Data;
using System.Data.SqlClient;
using SQl_Database.Models;

namespace SQl_Database.Services
{
    public class SessionService
    {
        private readonly Database _db;

        public SessionService()
        {
            _db = new Database();
        }

        /// <summary>
        /// Get the price per hour for the specified room ID
        /// </summary>
        /// <param name="roomId">The room ID</param>
        /// <returns>Price per hour</returns>
        public decimal GetRoomHourlyPrice(int roomId)
        {
            string query = "SELECT GiaMoiPhong FROM Phong WHERE MaPhong = @MaPhong";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaPhong", roomId)
            };

            DataTable result = _db.GetData(query, parameters);

            if (result != null && result.Rows.Count > 0)
            {
                return Convert.ToDecimal(result.Rows[0]["GiaMoiPhong"]);
            }

            return 0;
        }

        /// <summary>
        /// Get the room ID for a computer
        /// </summary>
        /// <param name="computerId">Computer ID</param>
        /// <returns>Room ID</returns>
        public int GetRoomIdForComputer(int computerId)
        {
            string query = "SELECT MaPhong FROM MayTinh WHERE MaMay = @MaMay";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaMay", computerId)
            };

            DataTable result = _db.GetData(query, parameters);

            if (result != null && result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["MaPhong"]);
            }

            return 0;
        }

        /// <summary>
        /// Create a new session for a customer
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <param name="computerId">Computer ID</param>
        /// <returns>Session ID if successful, -1 otherwise</returns>
        public int CreateSession(int customerId, int computerId)
        {
            string query = @"INSERT INTO PhienChoi (MaMay, MaKH, ThoiGianBatDau, ThoiGianKetThuc)
                            VALUES (@MaMay, @MaKH, @ThoiGianBatDau, NULL);
                            SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaMay", computerId),
                new SqlParameter("@MaKH", customerId),
                new SqlParameter("@ThoiGianBatDau", DateTime.Now)
            };

            try
            {
                // Use ExecuteScalar to get the inserted ID
                using (SqlConnection conn = new SqlConnection(_db.GetConnection().ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddRange(parameters);

                    // Get the new session ID
                    decimal result = (decimal)cmd.ExecuteScalar();
                    return (int)result;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi tạo phiên chơi: " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// End a session for a customer
        /// </summary>
        /// <param name="sessionId">Session ID</param>
        /// <returns>True if successful</returns>
        public bool EndSession(int sessionId)
        {
            string query = "UPDATE PhienChoi SET ThoiGianKetThuc = @ThoiGianKetThuc WHERE MaPhien = @MaPhien";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaPhien", sessionId),
                new SqlParameter("@ThoiGianKetThuc", DateTime.Now)
            };

            int result = _db.Execute(query, parameters);
            return result > 0;
        }

        /// <summary>
        /// Update computer status
        /// </summary>
        /// <param name="computerId">Computer ID</param>
        /// <param name="status">New status</param>
        /// <returns>True if successful</returns>
        public bool UpdateComputerStatus(int computerId, string status)
        {
            string query = "UPDATE MayTinh SET TrangThaiMay = @TrangThaiMay WHERE MaMay = @MaMay";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaMay", computerId),
                new SqlParameter("@TrangThaiMay", status)
            };

            int result = _db.Execute(query, parameters);
            return result > 0;
        }

        /// <summary>
        /// Update customer balance
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <param name="amount">Amount to deduct</param>
        /// <returns>True if successful</returns>
        public bool UpdateCustomerBalance(int customerId, decimal amount)
        {
            string query = "UPDATE KhachHang SET SoDu = SoDu - @Amount WHERE MaKH = @MaKH";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaKH", customerId),
                new SqlParameter("@Amount", amount)
            };

            int result = _db.Execute(query, parameters);
            return result > 0;
        }

        /// <summary>
        /// Change customer password
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <param name="newPassword">New password</param>
        /// <returns>True if successful</returns>
        public bool ChangeCustomerPassword(int customerId, string newPassword)
        {
            string query = "UPDATE KhachHang SET MatKhau = @MatKhau WHERE MaKH = @MaKH";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaKH", customerId),
                new SqlParameter("@MatKhau", newPassword)
            };

            int result = _db.Execute(query, parameters);
            return result > 0;
        }

        /// <summary>
        /// Validate customer's current password
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <param name="currentPassword">Current password to validate</param>
        /// <returns>True if password is correct</returns>
        public bool ValidateCustomerPassword(int customerId, string currentPassword)
        {
            string query = "SELECT COUNT(1) FROM KhachHang WHERE MaKH = @MaKH AND MatKhau = @MatKhau";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaKH", customerId),
                new SqlParameter("@MatKhau", currentPassword)
            };

            DataTable result = _db.GetData(query, parameters);

            if (result != null && result.Rows.Count > 0)
            {
                int count = Convert.ToInt32(result.Rows[0][0]);
                return count > 0;
            }

            return false;
        }

        /// <summary>
        /// Get current balance for customer
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <returns>Current balance</returns>
        public decimal GetCustomerBalance(int customerId)
        {
            string query = "SELECT SoDu FROM KhachHang WHERE MaKH = @MaKH";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaKH", customerId)
            };

            DataTable result = _db.GetData(query, parameters);

            if (result != null && result.Rows.Count > 0)
            {
                return Convert.ToDecimal(result.Rows[0]["SoDu"]);
            }

            return 0;
        }
    }
}
