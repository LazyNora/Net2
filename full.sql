-- Tạo CSDL
CREATE DATABASE Cyber;
go 

USE Cyber;

go
-- Bảng Phòng
CREATE TABLE
    Phong (
        MaPhong INT PRIMARY KEY IDENTITY (1, 1),
        TenPhong NVARCHAR (50) NOT NULL,
        GiaMoiPhong DECIMAL(10, 2) NOT NULL
    );

INSERT INTO
    Phong (TenPhong, GiaMoiPhong)
VALUES
    (N'Phòng 101', 5000),
    (N'Phòng 102', 5000),
    (N'Phòng 103', 5000),
    (N'Phòng 104', 5000),
    (N'Phòng VIP', 10000),
    (N'Phòng Game 1', 6000),
    (N'Phòng Thi Đấu', 20000),
    (N'Phòng Streamer', 25000);

-- Bảng Máy Tính
CREATE TABLE
    MayTinh (
        MaMay INT PRIMARY KEY IDENTITY (1, 1),
        TrangThaiMay NVARCHAR (50) NOT NULL,
        MaPhong INT, -- Máy tính thuộc phòng nào
        FOREIGN KEY (MaPhong) REFERENCES Phong (MaPhong)
    );

INSERT INTO
    MayTinh (TrangThaiMay, MaPhong)
VALUES
    (N'Sẵn sàng', 1),
    (N'Sẵn sàng', 1),
    (N'Sẵn sàng', 1),
    (N'Sẵn sàng', 1),
    (N'Sẵn sàng', 1),
    (N'Sẵn sàng', 2),
    (N'Sẵn sàng', 2),
    (N'Sẵn sàng', 2),
    (N'Sẵn sàng', 2),
    (N'Sẵn sàng', 2),
    (N'Sẵn sàng', 3),
    (N'Sẵn sàng', 3),
    (N'Sẵn sàng', 3),
    (N'Sẵn sàng', 3),
    (N'Sẵn sàng', 3),
    (N'Sẵn sàng', 4),
    (N'Sẵn sàng', 4),
    (N'Sẵn sàng', 4),
    (N'Sẵn sàng', 4),
    (N'Sẵn sàng', 4),
    (N'Sẵn sàng', 5),
    (N'Sẵn sàng', 5),
    (N'Sẵn sàng', 5),
    (N'Sẵn sàng', 5),
    (N'Sẵn sàng', 5),
    (N'Sẵn sàng', 6),
    (N'Sẵn sàng', 6),
    (N'Sẵn sàng', 6),
    (N'Sẵn sàng', 6),
    (N'Sẵn sàng', 6),
    (N'Sẵn sàng', 7),
    (N'Sẵn sàng', 7),
    (N'Sẵn sàng', 7),
    (N'Sẵn sàng', 7),
    (N'Sẵn sàng', 7),
    (N'Sẵn sàng', 8),
    (N'Sẵn sàng', 8),
    (N'Sẵn sàng', 8),
    (N'Sẵn sàng', 8),
    (N'Sẵn sàng', 8);

-- Bảng Vị Trí Nhân Viên
CREATE TABLE
    ViTri (
        MaViTri INT PRIMARY KEY IDENTITY (1, 1),
        TenViTri NVARCHAR (50) NOT NULL,
        LuongMoiThang DECIMAL(10, 2) NOT NULL
    );

INSERT INTO
    ViTri (TenViTri, LuongMoiThang)
VALUES
    (N'Quản lý', 15000000),
    (N'Thu ngân', 8000000),
    (N'Phục vụ', 7000000),
    (N'IT hỗ trợ', 9500000);

