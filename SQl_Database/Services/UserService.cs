using System;
using System.Data;
using System.Data.SqlClient;
using SQl_Database.Models;

namespace SQl_Database.Services
{
    public class UserService
    {
        private readonly Database _db;

        public UserService()
        {
            _db = new Database();
        }

        public Employee EmployeeLogin(string username, string password)
        {
            string query = @"SELECT nv.*, vt.TenViTri
                            FROM NhanVien nv
                            JOIN ViTri vt ON nv.MaViTri = vt.MaViTri
                            WHERE nv.TenTK = @Username AND nv.MatKhau = @Password AND nv.TrangThaiNV = N'Đang làm'";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            DataTable result = _db.GetData(query, parameters);

            if (result != null && result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];

                return new Employee
                {
                    MaNhanVien = Convert.ToInt32(row["MaNhanVien"]),
                    HoTen = row["HoTen"].ToString(),
                    TenTK = row["TenTK"].ToString(),
                    Email = row["Email"].ToString(),
                    NgayVaoLam = Convert.ToDateTime(row["NgayVaoLam"]),
                    TrangThaiNV = row["TrangThaiNV"].ToString(),
                    MaViTri = Convert.ToInt32(row["MaViTri"]),
                    TenViTri = row["TenViTri"].ToString()
                };
            }

            return null;
        }

        public Customer CustomerLogin(string username, string password)
        {
            string query = "SELECT * FROM KhachHang WHERE TenTK = @Username AND MatKhau = @Password AND TrangThaiKH = N'Hoạt động'";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            DataTable result = _db.GetData(query, parameters);

            if (result != null && result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];

                return new Customer
                {
                    MaKH = Convert.ToInt32(row["MaKH"]),
                    TenKH = row["TenKH"].ToString(),
                    TenTK = row["TenTK"].ToString(),
                    Email = row["Email"].ToString(),
                    TrangThaiKH = row["TrangThaiKH"].ToString(),
                    SoDu = Convert.ToDecimal(row["SoDu"])
                };
            }

            return null;
        }

        public DataTable GetAllCustomers()
        {
            string query = @"SELECT MaKH, TenKH, TenTK, Email, TrangThaiKH, SoDu
                            FROM KhachHang
                            ORDER BY MaKH DESC";

            return _db.GetData(query);
        }

        public DataTable GetAllEmployees()
        {
            string query = @"SELECT nv.*, vt.TenViTri
                            FROM NhanVien nv
                            JOIN ViTri vt ON nv.MaViTri = vt.MaViTri";

            return _db.GetData(query);
        }
    }
}
