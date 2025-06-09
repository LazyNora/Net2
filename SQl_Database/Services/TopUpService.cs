using SQl_Database.Models;
using SQL_Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SQl_Database.Services
{
	public class TopUpService
	{
		private readonly DBConnect db;

		public TopUpService()
		{
			db = new DBConnect("Cyber");
		}

		/// <summary>
		/// Get customer balance
		/// </summary>
		/// <param name="customerId">Customer ID</param>
		/// <returns>Current balance</returns>
		public decimal GetCustomerBalance(int customerId)
		{
			string query = $"SELECT SoDu FROM KhachHang WHERE MaKH = {customerId}";
			return db.getDecimal(query);
		}

		/// <summary>
		/// Create or get an existing invoice for top-up
		/// </summary>
		/// <param name="customerId">Customer ID</param>
		/// <param name="employeeId">Employee ID</param>
		/// <returns>Invoice ID</returns>
		public int GetOrCreateInvoice(int customerId, int employeeId)
		{
			// Check if there's an existing invoice for this customer today
			string checkInvoiceQuery = $@"SELECT TOP 1 MaHD FROM HoaDon
                                        WHERE MaKH = {customerId}
                                        AND CONVERT(date, NgayLap) = CONVERT(date, GETDATE())
                                        ORDER BY MaHD DESC";


			int invoiceId = -1;
			try
			{
				invoiceId = db.getInt(checkInvoiceQuery);
			}
			catch (Exception)
			{
			}

			if (invoiceId != -1)
			{

				// Check if employee is set, if not, update it
				string checkEmployeeQuery = $"SELECT MaNhanVien FROM HoaDon WHERE MaHD = {invoiceId}";
				string employeeIdStr = db.getString(checkEmployeeQuery);

				if (string.IsNullOrEmpty(employeeIdStr) || employeeIdStr == "NULL")
				{
					// Update the employee ID
					string updateEmployeeQuery = $"UPDATE HoaDon SET MaNhanVien = {employeeId} WHERE MaHD = {invoiceId}";
					db.updateToDataBase(updateEmployeeQuery);
				}

				return invoiceId;
			}
			else
			{
				// Create a new invoice
				string createInvoiceQuery = $@"INSERT INTO HoaDon (NgayLap, MaKH, MaNhanVien)
                                            VALUES (GETDATE(), {customerId}, {employeeId});
                                            SELECT SCOPE_IDENTITY()";

				return (int)db.getDecimal(createInvoiceQuery);
			}
		}

		/// <summary>
		/// Top up customer account
		/// </summary>
		/// <param name="customerId">Customer ID</param>
		/// <param name="amount">Amount to add</param>
		/// <param name="employeeId">Employee ID</param>
		/// <returns>True if successful</returns>
		public bool TopUpAccount(int customerId, decimal amount, int employeeId)
		{
			try
			{
				// Get or create invoice
				int invoiceId = GetOrCreateInvoice(customerId, employeeId);

				if (invoiceId > 0)
				{
					// Create a new ChiTietNap record
					string insertNapQuery = $@"INSERT INTO ChiTietNap (SoTienNap, MaHD)
                                            VALUES ({amount}, {invoiceId})";
					db.updateToDataBase(insertNapQuery);

					// Update customer balance
					string updateBalanceQuery = $@"UPDATE KhachHang
                                                SET SoDu = SoDu + {amount}
                                                WHERE MaKH = {customerId}";
					db.updateToDataBase(updateBalanceQuery);

					return true;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Perform a top-up operation for a customer
		/// </summary>
		/// <param name="customerId">Customer ID</param>
		/// <param name="invoiceId">Invoice ID</param>
		/// <param name="amount">Amount to top up</param>
		/// <returns>True if successful</returns>
		public bool PerformTopUp(int customerId, int invoiceId, decimal amount)
		{
			try
			{
				// Create a new ChiTietNap record
				string insertNapQuery = $@"INSERT INTO ChiTietNap (SoTienNap, MaHD)
                                        VALUES ({amount}, {invoiceId})";
				db.updateToDataBase(insertNapQuery);

				// Update customer balance
				string updateBalanceQuery = $@"UPDATE KhachHang
                                            SET SoDu = SoDu + {amount}
                                            WHERE MaKH = {customerId}";
				db.updateToDataBase(updateBalanceQuery);

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Get top-up history for a customer
		/// </summary>
		/// <param name="customerId">Customer ID</param>
		/// <returns>List of top-ups</returns>
		public List<TopUp> GetTopUpHistory(int customerId)
		{
			List<TopUp> topUps = new List<TopUp>();

			string query = @"SELECT ctn.MaChiTietNap, ctn.SoTienNap, ctn.MaHD, hd.NgayLap,
                           hd.MaKH, kh.TenKH, hd.MaNhanVien, nv.HoTen as TenNhanVien
                           FROM ChiTietNap ctn
                           JOIN HoaDon hd ON ctn.MaHD = hd.MaHD
                           JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                           LEFT JOIN NhanVien nv ON hd.MaNhanVien = nv.MaNhanVien
                           WHERE hd.MaKH = @MaKH
                           ORDER BY hd.NgayLap DESC, ctn.MaChiTietNap DESC";

			SqlParameter[] parameters = {
				new SqlParameter("@MaKH", customerId)
			};

			DataTable result = db.getDataTable(query, "TopUps");

			foreach (DataRow row in result.Rows)
			{
				TopUp topUp = new TopUp
				{
					MaChiTietNap = Convert.ToInt32(row["MaChiTietNap"]),
					SoTienNap = Convert.ToDecimal(row["SoTienNap"]),
					MaHD = Convert.ToInt32(row["MaHD"]),
					NgayNap = Convert.ToDateTime(row["NgayLap"]),
					MaKH = Convert.ToInt32(row["MaKH"]),
					TenKH = row["TenKH"].ToString()
				};

				if (row["MaNhanVien"] != DBNull.Value)
				{
					topUp.MaNhanVien = Convert.ToInt32(row["MaNhanVien"]);
					topUp.TenNhanVien = row["TenNhanVien"].ToString();
				}

				topUps.Add(topUp);
			}

			return topUps;
		}
	}
}
