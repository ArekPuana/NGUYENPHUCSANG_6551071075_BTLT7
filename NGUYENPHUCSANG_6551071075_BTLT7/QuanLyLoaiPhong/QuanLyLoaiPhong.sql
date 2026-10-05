CREATE DATABASE SunriseHomestay;
GO

USE SunriseHomestay;
GO

CREATE TABLE LoaiPhong
(
    MaLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL,
    GiaMoiDem DECIMAL(18,2) NOT NULL,
    MoTa NVARCHAR(255)
);
GO

CREATE TABLE Phong
(
    MaPhong INT IDENTITY(1,1) PRIMARY KEY,
    SoPhong VARCHAR(10) NOT NULL,
    TangSo INT NOT NULL,
    TinhTrang NVARCHAR(20) NOT NULL,
    HinhAnh NVARCHAR(255),
    MaLoai INT NOT NULL,

    CONSTRAINT FK_Phong_LoaiPhong
        FOREIGN KEY (MaLoai)
        REFERENCES LoaiPhong(MaLoai)
);
GO

INSERT INTO LoaiPhong
    (TenLoai, GiaMoiDem, MoTa)
VALUES
    (N'Phòng Đơn', 35000, N'Phòng dành cho một người'),
    (N'Phòng Đôi', 20000, N'Phòng dành cho hai người'),
    (N'Phòng VIP', 30000, N'Phòng cao cấp');
GO

INSERT INTO Phong
    (SoPhong, TangSo, TinhTrang, HinhAnh, MaLoai)
VALUES
    ('101', 1, N'Trống', NULL, 1),
    ('102', 1, N'Đang ở', NULL, 2),
    ('201', 2, N'Đang dọn', NULL, 1),
    ('202', 2, N'Đang dọn', NULL, 2),
    ('301', 3, N'Trống', NULL, 3);
GO