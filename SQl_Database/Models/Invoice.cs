using System;

namespace SQl_Database.Models
{
  public class Invoice
  {
    public int MaHD { get; set; }
    public DateTime NgayLap { get; set; }
    public int MaKH { get; set; }
    public string TenKH { get; set; }
    public int? MaNhanVien { get; set; }
    public string TenNhanVien { get; set; }
    public decimal TongTien { get; set; }
    public bool DaThanhToan { get; set; }
  }
}
