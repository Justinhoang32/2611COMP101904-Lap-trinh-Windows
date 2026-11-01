/* =====================================================================
   COMP1019 - Lap trinh tren Windows - Buoi 10
   File    : 01_CreateDatabase.sql
   Noi dung: Tao database EduManagerDB va 6 bang (KHOA, LOP, SINHVIEN,
             MONHOC, KETQUA, TAIKHOAN) cung khoa chinh, khoa ngoai, rang buoc
   SV      : Hoang Minh Nhat - MSSV 51.01.104.066 - Nhom 5
   Chay tren SQL Server Management Studio (SSMS).
   LUU Y   : Script se XOA database EduManagerDB cu (neu co) roi tao lai.
   ===================================================================== */

USE master;
GO

-- Xoa database cu (dong tat ca ket noi dang mo de DROP khong bi loi)
IF DB_ID(N'EduManagerDB') IS NOT NULL
BEGIN
    ALTER DATABASE EduManagerDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE EduManagerDB;
END
GO

CREATE DATABASE EduManagerDB;
GO

USE EduManagerDB;
GO

/* ---------------------------------------------------------------------
   1. KHOA: thong tin khoa
   --------------------------------------------------------------------- */
CREATE TABLE KHOA (
    MaKhoa    VARCHAR(20)   NOT NULL,
    TenKhoa   NVARCHAR(100) NOT NULL,
    DienThoai VARCHAR(15)   NULL,
    CONSTRAINT PK_KHOA PRIMARY KEY (MaKhoa)
);
GO

/* ---------------------------------------------------------------------
   2. LOP: moi lop thuoc mot khoa (FK -> KHOA)
   --------------------------------------------------------------------- */
CREATE TABLE LOP (
    MaLop   VARCHAR(20)   NOT NULL,
    TenLop  NVARCHAR(100) NOT NULL,
    MaKhoa  VARCHAR(20)   NOT NULL,
    CONSTRAINT PK_LOP PRIMARY KEY (MaLop),
    CONSTRAINT FK_LOP_KHOA
        FOREIGN KEY (MaKhoa) REFERENCES KHOA(MaKhoa)
);
GO

/* ---------------------------------------------------------------------
   3. SINHVIEN: moi sinh vien thuoc mot lop (FK -> LOP)
      - GioiTinh chi nhan 'Nam' hoac 'Nu'
   --------------------------------------------------------------------- */
CREATE TABLE SINHVIEN (
    MaSV     VARCHAR(20)   NOT NULL,
    HoTen    NVARCHAR(100) NOT NULL,
    NgaySinh DATE          NULL,
    GioiTinh NVARCHAR(10)  NOT NULL,
    MaLop    VARCHAR(20)   NOT NULL,
    CONSTRAINT PK_SINHVIEN PRIMARY KEY (MaSV),
    CONSTRAINT CK_SINHVIEN_GioiTinh
        CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    CONSTRAINT FK_SINHVIEN_LOP
        FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);
GO

/* ---------------------------------------------------------------------
   4. MONHOC: so tin chi phai lon hon 0
   --------------------------------------------------------------------- */
CREATE TABLE MONHOC (
    MaMH     VARCHAR(20)   NOT NULL,
    TenMH    NVARCHAR(100) NOT NULL,
    SoTinChi INT           NOT NULL,
    CONSTRAINT PK_MONHOC PRIMARY KEY (MaMH),
    CONSTRAINT CK_MONHOC_SoTinChi CHECK (SoTinChi > 0)
);
GO

/* ---------------------------------------------------------------------
   5. KETQUA: diem cua sinh vien theo mon
      - Khoa chinh ghep (MaSV, MaMH): mot sinh vien chi co mot diem cho mot mon
      - Diem nam trong khoang 0..10
      - FK -> SINHVIEN va MONHOC
   --------------------------------------------------------------------- */
CREATE TABLE KETQUA (
    MaSV  VARCHAR(20)  NOT NULL,
    MaMH  VARCHAR(20)  NOT NULL,
    Diem  DECIMAL(4,2) NOT NULL,
    CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMH),
    CONSTRAINT CK_KETQUA_Diem CHECK (Diem BETWEEN 0 AND 10),
    CONSTRAINT FK_KETQUA_SINHVIEN
        FOREIGN KEY (MaSV) REFERENCES SINHVIEN(MaSV),
    CONSTRAINT FK_KETQUA_MONHOC
        FOREIGN KEY (MaMH) REFERENCES MONHOC(MaMH)
);
GO

/* ---------------------------------------------------------------------
   6. TAIKHOAN: tai khoan dang nhap demo
      (Mat khau luu dang ban ro chi de demo bai lab; he thong that phai bam/hash)
   --------------------------------------------------------------------- */
CREATE TABLE TAIKHOAN (
    TenDangNhap VARCHAR(50)   NOT NULL,
    MatKhau     VARCHAR(100)  NOT NULL,
    HoTen       NVARCHAR(100) NOT NULL,
    VaiTro      VARCHAR(20)   NOT NULL CONSTRAINT DF_TAIKHOAN_VaiTro DEFAULT 'User',
    TrangThai   BIT           NOT NULL CONSTRAINT DF_TAIKHOAN_TrangThai DEFAULT 1,
    CONSTRAINT PK_TAIKHOAN PRIMARY KEY (TenDangNhap),
    CONSTRAINT CK_TAIKHOAN_VaiTro CHECK (VaiTro IN ('Admin', 'User'))
);
GO

-- Kiem tra nhanh: phai co du 6 bang
SELECT TABLE_NAME AS DanhSachBang
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;
GO
