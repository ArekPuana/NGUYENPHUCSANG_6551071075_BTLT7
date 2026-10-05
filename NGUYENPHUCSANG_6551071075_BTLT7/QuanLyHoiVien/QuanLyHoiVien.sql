CREATE DATABASE FitZone;
GO

USE FitZone;
GO

CREATE TABLE HoiVien
(
    MaHV INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh BIT NOT NULL,
    NgaySinh DATE NOT NULL,
    SDT VARCHAR(15) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    HangThanhVien NVARCHAR(20) NOT NULL,
    NgayDangKy DATETIME NOT NULL DEFAULT GETDATE(),
    TrangThai BIT NOT NULL DEFAULT 1
);
GO

INSERT INTO HoiVien
(
    HoTen,
    GioiTinh,
    NgaySinh,
    SDT,
    Email,
    HangThanhVien,
    TrangThai
)
VALUES
(
    N'Nguyễn Văn An',
    1,
    '2000-05-10',
    '0912345678',
    'an@gmail.com',
    N'Basic',
    1
),
(
    N'Trần Thị Bình',
    0,
    '1998-08-20',
    '0987654321',
    'binh@gmail.com',
    N'VIP',
    1
),
(
    N'Lê Minh Hoàng',
    1,
    '2003-12-15',
    '0901234567',
    'hoang@gmail.com',
    N'Premium',
    0
);
GO