-- Bảng Nhân Viên
CREATE TABLE
    NhanVien (
        MaNhanVien INT PRIMARY KEY IDENTITY (1, 1),
        HoTen NVARCHAR (50) NOT NULL,
        TenTK NVARCHAR (50) UNIQUE NOT NULL,
        MatKhau NVARCHAR (50) NOT NULL,
        Email NVARCHAR (50) UNIQUE NOT NULL,
        NgayVaoLam DATE NOT NULL,
        TrangThaiNV NVARCHAR (50) NOT NULL,
        MaViTri INT NOT NULL, -- Nhân viên có vị trí công việc
        FOREIGN KEY (MaViTri) REFERENCES ViTri (MaViTri)
    );

INSERT INTO
    NhanVien (
        HoTen,
        TenTK,
        MatKhau,
        Email,
        NgayVaoLam,
        TrangThaiNV,
        MaViTri
    )
VALUES
    (
        N'Nguyễn Văn A',
        'nva1',
        '123456',
        'nva1@example.com',
        '2022-01-15',
        N'Đang làm',
        1
    ),
    (
        N'Trần Thị B',
        'ttb2',
        'abcdef',
        'ttb2@example.com',
        '2022-02-20',
        N'Đang làm',
        2
    ),
    (
        N'Lê Văn C',
        'lvc3',
        'pass123',
        'lvc3@example.com',
        '2022-03-10',
        N'Đang làm',
        3
    ),
    (
        N'Phạm Thị D',
        'ptd4',
        '123abc',
        'ptd4@example.com',
        '2022-04-05',
        N'Nghỉ việc',
        4
    ),
    (
        N'Hoàng Văn E',
        'hve5',
        'qwerty',
        'hve5@example.com',
        '2022-05-25',
        N'Đang làm',
        3
    ),
    (
        N'Ngô Thị F',
        'ntf6',
        '987654',
        'ntf6@example.com',
        '2022-06-18',
        N'Đang làm',
        2
    ),
    (
        N'Vũ Văn G',
        'vvg7',
        'ghijkl',
        'vvg7@example.com',
        '2022-07-01',
        N'Đang làm',
        2
    ),
    (
        N'Tạ Thị H',
        'tth8',
        'password',
        'tth8@example.com',
        '2022-08-12',
        N'Nghỉ việc',
        2
    ),
    (
        N'Đặng Văn I',
        'dvi9',
        'letmein',
        'dvi9@example.com',
        '2022-09-20',
        N'Đang làm',
        4
    ),
    (
        N'Lý Thị K',
        'ltk10',
        'welcome',
        'ltk10@example.com',
        '2022-10-30',
        N'Đang làm',
        4
    );

-- Bảng Khách Hàng
CREATE TABLE
    KhachHang (
        MaKH INT PRIMARY KEY IDENTITY (1, 1),
        TenKH NVARCHAR (50) NOT NULL,
        TenTK NVARCHAR (50) UNIQUE NOT NULL,
        MatKhau NVARCHAR (50) NOT NULL,
        Email NVARCHAR (50) UNIQUE NOT NULL,
        TrangThaiKH NVARCHAR (50) NOT NULL,
        SoDu DECIMAL(10, 2) DEFAULT 0
    );

INSERT INTO
    KhachHang (TenKH, TenTK, MatKhau, Email, TrangThaiKH, SoDu)
VALUES
    (
        N'Khách 1',
        'khach1',
        'pass1',
        'khach1@example.com',
        N'Hoạt động',
        100000
    ),
    (
        N'Khách 2',
        'khach2',
        'pass2',
        'khach2@example.com',
        N'Hoạt động',
        200000
    ),
    (
        N'Khách 3',
        'khach3',
        'pass3',
        'khach3@example.com',
        N'Đã khóa',
        150000
    ),
    (
        N'Khách 4',
        'khach4',
        'pass4',
        'khach4@example.com',
        N'Hoạt động',
        50000
    ),
    (
        N'Khách 5',
        'khach5',
        'pass5',
        'khach5@example.com',
        N'Hoạt động',
        75000
    ),
    (
        N'Khách 6',
        'khach6',
        'pass6',
        'khach6@example.com',
        N'Đã khóa',
        0
    ),
    (
        N'Khách 7',
        'khach7',
        'pass7',
        'khach7@example.com',
        N'Hoạt động',
        300000
    ),
    (
        N'Khách 8',
        'khach8',
        'pass8',
        'khach8@example.com',
        N'Hoạt động',
        250000
    ),
    (
        N'Khách 9',
        'khach9',
        'pass9',
        'khach9@example.com',
        N'Hoạt động',
        80000
    ),
    (
        N'Khách 10',
        'khach10',
        'pass10',
        'khach10@example.com',
        N'Đã khóa',
        0
    );

