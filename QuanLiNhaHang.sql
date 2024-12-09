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
    GHI_CHU NVARCHAR(255)
);
-- 5. Tạo bảng DAT_BAN
CREATE TABLE DAT_BAN (
    MA_DAT_BAN INT PRIMARY KEY IDENTITY(1,1),
    TEN_KH NVARCHAR(20) NOT NULL,
    MA_BAN INT NOT NULL,
    NGAY_DAT DATETIME NOT NULL,
    TRANG_THAI NVARCHAR(50) NOT NULL,
);
select * from DAT_BAN
-- 6. Tạo bảng HOA_DON
CREATE TABLE HOA_DON (
    MaHoaDon INT PRIMARY KEY IDENTITY(1,1), -- Mã hóa đơn tự tăng
    NgayLap DATE NOT NULL,                  -- Ngày lập hóa đơn
    ThoiGian DATETIME NOT NULL,             -- Thời gian lập hóa đơn
    SoBan INT NOT NULL,                     -- Số bàn
    TongTien DECIMAL(18,2) NOT NULL,        -- Tổng tiền của hóa đơn
    TrangThai NVARCHAR(50) NOT NULL,        -- Trạng thái (VD: "Phục vụ ngay", "Đã thanh toán")
    GhiChu NVARCHAR(MAX)                    -- Ghi chú gửi đến bếp
);
-- 7. Tạo bảng CHI_TIET_HOA_DON
CREATE TABLE CHI_TIET_HOA_DON (
    MaChiTiet INT PRIMARY KEY IDENTITY(1,1), -- Mã chi tiết hóa đơn tự tăng
    MaHoaDon INT NOT NULL,                   -- Mã hóa đơn (khóa ngoại)
    TenMon NVARCHAR(100) NOT NULL,           -- Tên món ăn
    SoLuong INT NOT NULL,                    -- Số lượng món ăn
    Gia DECIMAL(18,2) NOT NULL,              -- Giá mỗi món
    ThanhTien AS (SoLuong * Gia),            -- Thành tiền (tính tự động)
    FOREIGN KEY (MaHoaDon) REFERENCES HOA_DON(MaHoaDon) ON DELETE CASCADE
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
-- update món ăn
CREATE PROC sp_SuaMon
    @mamon INT,
    @tenmon NVARCHAR(100),
    @danhmuc NVARCHAR(50),
    @gia DECIMAL(10,2)
AS
BEGIN
    UPDATE MON_AN
    SET TEN_MON = @tenmon,
        DANH_MUC = @danhmuc,
        GIA = @gia
    WHERE MA_MON = @mamon;
END

select * from MON_AN
drop proc sp_SuaMon

-- Lấy danh sách bàn
create proc sp_LayBan
as 
	select * from BAN

-- Lấy danh sách bàn với chuỗi "Bàn - Trạng Thái"
CREATE PROCEDURE sp_LayDanhSachBan
AS
BEGIN
    SELECT 
        MA_BAN,
        CONCAT(CAST(SO_BAN AS NVARCHAR), ' - ', TRANG_THAI) AS DanhSachBan
    FROM BAN;
END;

drop proc sp_LayDanhSachBan

EXEC sp_LayDSMon;
-- Tìm kiếm món theo tên món và mã món
CREATE PROCEDURE sp_TimKiemMonAn
    @Keyword NVARCHAR(100)
AS
BEGIN
    -- Tìm kiếm trong bảng MonAn
    SELECT * FROM MON_AN
    WHERE 
        MA_MON LIKE '%' + @Keyword + '%'  -- Tìm kiếm theo mã món
        OR TEN_MON LIKE '%' + @Keyword + '%' -- Tìm kiếm theo tên món
    ORDER BY 
        TEN_MON; -- Sắp xếp kết quả theo tên món
END;

------------------ Lưu hóa đơn
-- Tạo Stored Procedure lưu hóa đơn và chi tiết hóa đơn
--- Kiểm tra trạng thái bàn
CREATE PROC sp_KiemTraTrangThaiBan
    @maBan INT
AS
    SELECT TRANG_THAI
    FROM BAN
    WHERE MA_BAN = @maBan;
-----------------------
drop proc sp_LaySoBan
------- Lấy số bàn từ mã bàn
create proc sp_LaySoBan(@maban int)
as
	select SO_BAN from BAN WHERE MA_BAN = @maban
-- Thêm hóa đơn

-- Thêm vào danh sách đặt bàn
CREATE PROC sp_ThemDatBan
    @TEN_KH NVARCHAR(20),
    @MA_BAN INT,
    @NGAY_DAT DATETIME,
    @TRANG_THAI NVARCHAR(50)
AS
    -- Thêm dữ liệu vào bảng DAT_BAN
    INSERT INTO DAT_BAN (TEN_KH, MA_BAN, NGAY_DAT, TRANG_THAI)
    VALUES (@TEN_KH, @MA_BAN, @NGAY_DAT, @TRANG_THAI);

drop proc sp_ThemDatBan



go
--Danh Sach Nhan Vien
create proc sp_DSNhanVien
as
select * from NHAN_VIEN
go
--Danh Sach Quyen
create proc sp_DSQuyen
as
SELECT DISTINCT PHAN_QUYEN FROM NHAN_VIEN
go
--Them Nhan Vien
create proc sp_ThemNhanVien(@tennv nvarchar(50),@taikhoan varchar(50),@matkhau varchar(50),@phanquyen nvarchar(50))
as
insert into NHAN_VIEN(TEN_NV,TAI_KHOAN,MAT_KHAU,PHAN_QUYEN)
values (@tennv,@taikhoan,@matkhau,@phanquyen)
go
--Xoa Nhan Vien
create proc sp_XoaNhanVien(@manhanvien int)
as
delete from NHAN_VIEN where MA_NV = @manhanvien
go
--Sua Nhan Vien
create proc sp_CapNhatNhanVien(@manhanvien int,@tennv nvarchar(50),@taikhoan varchar(50),@matkhau varchar(50),@phanquyen nvarchar(50))
as
update NHAN_VIEN
set TEN_NV = @tennv,
TAI_KHOAN = @taikhoan,
MAT_KHAU = @matkhau,
PHAN_QUYEN = @phanquyen
where MA_NV = @manhanvien
go
--Tim Nhan Vien
create proc sp_TimNhanVien(@tennv nvarchar(50))
as
select nv.MA_NV , nv.TEN_NV, nv.TAI_KHOAN,nv.TAI_KHOAN,nv.MAT_KHAU,nv.PHAN_QUYEN
from NHAN_VIEN nv
where nv.TEN_NV = @tennv or (TRY_CAST(@tennv AS INT) IS NOT NULL AND nv.MA_NV = TRY_CAST(@tennv AS INT))

go
--Danh Sach Ban
create proc sp_DanhSachBan
as
SELECT * FROM BAN
go
--Danh Sach Trang Thai
create proc sp_DSTrangThai
as
SELECT DISTINCT TRANG_THAI FROM BAN
GO
--Them Ban
create proc sp_ThemBan(@soban int,@trangthai nvarchar(50))
as
Insert into BAN(SO_BAN,TRANG_THAI)
values (@soban,@trangthai)
go
--Xoa Ban
create proc sp_XoaBan(@maban int)
as
delete from BAN where MA_BAN = @maban
go
--Sua Ban
create proc sp_SuaBan(@maban int, @soban int, @trangthai nvarchar(50))
as
update BAN
set SO_BAN = @soban,
TRANG_THAI = @trangthai
where MA_BAN = @maban
go
--Tim Ban
create proc sp_TimBan(@tk int)
as
select b.MA_BAN,b.SO_BAN,b.TRANG_THAI
from BAN b
where b.SO_BAN = @tk

