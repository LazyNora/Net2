using System;

namespace SQl_Database.Models
{
  public class Computer
  {
    public int MaMay { get; set; }
    public string TrangThaiMay { get; set; }
    public int MaPhong { get; set; }

    // Additional properties from joins
    public string TenPhong { get; set; }
    public decimal GiaMoiPhong { get; set; }

    // Session information
    public int? MaPhien { get; set; }
    public int? MaKH { get; set; }
    public string TenKH { get; set; }
    public DateTime? ThoiGianBatDau { get; set; }
    public DateTime? ThoiGianKetThuc { get; set; }

    // Balance information
    public decimal? SoDu { get; set; }

    // Invoice information
    public int? MaHD { get; set; }
    public bool DaThanhToan { get; set; }
  }
}
