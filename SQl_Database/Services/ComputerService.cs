using SQl_Database.Models;
using SQL_Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SQl_Database.Services
{
	public class ComputerService
	{
		private readonly DBConnect db;

		public ComputerService()
		{
			db = new DBConnect("Cyber");
		}

		/// <summary>
		/// Get all computers with their status and room information
		/// </summary>
		/// <returns>List of computers</returns>
		public List<Computer> GetAllComputers()
		{
			List<Computer> computers = new List<Computer>();

			string query = @"SELECT m.MaMay, m.TrangThaiMay, p.TenPhong, p.GiaMoiPhong,
                           (SELECT TOP 1 pc.MaPhien FROM PhienChoi pc
                            WHERE pc.MaMay = m.MaMay AND pc.ThoiGianKetThuc IS NULL) as MaPhien,
                           (SELECT TOP 1 pc.MaKH FROM PhienChoi pc
                            WHERE pc.MaMay = m.MaMay AND pc.ThoiGianKetThuc IS NULL) as MaKH,
                           (SELECT TOP 1 kh.TenKH FROM PhienChoi pc
                            JOIN KhachHang kh ON pc.MaKH = kh.MaKH
                            WHERE pc.MaMay = m.MaMay AND pc.ThoiGianKetThuc IS NULL) as TenKH,
                           (SELECT TOP 1 kh.SoDu FROM PhienChoi pc
                            JOIN KhachHang kh ON pc.MaKH = kh.MaKH
                            WHERE pc.MaMay = m.MaMay AND pc.ThoiGianKetThuc IS NULL) as SoDu,
                           (SELECT TOP 1 pc.ThoiGianBatDau FROM PhienChoi pc
                            WHERE pc.MaMay = m.MaMay AND pc.ThoiGianKetThuc IS NULL) as ThoiGianBatDau
                           FROM MayTinh m
                           JOIN Phong p ON m.MaPhong = p.MaPhong
                           ORDER BY m.MaMay";

			if (db.Dset.Tables["Computers"] != null)
			{
				db.Dset.Tables["Computers"].Clear();
			}

			DataTable result = db.getDataTable(query, "Computers");

			foreach (DataRow row in result.Rows)
			{
				Computer computer = new Computer
				{
					MaMay = Convert.ToInt32(row["MaMay"]),
					TrangThaiMay = row["TrangThaiMay"].ToString(),
					TenPhong = row["TenPhong"].ToString(),
					GiaMoiPhong = Convert.ToDecimal(row["GiaMoiPhong"])
				};

				// Add session information if available
				if (row["MaPhien"] != DBNull.Value)
				{
					computer.MaPhien = Convert.ToInt32(row["MaPhien"]);
					computer.MaKH = Convert.ToInt32(row["MaKH"]);
					computer.TenKH = row["TenKH"].ToString();
					computer.SoDu = Convert.ToDecimal(row["SoDu"]);
					computer.ThoiGianBatDau = Convert.ToDateTime(row["ThoiGianBatDau"]);
				}

				computers.Add(computer);
			}

			return computers;
		}

		/// <summary>
		/// Get a specific computer by ID with detailed information
		/// </summary>
		/// <param name="computerId">Computer ID</param>
		/// <returns>Computer details</returns>
		public Computer GetComputerById(int computerId)
		{
			string query = @"SELECT m.MaMay, m.TrangThaiMay, m.MaPhong, p.TenPhong, p.GiaMoiPhong,
                           (SELECT TOP 1 pc.MaPhien FROM PhienChoi pc
                            WHERE pc.MaMay = m.MaMay AND pc.ThoiGianKetThuc IS NULL) as MaPhien,
                           (SELECT TOP 1 pc.MaKH FROM PhienChoi pc
                            WHERE pc.MaMay = m.MaMay AND pc.ThoiGianKetThuc IS NULL) as MaKH,
                           (SELECT TOP 1 kh.TenKH FROM PhienChoi pc
                            JOIN KhachHang kh ON pc.MaKH = kh.MaKH
                            WHERE pc.MaMay = m.MaMay AND pc.ThoiGianKetThuc IS NULL) as TenKH,
                           (SELECT TOP 1 kh.SoDu FROM PhienChoi pc
                            JOIN KhachHang kh ON pc.MaKH = kh.MaKH
                            WHERE pc.MaMay = m.MaMay AND pc.ThoiGianKetThuc IS NULL) as SoDu,
                           (SELECT TOP 1 pc.ThoiGianBatDau FROM PhienChoi pc
                            WHERE pc.MaMay = m.MaMay AND pc.ThoiGianKetThuc IS NULL) as ThoiGianBatDau,
                           (SELECT TOP 1 hd.MaHD FROM HoaDon hd
                            JOIN PhienChoi pc ON hd.MaKH = pc.MaKH
                            WHERE pc.MaMay = m.MaMay AND pc.ThoiGianKetThuc IS NULL
                            AND CONVERT(DATE, hd.NgayLap) = CONVERT(DATE, GETDATE())
                            ORDER BY hd.MaHD DESC) as MaHD
                           FROM MayTinh m
                           JOIN Phong p ON m.MaPhong = p.MaPhong
                           WHERE m.MaMay = @MaMay";

			SqlParameter[] parameters = {
				new SqlParameter("@MaMay", computerId)
			};

			using (SqlConnection conn = new SqlConnection(db.strConnect))
			{
				conn.Open();
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddRange(parameters);

					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							Computer computer = new Computer
							{
								MaMay = computerId,
								TrangThaiMay = reader["TrangThaiMay"].ToString(),
								MaPhong = Convert.ToInt32(reader["MaPhong"]),
								TenPhong = reader["TenPhong"].ToString(),
								GiaMoiPhong = Convert.ToDecimal(reader["GiaMoiPhong"])
							};

							// Add session information if available
							if (reader["MaPhien"] != DBNull.Value)
							{
								computer.MaPhien = Convert.ToInt32(reader["MaPhien"]);
								computer.MaKH = Convert.ToInt32(reader["MaKH"]);
								computer.TenKH = reader["TenKH"].ToString();
								computer.SoDu = Convert.ToDecimal(reader["SoDu"]);
								computer.ThoiGianBatDau = Convert.ToDateTime(reader["ThoiGianBatDau"]);
							}

							// Add invoice information if available
							if (reader["MaHD"] != DBNull.Value)
							{
								computer.MaHD = Convert.ToInt32(reader["MaHD"]);

								// Check if the computer has been paid for
								string paymentQuery = $@"SELECT COUNT(1)
														 FROM ThanhToan tt
														 WHERE tt.MaHD = {computer.MaHD}";
								bool hasPaid = db.checkExist(paymentQuery);
								computer.DaThanhToan = hasPaid;
							}

							return computer;
						}
					}
				}
			}

			return null;
		}

		/// <summary>
		/// Shutdown a computer and end its active session
		/// </summary>
		/// <param name="computerId">Computer ID</param>
		/// <returns>True if successful</returns>
		public bool ShutdownComputer(int computerId)
		{
			try
			{
				// Find active session for this computer
				string sessionQuery = $@"SELECT TOP 1 MaPhien
                                      FROM PhienChoi
                                      WHERE MaMay = {computerId}
                                      AND ThoiGianKetThuc IS NULL";

				string sessionIdStr = db.getString(sessionQuery);

				if (!string.IsNullOrEmpty(sessionIdStr))
				{
					int sessionId = int.Parse(sessionIdStr);

					// End the session
					string endSessionQuery = $@"UPDATE PhienChoi
                                             SET ThoiGianKetThuc = GETDATE()
                                             WHERE MaPhien = {sessionId}";

					db.updateToDataBase(endSessionQuery);
				}

				// Update computer status
				string updateStatusQuery = $@"UPDATE MayTinh
                                          SET TrangThaiMay = N'Sẵn sàng'
                                          WHERE MaMay = {computerId}";

				db.updateToDataBase(updateStatusQuery);

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Get invoice information for a specific computer
		/// </summary>
		/// <param name="computerId">Computer ID</param>
		/// <returns>Invoice details</returns>
		public Invoice GetInvoiceForComputer(int computerId)
		{
			string query = @"SELECT hd.MaHD, hd.NgayLap, hd.MaKH, kh.TenKH, hd.MaNhanVien, nv.HoTen as TenNhanVien,
                           (SELECT ISNULL(SUM(ThanhTien), 0) FROM ChiTietDichVu WHERE MaHD = hd.MaHD) as TongDichVu,
                           (SELECT ISNULL(SUM(SoTienNap), 0) FROM ChiTietNap WHERE MaHD = hd.MaHD) as TongNap,
                           CASE WHEN EXISTS(SELECT 1 FROM ThanhToan WHERE MaHD = hd.MaHD) THEN 1 ELSE 0 END as DaThanhToan
                           FROM HoaDon hd
                           JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                           LEFT JOIN NhanVien nv ON hd.MaNhanVien = nv.MaNhanVien
                           JOIN PhienChoi pc ON hd.MaKH = pc.MaKH
                           WHERE pc.MaMay = @MaMay AND pc.ThoiGianKetThuc IS NULL
                           AND CONVERT(DATE, hd.NgayLap) = CONVERT(DATE, GETDATE())
                           ORDER BY hd.MaHD DESC";

			SqlParameter[] parameters = {
				new SqlParameter("@MaMay", computerId)
			};

			using (SqlConnection conn = new SqlConnection(db.strConnect))
			{
				conn.Open();

				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddRange(parameters);

					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							decimal tongDichVu = Convert.ToDecimal(reader["TongDichVu"]);
							decimal tongNap = Convert.ToDecimal(reader["TongNap"]);

							Invoice invoice = new Invoice
							{
								MaHD = Convert.ToInt32(reader["MaHD"]),
								NgayLap = Convert.ToDateTime(reader["NgayLap"]),
								MaKH = Convert.ToInt32(reader["MaKH"]),
								TenKH = reader["TenKH"].ToString(),
								DaThanhToan = Convert.ToBoolean(reader["DaThanhToan"]),
								TongTien = tongDichVu + tongNap
							};

							if (reader["MaNhanVien"] != DBNull.Value)
							{
								invoice.MaNhanVien = Convert.ToInt32(reader["MaNhanVien"]);
								invoice.TenNhanVien = reader["TenNhanVien"].ToString();
							}

							return invoice;
						}
					}
				}

			}

			return null;
		}

		/// <summary>
		/// Calculate the current cost for a computer session
		/// </summary>
		/// <param name="computerId">Computer ID</param>
		/// <returns>Current cost</returns>
		public decimal CalculateCurrentCost(int computerId)
		{
			Computer computer = GetComputerById(computerId);

			if (computer != null && computer.ThoiGianBatDau.HasValue)
			{
				TimeSpan duration = DateTime.Now - computer.ThoiGianBatDau.Value;
				decimal hours = (decimal)duration.TotalHours;

				return Math.Ceiling(hours) * computer.GiaMoiPhong;
			}

			return 0;
		}
	}
}
