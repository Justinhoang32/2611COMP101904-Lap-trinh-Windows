/* =====================================================================
   COMP1019 - Lap trinh tren Windows - Lab 12
   File    : QLSinhVienLab12.sql
   Noi dung: Tao database QLSinhVienLab12, 4 bang, du lieu mau
             va 4 stored procedure cho module Quan ly ket qua hoc tap
   SV      : Hoang Minh Nhat - MSSV 51.01.104.066 - Nhom 5
   Chay tren SQL Server Management Studio (SSMS).
   LUU Y   : Script se XOA database QLSinhVienLab12 cu (neu co) roi tao lai.
   ===================================================================== */

USE master;
GO

-- Xoa database cu (dong cac ket noi dang mo de DROP khong bi loi)
IF DB_ID(N'QLSinhVienLab12') IS NOT NULL
BEGIN
    ALTER DATABASE QLSinhVienLab12 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLSinhVienLab12;
END
GO

CREATE DATABASE QLSinhVienLab12;
GO

USE QLSinhVienLab12;
GO

/* ===================== 1. TAO BANG ===================== */

CREATE TABLE LOP (
    MaLop  NVARCHAR(20)  NOT NULL,
    TenLop NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_LOP PRIMARY KEY (MaLop)
);
GO

CREATE TABLE SINHVIEN (
    MaSV     NVARCHAR(20)  NOT NULL,
    HoTen    NVARCHAR(100) NOT NULL,
    NgaySinh DATE          NULL,
    MaLop    NVARCHAR(20)  NOT NULL,
    CONSTRAINT PK_SINHVIEN PRIMARY KEY (MaSV),
    CONSTRAINT FK_SINHVIEN_LOP FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);
GO

CREATE TABLE MONHOC (
    MaMon    NVARCHAR(20)  NOT NULL,
    TenMon   NVARCHAR(100) NOT NULL,
    SoTinChi INT           NOT NULL,
    CONSTRAINT PK_MONHOC PRIMARY KEY (MaMon),
    CONSTRAINT CK_MONHOC_SoTinChi CHECK (SoTinChi > 0)
);
GO

-- KETQUA: khoa chinh ghep (MaSV, MaMon) => moi sinh vien chi co 1 diem cho 1 mon
CREATE TABLE KETQUA (
    MaSV   NVARCHAR(20)  NOT NULL,
    MaMon  NVARCHAR(20)  NOT NULL,
    Diem   DECIMAL(4,2)  NOT NULL,
    GhiChu NVARCHAR(255) NULL,
    CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMon),
    CONSTRAINT CK_KETQUA_Diem CHECK (Diem >= 0 AND Diem <= 10),
    CONSTRAINT FK_KETQUA_SINHVIEN FOREIGN KEY (MaSV)  REFERENCES SINHVIEN(MaSV),
    CONSTRAINT FK_KETQUA_MONHOC   FOREIGN KEY (MaMon) REFERENCES MONHOC(MaMon)
);
GO

/* ===================== 2. DU LIEU MAU ===================== */

INSERT INTO LOP (MaLop, TenLop) VALUES
(N'CTK47A', N'Công nghệ thông tin K47A'),
(N'CTK47B', N'Công nghệ thông tin K47B');
GO

INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, MaLop) VALUES
(N'SV001', N'Nguyễn Văn An',     '2005-01-15', N'CTK47A'),
(N'SV002', N'Trần Thị Bình',     '2005-05-20', N'CTK47A'),
(N'SV003', N'Lê Minh Cường',     '2005-03-11', N'CTK47A'),
(N'SV004', N'Phạm Thanh Dung',   '2005-07-09', N'CTK47A'),
(N'SV005', N'Hoàng Gia Hân',     '2005-10-30', N'CTK47A'),
(N'SV006', N'Võ Thành Khang',    '2005-09-09', N'CTK47B'),
(N'SV007', N'Đặng Thị Lan',      '2005-06-18', N'CTK47B'),
(N'SV008', N'Bùi Văn Minh',      '2005-01-25', N'CTK47B');
GO

INSERT INTO MONHOC (MaMon, TenMon, SoTinChi) VALUES
(N'COMP1019', N'Lập trình trên Windows', 3),
(N'COMP1017', N'Cơ sở lập trình',        3),
(N'COMP1020', N'Cơ sở dữ liệu',          3);
GO

-- Mot so diem co san de thay ro "kem diem neu da co" khi tai danh sach
INSERT INTO KETQUA (MaSV, MaMon, Diem, GhiChu) VALUES
(N'SV001', N'COMP1019', 8.50, N'Làm bài tốt'),
(N'SV002', N'COMP1019', 9.00, N''),
(N'SV006', N'COMP1017', 7.00, N'');
GO

/* ===================== 3. STORED PROCEDURE ===================== */

-- 3.1 Lay danh sach lop
CREATE OR ALTER PROCEDURE sp_Lop_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaLop, TenLop
    FROM LOP
    ORDER BY TenLop;
END;
GO

-- 3.2 Lay danh sach mon hoc
CREATE OR ALTER PROCEDURE sp_MonHoc_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaMon, TenMon, SoTinChi
    FROM MONHOC
    ORDER BY TenMon;
END;
GO

-- 3.3 Lay sinh vien theo lop va mon hoc, kem diem neu da co
--     LEFT JOIN: sinh vien chua co diem van hien, cot Diem la NULL (de trong)
CREATE OR ALTER PROCEDURE sp_KetQua_GetByLopMon
    @MaLop NVARCHAR(20),
    @MaMon NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT sv.MaSV,
           sv.HoTen,
           kq.Diem,
           ISNULL(kq.GhiChu, N'') AS GhiChu
    FROM SINHVIEN sv
    LEFT JOIN KETQUA kq
           ON kq.MaSV = sv.MaSV AND kq.MaMon = @MaMon
    WHERE sv.MaLop = @MaLop
    ORDER BY sv.MaSV;
END;
GO

-- 3.4 Luu diem (upsert): da co thi UPDATE, chua co thi INSERT
CREATE OR ALTER PROCEDURE sp_KetQua_Save
    @MaSV   NVARCHAR(20),
    @MaMon  NVARCHAR(20),
    @Diem   DECIMAL(4,2),
    @GhiChu NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    IF @Diem IS NULL OR @Diem < 0 OR @Diem > 10
        THROW 50001, N'Điểm phải nằm trong khoảng từ 0 đến 10.', 1;

    UPDATE KETQUA
    SET Diem = @Diem, GhiChu = @GhiChu
    WHERE MaSV = @MaSV AND MaMon = @MaMon;

    IF @@ROWCOUNT = 0
        INSERT INTO KETQUA (MaSV, MaMon, Diem, GhiChu)
        VALUES (@MaSV, @MaMon, @Diem, @GhiChu);
END;
GO

/* ===================== 4. KIEM TRA NHANH ===================== */
-- EXEC sp_Lop_GetAll;
-- EXEC sp_MonHoc_GetAll;
-- EXEC sp_KetQua_GetByLopMon @MaLop = N'CTK47A', @MaMon = N'COMP1019';
-- EXEC sp_KetQua_Save @MaSV = N'SV003', @MaMon = N'COMP1019', @Diem = 7.5, @GhiChu = N'Test';
-- SELECT * FROM KETQUA;
GO
