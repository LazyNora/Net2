using System;

namespace SQl_Database.Models
{
  public class TopUp
  {
    public int MaChiTietNap { get; set; }
    public decimal SoTienNap { get; set; }
    public int MaHD { get; set; }

    // Additional properties
    public DateTime NgayNap { get; set; }
    public int MaKH { get; set; }
    public string TenKH { get; set; }
    public int? MaNhanVien { get; set; }
    public string TenNhanVien { get; set; }
  }
}
