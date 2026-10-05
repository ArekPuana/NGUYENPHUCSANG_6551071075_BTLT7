CREATE DATABASE AnKhangClinic;
GO

USE AnKhangClinic;
GO

CREATE TABLE BacSi
(
    MaBS INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    ChuyenKhoa NVARCHAR(100),
    SDT VARCHAR(15)
);
GO

CREATE TABLE LichKham
(
    MaLich INT IDENTITY(1,1) PRIMARY KEY,
    TenBenhNhan NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15),
    NgayKham DATE,
    GioKham TIME,
    MaBS INT NOT NULL,
    TrangThai NVARCHAR(20),

    CONSTRAINT FK_LichKham_BacSi
        FOREIGN KEY (MaBS)
        REFERENCES BacSi(MaBS)
);
GO
INSERT INTO BacSi(HoTen, ChuyenKhoa, SDT)
VALUES
(N'Nguyễn Văn A', N'Nội tổng quát', '0901111111'),
(N'Nguyễn Văn B', N'Nội khoa', '0902222222'),
(N'Nguyễn Văn C', N'Chuyên khoa', '0903333333');

INSERT INTO LichKham
(TenBenhNhan, SDT, NgayKham, GioKham, MaBS, TrangThai)
VALUES
(N'Nguyễn Văn X', '0972566789', '2026-10-10', '09:00', 1, N'Chờ khám'),
(N'Nguyễn Hàm', '0972566789', '2026-10-15', '16:00', 1, N'Đã hủy'),
(N'Nguyễn Thịnh', '0972566789', '2026-10-20', '13:00', 2, N'Đã khám');
GO