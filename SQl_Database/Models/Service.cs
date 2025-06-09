using System;

namespace SQl_Database.Models
{
    public class Service
    {
        public int MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public decimal Gia { get; set; }
        public string Anh { get; set; }
        public int TonKho { get; set; }
        public int MaLoai { get; set; }
    }

    public class ServiceOrder
    {
        public int MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public int MaKH { get; set; }
        public int MaNhanVien { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }
    }

    public class ServiceOrderDetail
    {
        public int MaChiTiet { get; set; }
        public int MaHD { get; set; }
        public int MaDichVu { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
