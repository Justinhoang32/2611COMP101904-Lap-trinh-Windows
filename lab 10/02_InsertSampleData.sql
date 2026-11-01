/* =====================================================================
   COMP1019 - Lap trinh tren Windows - Buoi 10
   File    : 02_InsertSampleData.sql
   Noi dung: Nhap du lieu mau cho EduManagerDB
             (2 khoa, 4 lop, 8 sinh vien, 4 mon hoc, 8 ket qua, 2 tai khoan)
   SV      : Hoang Minh Nhat - MSSV 51.01.104.066 - Nhom 5
   Chay SAU khi da chay 01_CreateDatabase.sql.
   THU TU NHAP (theo quan he khoa ngoai):
       KHOA -> LOP -> SINHVIEN -> MONHOC -> KETQUA -> TAIKHOAN
   ===================================================================== */

USE EduManagerDB;
GO

-- 1. KHOA (2 dong)
INSERT INTO KHOA (MaKhoa, TenKhoa, DienThoai) VALUES
('FIT',  N'Khoa Công nghệ Thông tin', '0281234567'),
('MATH', N'Khoa Toán - Tin học',      '0287654321');
GO

-- 2. LOP (4 dong)
INSERT INTO LOP (MaLop, TenLop, MaKhoa) VALUES
('CNTT01',  N'Công nghệ thông tin 01', 'FIT'),
('CNTT02',  N'Công nghệ thông tin 02', 'FIT'),
('SPTIN01', N'Sư phạm Tin học 01',     'MATH'),
('SPTIN02', N'Sư phạm Tin học 02',     'MATH');
GO

-- 3. SINHVIEN (8 dong)
--    SV007, SV008 chua co diem de phuc vu cau DELETE / LEFT JOIN
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop) VALUES
('SV001', N'Nguyễn Văn An',    '2005-02-10', N'Nam', 'CNTT01'),
('SV002', N'Trần Thị Bình',    '2005-08-21', N'Nữ',  'CNTT01'),
('SV003', N'Lê Minh Chi',      '2004-12-02', N'Nữ',  'CNTT02'),
('SV004', N'Phạm Quốc Dũng',   '2005-04-16', N'Nam', 'CNTT02'),
('SV005', N'Hoàng Gia Hân',    '2005-10-30', N'Nữ',  'SPTIN01'),
('SV006', N'Võ Thành Khang',   '2004-09-09', N'Nam', 'SPTIN01'),
('SV007', N'Đặng Thị Lan',     '2005-06-18', N'Nữ',  'SPTIN02'),
('SV008', N'Bùi Văn Minh',     '2005-01-25', N'Nam', 'CNTT01');
GO

-- 4. MONHOC (4 dong)
INSERT INTO MONHOC (MaMH, TenMH, SoTinChi) VALUES
('COMP1019', N'Lập trình trên Windows',         3),
('COMP1017', N'Lập trình cơ bản',               3),
('COMP1020', N'Cơ sở dữ liệu',                  3),
('COMP1044', N'Nhập môn Công nghệ phần mềm',    3);
GO

-- 5. KETQUA (8 dong)
INSERT INTO KETQUA (MaSV, MaMH, Diem) VALUES
('SV001', 'COMP1019', 8.5),
('SV001', 'COMP1020', 7.5),
('SV002', 'COMP1019', 9.0),
('SV002', 'COMP1020', 8.0),
('SV003', 'COMP1019', 6.5),
('SV004', 'COMP1019', 7.0),
('SV005', 'COMP1017', 8.0),
('SV006', 'COMP1044', 7.8);
GO

-- 6. TAIKHOAN (2 dong)
INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, HoTen, VaiTro) VALUES
('admin', '123456', N'Quản trị viên',   'Admin'),
('gv01',  '123456', N'Giảng viên demo', 'User');
GO

-- Kiem tra so dong moi bang
SELECT 'KHOA'      AS Bang, COUNT(*) AS SoDong FROM KHOA
UNION ALL SELECT 'LOP',       COUNT(*) FROM LOP
UNION ALL SELECT 'SINHVIEN',  COUNT(*) FROM SINHVIEN
UNION ALL SELECT 'MONHOC',    COUNT(*) FROM MONHOC
UNION ALL SELECT 'KETQUA',    COUNT(*) FROM KETQUA
UNION ALL SELECT 'TAIKHOAN',  COUNT(*) FROM TAIKHOAN;
GO