-- Bảng Phiên Chơi
CREATE TABLE
    PhienChoi (
        MaPhien INT PRIMARY KEY IDENTITY (1, 1),
        MaMay INT NOT NULL,
        MaKH INT NOT NULL, -- Khách hàng sử dụng máy
        ThoiGianBatDau DATETIME NOT NULL,
        ThoiGianKetThuc DATETIME NULL,
        FOREIGN KEY (MaMay) REFERENCES MayTinh (MaMay),
        FOREIGN KEY (MaKH) REFERENCES KhachHang (MaKH)
    );

INSERT INTO
    PhienChoi (MaMay, MaKH, ThoiGianBatDau, ThoiGianKetThuc)
VALUES
    (
        1,
        1,
        '2025-06-08 08:30:00',
        '2025-06-08 10:00:00'
    ),
    (
        2,
        2,
        '2025-06-08 09:00:00',
        '2025-06-08 10:30:00'
    ),
    (3, 3, '2025-06-08 10:15:00', NULL), -- Phiên đang chơi
    (
        4,
        4,
        '2025-06-08 07:45:00',
        '2025-06-08 09:00:00'
    ),
    (
        5,
        5,
        '2025-06-08 10:00:00',
        '2025-06-08 12:00:00'
    ),
    (6, 6, '2025-06-08 08:00:00', NULL), -- Phiên đang chơi
    (
        7,
        7,
        '2025-06-08 11:00:00',
        '2025-06-08 11:45:00'
    ),
    (
        8,
        8,
        '2025-06-08 09:30:00',
        '2025-06-08 10:15:00'
    );

-- Bảng Loại Dịch Vụ
CREATE TABLE
    LoaiDichVu (
        MaLoai INT PRIMARY KEY IDENTITY (1, 1),
        TenLoaiDichVu NVARCHAR (50) NOT NULL
    );

INSERT INTO
    LoaiDichVu (TenLoaiDichVu)
VALUES
    (N'Đồ ăn'),
    (N'Nước uống'),
    (N'Khác');

-- Bảng Dịch Vụ
CREATE TABLE
    DichVu (
        MaDichVu INT PRIMARY KEY IDENTITY (1, 1),
        TenDichVu NVARCHAR (50) NOT NULL,
        Gia DECIMAL(10, 2) NOT NULL,
        Anh NVARCHAR (50) NOT NULL,
        TonKho INT NOT NULL,
        MaLoai INT NOT NULL,
        FOREIGN KEY (MaLoai) REFERENCES LoaiDichVu (MaLoai)
    );

INSERT INTO
    DichVu (TenDichVu, Gia, Anh, TonKho, MaLoai)
