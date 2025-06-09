using System;

namespace SQl_Database.Models
{
    public class Employee
    {
        public int MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public string TenTK { get; set; }
        public string Email { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public string TrangThaiNV { get; set; }
        public int MaViTri { get; set; }
        public string TenViTri { get; set; }
    }
}
