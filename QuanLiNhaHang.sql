-- 1. Tạo cơ sở dữ liệu
CREATE DATABASE QuanLyNhaHang;
GO
USE QuanLyNhaHang;
GO

-- 2. Tạo bảng MON_AN
CREATE TABLE MON_AN (
    MA_MON INT PRIMARY KEY IDENTITY(1,1),
    TEN_MON NVARCHAR(100) NOT NULL,
    DANH_MUC NVARCHAR(50) NOT NULL,
    GIA DECIMAL(10, 2) NOT NULL,
    TRANG_THAI NVARCHAR(10) NOT NULL
);
ALTER TABLE MON_AN
ALTER COLUMN TRANG_THAI NVARCHAR(10);

-- 3. Tạo bảng BAN
CREATE TABLE BAN (
    MA_BAN INT PRIMARY KEY IDENTITY(1,1),
    SO_BAN INT NOT NULL,
    TRANG_THAI NVARCHAR(50) NOT NULL
);

-- 4. Tạo bảng KHACH_HANG
CREATE TABLE KHACH_HANG (
    MA_KH INT PRIMARY KEY IDENTITY(1,1),
    TEN_KH NVARCHAR(100) NOT NULL,
    SDT NVARCHAR(20) NOT NULL,
    EMAIL NVARCHAR(100),
    GHI_CHU NVARCHAR(255)
);

-- 5. Tạo bảng DAT_BAN
CREATE TABLE DAT_BAN (
    MA_DAT_BAN INT PRIMARY KEY IDENTITY(1,1),
    MA_KH INT NOT NULL,
    MA_BAN INT NOT NULL,
    NGAY_DAT DATETIME NOT NULL,
    TRANG_THAI NVARCHAR(50) NOT NULL,
    FOREIGN KEY (MA_KH) REFERENCES KHACH_HANG(MA_KH),
    FOREIGN KEY (MA_BAN) REFERENCES BAN(MA_BAN)
);

-- 6. Tạo bảng HOA_DON
CREATE TABLE HOA_DON (
    MA_HD INT PRIMARY KEY IDENTITY(1,1),
    MA_BAN INT NOT NULL,
    NGAY_LAP DATETIME NOT NULL,
    TONG_TIEN DECIMAL(10, 2) NOT NULL,
    TRANG_THAI NVARCHAR(50) NOT NULL,
    FOREIGN KEY (MA_BAN) REFERENCES BAN(MA_BAN)
);

-- 7. Tạo bảng CHI_TIET_HOA_DON
CREATE TABLE CHI_TIET_HOA_DON (
    MA_HD INT NOT NULL,
    MA_MON INT NOT NULL,
    SO_LUONG INT NOT NULL,
    THANH_TIEN DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (MA_HD, MA_MON),
    FOREIGN KEY (MA_HD) REFERENCES HOA_DON(MA_HD),
    FOREIGN KEY (MA_MON) REFERENCES MON_AN(MA_MON)
);

-- 8. Tạo bảng NHAN_VIEN
CREATE TABLE NHAN_VIEN (
    MA_NV INT PRIMARY KEY IDENTITY(1,1),
    TEN_NV NVARCHAR(100) NOT NULL,
    TAI_KHOAN NVARCHAR(50) NOT NULL UNIQUE,
    MAT_KHAU NVARCHAR(255) NOT NULL,
    PHAN_QUYEN NVARCHAR(50) NOT NULL
);

-- 9. Thêm dữ liệu mẫu vào bảng MON_AN
INSERT INTO MON_AN (TEN_MON, DANH_MUC, GIA, TRANG_THAI) VALUES
(N'Phở bò', N'Món chính', 50000, N'Còn món'),
(N'Gỏi cuốn', N'Khai vị', 30000, N'Còn món'),
(N'Trà đá', N'Đồ uống', 5000, N'Còn món'),
(N'Bánh xèo', N'Món chính', 40000, N'Còn món'),
(N'Cà phê sữa', N'Đồ uống', 20000, N'Còn món'),
(N'Chè bưởi', N'Tráng miệng', 25000, N'Đã hết'),
(N'Bún chả', N'Món chính', 45000, N'Còn món'),
(N'Nem rán', N'Khai vị', 35000, N'Còn món');

DELETE FROM MON_AN
WHERE TRANG_THAI = 1;
-- Trạng thái
-- 10. Thêm dữ liệu mẫu vào bảng BAN
INSERT INTO BAN (SO_BAN, TRANG_THAI) VALUES
(1, N'Trống'),
(2, N'Đang phục vụ'),
(3, N'Đặt trước'),
(4, N'Trống'),
(5, N'Đang phục vụ');

-- 11. Thêm dữ liệu mẫu vào bảng KHACH_HANG
INSERT INTO KHACH_HANG (TEN_KH, SDT, EMAIL, GHI_CHU) VALUES
(N'Nguyen Van A', '0909123456', 'a.nguyen@gmail.com', N'Khách VIP'),
(N'Tran Thi B', '0912345678', 'b.tran@gmail.com', NULL),
(N'Le Van C', '0987654321', 'c.le@gmail.com', N'Khách thân quen'),
(N'Pham Thi D', '0922334455', NULL, N'Đặt bàn thường xuyên');

-- 12. Thêm dữ liệu mẫu vào bảng NHAN_VIEN
INSERT INTO NHAN_VIEN (TEN_NV, TAI_KHOAN, MAT_KHAU, PHAN_QUYEN) VALUES
('Admin', 'admin', 'admin@123', 'admin'),
('Nhan vien A', 'nva', 'password123', 'nhanvien'),
('Nhan vien B', 'nvb', 'password456', 'nhanvien'),
('Quan ly', 'ql', 'ql@789', 'quanly');
go
-- Create proc 
create proc sp_LayDSMon
as
select * from MON_AN
go
-- them mon an
create proc sp_ThemMon(@tenmon nvarchar(100),@danhmuc nvarchar(50),@gia decimal(10,2),@trangthai nvarchar(10))
as
insert into MON_AN(TEN_MON,DANH_MUC,GIA,TRANG_THAI)
values (@tenmon,@danhmuc,@gia,@trangthai)
-- Xóa món ăn
go
create proc sp_XoaMonAn(@maMon int)
as
	delete from MON_AN where MA_MON = @maMon