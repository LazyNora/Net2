USE [master]
GO
/****** Object:  Database [Cyber]    Script Date: 09/06/2025 12:00:50 PM ******/
CREATE DATABASE [Cyber]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cyber', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\Cyber.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cyber_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\Cyber_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Cyber] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cyber].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cyber] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cyber] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cyber] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cyber] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cyber] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cyber] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cyber] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cyber] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cyber] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cyber] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cyber] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cyber] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cyber] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cyber] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cyber] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Cyber] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cyber] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cyber] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cyber] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cyber] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cyber] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cyber] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cyber] SET RECOVERY FULL 
GO
ALTER DATABASE [Cyber] SET  MULTI_USER 
GO
ALTER DATABASE [Cyber] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cyber] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cyber] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cyber] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Cyber] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Cyber] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Cyber', N'ON'
GO
ALTER DATABASE [Cyber] SET QUERY_STORE = ON
GO
ALTER DATABASE [Cyber] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Cyber]
GO
/****** Object:  Table [dbo].[ChiTietDichVu]    Script Date: 09/06/2025 12:00:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDichVu](
	[MaCTDV] [int] IDENTITY(1,1) NOT NULL,
	[MaHD] [int] NOT NULL,
	[MaDichVu] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [decimal](10, 2) NOT NULL,
	[ThanhTien] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCTDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietNap]    Script Date: 09/06/2025 12:00:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietNap](
	[MaChiTietNap] [int] IDENTITY(1,1) NOT NULL,
	[SoTienNap] [decimal](10, 2) NOT NULL,
	[MaHD] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChiTietNap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 09/06/2025 12:00:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[MaDichVu] [int] IDENTITY(1,1) NOT NULL,
	[TenDichVu] [nvarchar](50) NOT NULL,
	[Gia] [decimal](10, 2) NOT NULL,
	[Anh] [nvarchar](50) NOT NULL,
	[TonKho] [int] NOT NULL,
	[MaLoai] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 09/06/2025 12:00:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[NgayLap] [date] NOT NULL,
	[MaKH] [int] NOT NULL,
	[MaNhanVien] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 09/06/2025 12:00:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](50) NOT NULL,
	[TenTK] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[TrangThaiKH] [nvarchar](50) NOT NULL,
	[SoDu] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiDichVu]    Script Date: 09/06/2025 12:00:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiDichVu](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiDichVu] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MayTinh]    Script Date: 09/06/2025 12:00:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MayTinh](
	[MaMay] [int] IDENTITY(1,1) NOT NULL,
	[TrangThaiMay] [nvarchar](50) NOT NULL,
	[MaPhong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 09/06/2025 12:00:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[TenTK] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[NgayVaoLam] [date] NOT NULL,
	[TrangThaiNV] [nvarchar](50) NOT NULL,
	[MaViTri] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhienChoi]    Script Date: 09/06/2025 12:00:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhienChoi](
	[MaPhien] [int] IDENTITY(1,1) NOT NULL,
	[MaMay] [int] NOT NULL,
	[MaKH] [int] NOT NULL,
	[ThoiGianBatDau] [datetime] NOT NULL,
	[ThoiGianKetThuc] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phong]    Script Date: 09/06/2025 12:00:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phong](
	[MaPhong] [int] IDENTITY(1,1) NOT NULL,
	[TenPhong] [nvarchar](50) NOT NULL,
	[GiaMoiPhong] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThanhToan]    Script Date: 09/06/2025 12:00:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThanhToan](
	[MaThanhToan] [int] IDENTITY(1,1) NOT NULL,
	[SoTienTT] [decimal](10, 2) NOT NULL,
	[PhuongThucTT] [nvarchar](50) NOT NULL,
	[MaHD] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaThanhToan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ViTri]    Script Date: 09/06/2025 12:00:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ViTri](
	[MaViTri] [int] IDENTITY(1,1) NOT NULL,
	[TenViTri] [nvarchar](50) NOT NULL,
	[LuongMoiThang] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaViTri] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChiTietDichVu] ON 

INSERT [dbo].[ChiTietDichVu] ([MaCTDV], [MaHD], [MaDichVu], [SoLuong], [DonGia], [ThanhTien]) VALUES (4, 9, 1, 1, CAST(30000.00 AS Decimal(10, 2)), CAST(30000.00 AS Decimal(10, 2)))
INSERT [dbo].[ChiTietDichVu] ([MaCTDV], [MaHD], [MaDichVu], [SoLuong], [DonGia], [ThanhTien]) VALUES (5, 10, 1, 1, CAST(30000.00 AS Decimal(10, 2)), CAST(30000.00 AS Decimal(10, 2)))
INSERT [dbo].[ChiTietDichVu] ([MaCTDV], [MaHD], [MaDichVu], [SoLuong], [DonGia], [ThanhTien]) VALUES (6, 10, 2, 1, CAST(30000.00 AS Decimal(10, 2)), CAST(30000.00 AS Decimal(10, 2)))
INSERT [dbo].[ChiTietDichVu] ([MaCTDV], [MaHD], [MaDichVu], [SoLuong], [DonGia], [ThanhTien]) VALUES (7, 10, 7, 3, CAST(30000.00 AS Decimal(10, 2)), CAST(90000.00 AS Decimal(10, 2)))
INSERT [dbo].[ChiTietDichVu] ([MaCTDV], [MaHD], [MaDichVu], [SoLuong], [DonGia], [ThanhTien]) VALUES (8, 10, 10, 1, CAST(15000.00 AS Decimal(10, 2)), CAST(15000.00 AS Decimal(10, 2)))
INSERT [dbo].[ChiTietDichVu] ([MaCTDV], [MaHD], [MaDichVu], [SoLuong], [DonGia], [ThanhTien]) VALUES (9, 10, 11, 9, CAST(15000.00 AS Decimal(10, 2)), CAST(135000.00 AS Decimal(10, 2)))
INSERT [dbo].[ChiTietDichVu] ([MaCTDV], [MaHD], [MaDichVu], [SoLuong], [DonGia], [ThanhTien]) VALUES (10, 11, 4, 1, CAST(10000.00 AS Decimal(10, 2)), CAST(10000.00 AS Decimal(10, 2)))
INSERT [dbo].[ChiTietDichVu] ([MaCTDV], [MaHD], [MaDichVu], [SoLuong], [DonGia], [ThanhTien]) VALUES (11, 11, 11, 1, CAST(15000.00 AS Decimal(10, 2)), CAST(15000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[ChiTietDichVu] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietNap] ON 

INSERT [dbo].[ChiTietNap] ([MaChiTietNap], [SoTienNap], [MaHD]) VALUES (3, CAST(1000.00 AS Decimal(10, 2)), 9)
INSERT [dbo].[ChiTietNap] ([MaChiTietNap], [SoTienNap], [MaHD]) VALUES (4, CAST(10000.00 AS Decimal(10, 2)), 10)
SET IDENTITY_INSERT [dbo].[ChiTietNap] OFF
GO
SET IDENTITY_INSERT [dbo].[DichVu] ON 

INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (1, N'Cơm chiên bò', CAST(30000.00 AS Decimal(10, 2)), N'/images/Cơm_chiên_bò.jpg', 3, 1)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (2, N'Cơm chiên trứng', CAST(30000.00 AS Decimal(10, 2)), N'/images/Cơm_chiên_trứng.jpg', 4, 1)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (3, N'Nui xào bò', CAST(30000.00 AS Decimal(10, 2)), N'/images/Nui_xào_bò.jpg', 5, 1)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (4, N'Mì tôm', CAST(10000.00 AS Decimal(10, 2)), N'/images/Mì_tôm.jpg', 20, 1)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (5, N'Mì tôm trứng', CAST(20000.00 AS Decimal(10, 2)), N'/images/Mì_tôm_trứng.jpg', 40, 1)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (6, N'Cá viên chiên', CAST(15000.00 AS Decimal(10, 2)), N'/images/Cá_viên_chiên.jpg', 36, 1)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (7, N'Mì xào bò', CAST(30000.00 AS Decimal(10, 2)), N'/images/Mì_xào_bò.jpg', 2, 1)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (8, N'Com rang thập cẩm', CAST(30000.00 AS Decimal(10, 2)), N'/images/Cơm_rang_thập_cẩm.jpg', 1, 1)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (9, N'Coca', CAST(15000.00 AS Decimal(10, 2)), N'/images/Coca.jpg', 60, 2)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (10, N'Pepsi', CAST(15000.00 AS Decimal(10, 2)), N'/images/Pepsi.jpg', 45, 2)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (11, N'7up', CAST(15000.00 AS Decimal(10, 2)), N'/images/7up.jpg', 20, 2)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (12, N'Nước suối', CAST(10000.00 AS Decimal(10, 2)), N'/images/Nước_suối.jpg', 33, 2)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (13, N'Sting', CAST(15000.00 AS Decimal(10, 2)), N'/images/Sting.jpg', 57, 2)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (14, N'Redbull', CAST(20000.00 AS Decimal(10, 2)), N'/images/Redbull.jpg', 44, 2)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (15, N'Thẻ garena 100k', CAST(100000.00 AS Decimal(10, 2)), N'/images/Thẻ_garena_100k.jpg', 41, 3)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (16, N'Thẻ garena 200k', CAST(200000.00 AS Decimal(10, 2)), N'/images/Thẻ_garena_200k.jpg', 53, 3)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (17, N'Thẻ viettel 100k', CAST(100000.00 AS Decimal(10, 2)), N'/images/Thẻ_viettel_100k.jpg', 20, 3)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (18, N'Thẻ mobi 50k', CAST(50000.00 AS Decimal(10, 2)), N'/images/Thẻ_mobi_50k.jpg', 50, 3)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (19, N'Phở', CAST(30000.00 AS Decimal(10, 2)), N'/images/Phở.jpg', 20, 1)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (20, N'Cà phê', CAST(15000.00 AS Decimal(10, 2)), N'/images/Cà_phê.jpg', 14, 2)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (21, N'Bánh mì trứng', CAST(20000.00 AS Decimal(10, 2)), N'/images/Bánh_mì_trứng.jpg', 13, 1)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia], [Anh], [TonKho], [MaLoai]) VALUES (22, N'Bánh mì thịt', CAST(20000.00 AS Decimal(10, 2)), N'/images/Bánh_mì_thịt.jpg', 10, 1)
SET IDENTITY_INSERT [dbo].[DichVu] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaKH], [MaNhanVien]) VALUES (9, CAST(N'2025-06-09' AS Date), 1, 1)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaKH], [MaNhanVien]) VALUES (10, CAST(N'2025-06-09' AS Date), 1, 1)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaKH], [MaNhanVien]) VALUES (11, CAST(N'2025-06-09' AS Date), 1, NULL)
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [TenTK], [MatKhau], [Email], [TrangThaiKH], [SoDu]) VALUES (1, N'Khách 1', N'khach1', N'123', N'khach1@example.com', N'Hoạt động', CAST(96489.17 AS Decimal(10, 2)))
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [TenTK], [MatKhau], [Email], [TrangThaiKH], [SoDu]) VALUES (2, N'Khách 2', N'khach2', N'pass2', N'khach2@example.com', N'Hoạt động', CAST(200000.00 AS Decimal(10, 2)))
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [TenTK], [MatKhau], [Email], [TrangThaiKH], [SoDu]) VALUES (3, N'Khách 3', N'khach3', N'pass3', N'khach3@example.com', N'Đã khóa', CAST(150000.00 AS Decimal(10, 2)))
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [TenTK], [MatKhau], [Email], [TrangThaiKH], [SoDu]) VALUES (4, N'Khách 4', N'khach4', N'pass4', N'khach4@example.com', N'Hoạt động', CAST(50000.00 AS Decimal(10, 2)))
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [TenTK], [MatKhau], [Email], [TrangThaiKH], [SoDu]) VALUES (5, N'Khách 5', N'khach5', N'pass5', N'khach5@example.com', N'Hoạt động', CAST(75000.00 AS Decimal(10, 2)))
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [TenTK], [MatKhau], [Email], [TrangThaiKH], [SoDu]) VALUES (6, N'Khách 6', N'khach6', N'pass6', N'khach6@example.com', N'Đã khóa', CAST(0.00 AS Decimal(10, 2)))
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [TenTK], [MatKhau], [Email], [TrangThaiKH], [SoDu]) VALUES (7, N'Khách 7', N'khach7', N'pass7', N'khach7@example.com', N'Hoạt động', CAST(300000.00 AS Decimal(10, 2)))
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [TenTK], [MatKhau], [Email], [TrangThaiKH], [SoDu]) VALUES (8, N'Khách 8', N'khach8', N'pass8', N'khach8@example.com', N'Hoạt động', CAST(250000.00 AS Decimal(10, 2)))
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [TenTK], [MatKhau], [Email], [TrangThaiKH], [SoDu]) VALUES (9, N'Khách 9', N'khach9', N'pass9', N'khach9@example.com', N'Hoạt động', CAST(80000.00 AS Decimal(10, 2)))
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [TenTK], [MatKhau], [Email], [TrangThaiKH], [SoDu]) VALUES (10, N'Khách 10', N'khach10', N'pass10', N'khach10@example.com', N'Đã khóa', CAST(0.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiDichVu] ON 

INSERT [dbo].[LoaiDichVu] ([MaLoai], [TenLoaiDichVu]) VALUES (1, N'Đồ ăn')
INSERT [dbo].[LoaiDichVu] ([MaLoai], [TenLoaiDichVu]) VALUES (2, N'Nước uống')
INSERT [dbo].[LoaiDichVu] ([MaLoai], [TenLoaiDichVu]) VALUES (3, N'Khác')
SET IDENTITY_INSERT [dbo].[LoaiDichVu] OFF
GO
SET IDENTITY_INSERT [dbo].[MayTinh] ON 

INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (1, N'Đang sử dụng', 1)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (2, N'Sẵn sàng', 1)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (3, N'Sẵn sàng', 1)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (4, N'Sẵn sàng', 1)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (5, N'Sẵn sàng', 1)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (6, N'Sẵn sàng', 2)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (7, N'Sẵn sàng', 2)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (8, N'Sẵn sàng', 2)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (9, N'Sẵn sàng', 2)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (10, N'Sẵn sàng', 2)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (11, N'Sẵn sàng', 3)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (12, N'Sẵn sàng', 3)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (13, N'Sẵn sàng', 3)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (14, N'Sẵn sàng', 3)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (15, N'Sẵn sàng', 3)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (16, N'Sẵn sàng', 4)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (17, N'Sẵn sàng', 4)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (18, N'Sẵn sàng', 4)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (19, N'Sẵn sàng', 4)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (20, N'Sẵn sàng', 4)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (21, N'Sẵn sàng', 5)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (22, N'Sẵn sàng', 5)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (23, N'Sẵn sàng', 5)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (24, N'Sẵn sàng', 5)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (25, N'Sẵn sàng', 5)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (26, N'Sẵn sàng', 6)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (27, N'Sẵn sàng', 6)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (28, N'Sẵn sàng', 6)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (29, N'Sẵn sàng', 6)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (30, N'Sẵn sàng', 6)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (31, N'Sẵn sàng', 7)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (32, N'Sẵn sàng', 7)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (33, N'Sẵn sàng', 7)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (34, N'Sẵn sàng', 7)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (35, N'Sẵn sàng', 7)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (36, N'Sẵn sàng', 8)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (37, N'Sẵn sàng', 8)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (38, N'Sẵn sàng', 8)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (39, N'Sẵn sàng', 8)
INSERT [dbo].[MayTinh] ([MaMay], [TrangThaiMay], [MaPhong]) VALUES (40, N'Sẵn sàng', 8)
SET IDENTITY_INSERT [dbo].[MayTinh] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenTK], [MatKhau], [Email], [NgayVaoLam], [TrangThaiNV], [MaViTri]) VALUES (1, N'Nguyễn Văn A', N'nva1', N'123456', N'nva1@example.com', CAST(N'2022-01-15' AS Date), N'Đang làm', 1)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenTK], [MatKhau], [Email], [NgayVaoLam], [TrangThaiNV], [MaViTri]) VALUES (2, N'Trần Thị B', N'ttb2', N'abcdef', N'ttb2@example.com', CAST(N'2022-02-20' AS Date), N'Đang làm', 2)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenTK], [MatKhau], [Email], [NgayVaoLam], [TrangThaiNV], [MaViTri]) VALUES (3, N'Lê Văn C', N'lvc3', N'pass123', N'lvc3@example.com', CAST(N'2022-03-10' AS Date), N'Đang làm', 3)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenTK], [MatKhau], [Email], [NgayVaoLam], [TrangThaiNV], [MaViTri]) VALUES (4, N'Phạm Thị D', N'ptd4', N'123abc', N'ptd4@example.com', CAST(N'2022-04-05' AS Date), N'Nghỉ việc', 4)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenTK], [MatKhau], [Email], [NgayVaoLam], [TrangThaiNV], [MaViTri]) VALUES (5, N'Hoàng Văn E', N'hve5', N'qwerty', N'hve5@example.com', CAST(N'2022-05-25' AS Date), N'Đang làm', 3)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenTK], [MatKhau], [Email], [NgayVaoLam], [TrangThaiNV], [MaViTri]) VALUES (6, N'Ngô Thị F', N'ntf6', N'987654', N'ntf6@example.com', CAST(N'2022-06-18' AS Date), N'Đang làm', 2)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenTK], [MatKhau], [Email], [NgayVaoLam], [TrangThaiNV], [MaViTri]) VALUES (7, N'Vũ Văn G', N'vvg7', N'ghijkl', N'vvg7@example.com', CAST(N'2022-07-01' AS Date), N'Đang làm', 2)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenTK], [MatKhau], [Email], [NgayVaoLam], [TrangThaiNV], [MaViTri]) VALUES (8, N'Tạ Thị H', N'tth8', N'password', N'tth8@example.com', CAST(N'2022-08-12' AS Date), N'Nghỉ việc', 2)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenTK], [MatKhau], [Email], [NgayVaoLam], [TrangThaiNV], [MaViTri]) VALUES (9, N'Đặng Văn I', N'dvi9', N'letmein', N'dvi9@example.com', CAST(N'2022-09-20' AS Date), N'Đang làm', 4)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenTK], [MatKhau], [Email], [NgayVaoLam], [TrangThaiNV], [MaViTri]) VALUES (10, N'Lý Thị K', N'ltk10', N'welcome', N'ltk10@example.com', CAST(N'2022-10-30' AS Date), N'Đang làm', 4)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[PhienChoi] ON 

INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (1, 1, 1, CAST(N'2025-06-08T08:30:00.000' AS DateTime), CAST(N'2025-06-08T10:00:00.000' AS DateTime))
INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (2, 2, 2, CAST(N'2025-06-08T09:00:00.000' AS DateTime), CAST(N'2025-06-08T10:30:00.000' AS DateTime))
INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (4, 4, 4, CAST(N'2025-06-08T07:45:00.000' AS DateTime), CAST(N'2025-06-08T09:00:00.000' AS DateTime))
INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (5, 5, 5, CAST(N'2025-06-08T10:00:00.000' AS DateTime), CAST(N'2025-06-08T12:00:00.000' AS DateTime))
INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (7, 7, 7, CAST(N'2025-06-08T11:00:00.000' AS DateTime), CAST(N'2025-06-08T11:45:00.000' AS DateTime))
INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (8, 8, 8, CAST(N'2025-06-08T09:30:00.000' AS DateTime), CAST(N'2025-06-08T10:15:00.000' AS DateTime))
INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (33, 1, 1, CAST(N'2025-06-09T09:51:29.523' AS DateTime), CAST(N'2025-06-09T09:51:33.823' AS DateTime))
INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (34, 1, 1, CAST(N'2025-06-09T09:52:53.250' AS DateTime), CAST(N'2025-06-09T09:55:44.780' AS DateTime))
INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (35, 1, 1, CAST(N'2025-06-09T10:06:29.250' AS DateTime), CAST(N'2025-06-09T10:06:38.100' AS DateTime))
INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (36, 1, 1, CAST(N'2025-06-09T10:07:11.380' AS DateTime), CAST(N'2025-06-09T10:07:19.103' AS DateTime))
INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (37, 1, 1, CAST(N'2025-06-09T10:08:05.947' AS DateTime), CAST(N'2025-06-09T10:12:54.577' AS DateTime))
INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (38, 1, 1, CAST(N'2025-06-09T10:13:58.217' AS DateTime), CAST(N'2025-06-09T10:14:13.527' AS DateTime))
INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (39, 1, 1, CAST(N'2025-06-09T10:14:16.660' AS DateTime), CAST(N'2025-06-09T10:14:26.097' AS DateTime))
INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (40, 1, 1, CAST(N'2025-06-09T10:14:33.040' AS DateTime), CAST(N'2025-06-09T10:14:36.937' AS DateTime))
INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (41, 1, 1, CAST(N'2025-06-09T10:14:39.733' AS DateTime), CAST(N'2025-06-09T10:15:06.137' AS DateTime))
INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (42, 1, 1, CAST(N'2025-06-09T10:15:15.533' AS DateTime), CAST(N'2025-06-09T10:18:06.980' AS DateTime))
INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (43, 1, 1, CAST(N'2025-06-09T10:21:03.517' AS DateTime), CAST(N'2025-06-09T10:22:35.497' AS DateTime))
INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (44, 1, 1, CAST(N'2025-06-09T10:25:19.850' AS DateTime), CAST(N'2025-06-09T10:32:23.300' AS DateTime))
INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (45, 1, 1, CAST(N'2025-06-09T10:45:38.033' AS DateTime), CAST(N'2025-06-09T11:19:11.573' AS DateTime))
INSERT [dbo].[PhienChoi] ([MaPhien], [MaMay], [MaKH], [ThoiGianBatDau], [ThoiGianKetThuc]) VALUES (46, 1, 1, CAST(N'2025-06-09T11:52:35.807' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[PhienChoi] OFF
GO
SET IDENTITY_INSERT [dbo].[Phong] ON 

INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [GiaMoiPhong]) VALUES (1, N'Phòng 101', CAST(5000.00 AS Decimal(10, 2)))
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [GiaMoiPhong]) VALUES (2, N'Phòng 102', CAST(5000.00 AS Decimal(10, 2)))
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [GiaMoiPhong]) VALUES (3, N'Phòng 103', CAST(5000.00 AS Decimal(10, 2)))
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [GiaMoiPhong]) VALUES (4, N'Phòng 104', CAST(5000.00 AS Decimal(10, 2)))
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [GiaMoiPhong]) VALUES (5, N'Phòng VIP', CAST(10000.00 AS Decimal(10, 2)))
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [GiaMoiPhong]) VALUES (6, N'Phòng Game 1', CAST(6000.00 AS Decimal(10, 2)))
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [GiaMoiPhong]) VALUES (7, N'Phòng Thi Đấu', CAST(20000.00 AS Decimal(10, 2)))
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [GiaMoiPhong]) VALUES (8, N'Phòng Streamer', CAST(25000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Phong] OFF
GO
SET IDENTITY_INSERT [dbo].[ThanhToan] ON 

INSERT [dbo].[ThanhToan] ([MaThanhToan], [SoTienTT], [PhuongThucTT], [MaHD]) VALUES (1, CAST(31000.00 AS Decimal(10, 2)), N'Tiền mặt', 9)
INSERT [dbo].[ThanhToan] ([MaThanhToan], [SoTienTT], [PhuongThucTT], [MaHD]) VALUES (2, CAST(310000.00 AS Decimal(10, 2)), N'Ngân hàng', 10)
SET IDENTITY_INSERT [dbo].[ThanhToan] OFF
GO
SET IDENTITY_INSERT [dbo].[ViTri] ON 

INSERT [dbo].[ViTri] ([MaViTri], [TenViTri], [LuongMoiThang]) VALUES (1, N'Quản lý', CAST(15000000.00 AS Decimal(10, 2)))
INSERT [dbo].[ViTri] ([MaViTri], [TenViTri], [LuongMoiThang]) VALUES (2, N'Thu ngân', CAST(8000000.00 AS Decimal(10, 2)))
INSERT [dbo].[ViTri] ([MaViTri], [TenViTri], [LuongMoiThang]) VALUES (3, N'Phục vụ', CAST(7000000.00 AS Decimal(10, 2)))
INSERT [dbo].[ViTri] ([MaViTri], [TenViTri], [LuongMoiThang]) VALUES (4, N'IT hỗ trợ', CAST(9500000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[ViTri] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__KhachHan__4CF9E77737C1F4C0]    Script Date: 09/06/2025 12:00:51 PM ******/
ALTER TABLE [dbo].[KhachHang] ADD UNIQUE NONCLUSTERED 
(
	[TenTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__KhachHan__A9D10534EC7D147D]    Script Date: 09/06/2025 12:00:51 PM ******/
ALTER TABLE [dbo].[KhachHang] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NhanVien__4CF9E77728DB58FE]    Script Date: 09/06/2025 12:00:51 PM ******/
ALTER TABLE [dbo].[NhanVien] ADD UNIQUE NONCLUSTERED 
(
	[TenTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NhanVien__A9D10534BB71E396]    Script Date: 09/06/2025 12:00:51 PM ******/
ALTER TABLE [dbo].[NhanVien] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[KhachHang] ADD  DEFAULT ((0)) FOR [SoDu]
GO
ALTER TABLE [dbo].[ChiTietDichVu]  WITH CHECK ADD FOREIGN KEY([MaDichVu])
REFERENCES [dbo].[DichVu] ([MaDichVu])
GO
ALTER TABLE [dbo].[ChiTietDichVu]  WITH CHECK ADD FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[ChiTietNap]  WITH CHECK ADD FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[DichVu]  WITH CHECK ADD FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiDichVu] ([MaLoai])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[MayTinh]  WITH CHECK ADD FOREIGN KEY([MaPhong])
REFERENCES [dbo].[Phong] ([MaPhong])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaViTri])
REFERENCES [dbo].[ViTri] ([MaViTri])
GO
ALTER TABLE [dbo].[PhienChoi]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[PhienChoi]  WITH CHECK ADD FOREIGN KEY([MaMay])
REFERENCES [dbo].[MayTinh] ([MaMay])
GO
ALTER TABLE [dbo].[ThanhToan]  WITH CHECK ADD FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
GO
USE [master]
GO
ALTER DATABASE [Cyber] SET  READ_WRITE 
GO