VALUES
    (
        N'Cơm chiên bò',
        30000,
        N'/images/Cơm_chiên_bò.jpg',
        3,
        1
    ),
    (
        N'Cơm chiên trứng',
        30000,
        N'/images/Cơm_chiên_trứng.jpg',
        4,
        1
    ),
    (
        N'Nui xào bò',
        30000,
        N'/images/Nui_xào_bò.jpg',
        5,
        1
    ),
    (N'Mì tôm', 10000, N'/images/Mì_tôm.jpg', 20, 1),
    (
        N'Mì tôm trứng',
        20000,
        N'/images/Mì_tôm_trứng.jpg',
        40,
        1
    ),
    (
        N'Cá viên chiên',
        15000,
        N'/images/Cá_viên_chiên.jpg',
        36,
        1
    ),
    (
        N'Mì xào bò',
        30000,
        N'/images/Mì_xào_bò.jpg',
        2,
        1
    ),
    (
        N'Com rang thập cẩm',
        30000,
        N'/images/Cơm_rang_thập_cẩm.jpg',
        1,
        1
    ),
    (N'Coca', 15000, N'/images/Coca.jpg', 60, 2),
    (N'Pepsi', 15000, N'/images/Pepsi.jpg', 45, 2),
    (N'7up', 15000, N'/images/7up.jpg', 20, 2),
    (
        N'Nước suối',
        10000,
        N'/images/Nước_suối.jpg',
        33,
        2
    ),
    (N'Sting', 15000, N'/images/Sting.jpg', 57, 2),
    (N'Redbull', 20000, N'/images/Redbull.jpg', 44, 2),
    (
        N'Thẻ garena 100k',
        100000,
        N'/images/Thẻ_garena_100k.jpg',
        41,
        3
    ),
    (
        N'Thẻ garena 200k',
        200000,
        N'/images/Thẻ_garena_200k.jpg',
        53,
        3
    ),
    (
        N'Thẻ viettel 100k',
        100000,
        N'/images/Thẻ_viettel_100k.jpg',
        20,
        3
    ),
    (
        N'Thẻ mobi 50k',
        50000,
        N'/images/Thẻ_mobi_50k.jpg',
        50,
        3
    ),
    (N'Phở', 30000, N'/images/Phở.jpg', 20, 1),
    (N'Cà phê', 15000, N'/images/Cà_phê.jpg', 14, 2),
    (
        N'Bánh mì trứng',
        20000,
        N'/images/Bánh_mì_trứng.jpg',
        13,
        1
    ),
    (
        N'Bánh mì thịt',
        20000,
        N'/images/Bánh_mì_thịt.jpg',
        10,
        1
    );

-- Bảng Hóa Đơn
CREATE TABLE
    HoaDon (
        MaHD INT PRIMARY KEY IDENTITY (1, 1),
        NgayLap DATE NOT NULL,
        MaKH INT NOT NULL,
        MaNhanVien INT NULL,
        FOREIGN KEY (MaKH) REFERENCES KhachHang (MaKH),
        FOREIGN KEY (MaNhanVien) REFERENCES NhanVien (MaNhanVien)
    );

-- Bảng Chi Tiết Dịch Vụ (nhiều dòng cho mỗi hóa đơn)
CREATE TABLE
    ChiTietDichVu (
        MaCTDV INT PRIMARY KEY IDENTITY (1, 1),
        MaHD INT NOT NULL,
        MaDichVu INT NOT NULL,
        SoLuong INT NOT NULL,
        DonGia DECIMAL(10, 2) NOT NULL,
        ThanhTien DECIMAL(10, 2) NOT NULL,
        FOREIGN KEY (MaHD) REFERENCES HoaDon (MaHD),
        FOREIGN KEY (MaDichVu) REFERENCES DichVu (MaDichVu)
    );

-- Bảng Chi Tiết Nạp Tiền
CREATE TABLE
    ChiTietNap (
        MaChiTietNap INT PRIMARY KEY IDENTITY (1, 1),
        SoTienNap DECIMAL(10, 2) NOT NULL,
        MaHD INT NOT NULL,
        FOREIGN KEY (MaHD) REFERENCES HoaDon (MaHD)
    );

-- Bảng Thanh Toán
CREATE TABLE
    ThanhToan (
        MaThanhToan INT PRIMARY KEY IDENTITY (1, 1),
        SoTienTT DECIMAL(10, 2) NOT NULL,
        PhuongThucTT NVARCHAR (50) NOT NULL,
        MaHD INT NOT NULL,
        FOREIGN KEY (MaHD) REFERENCES HoaDon (MaHD)
    );