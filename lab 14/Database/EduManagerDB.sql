-- =============================================
-- Script tạo database và bảng cho bài Lab 14
-- =============================================
IF DB_ID(N'EduManagerDB') IS NULL
    CREATE DATABASE EduManagerDB;
GO

USE EduManagerDB;
GO

IF OBJECT_ID(N'dbo.MONHOC', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.MONHOC
    (
        MaMonHoc  NVARCHAR(10)  NOT NULL CONSTRAINT PK_MONHOC PRIMARY KEY,
        TenMonHoc NVARCHAR(100) NOT NULL,
        SoTinChi  INT           NOT NULL CONSTRAINT CK_MONHOC_SoTinChi CHECK (SoTinChi BETWEEN 1 AND 6),
        TrangThai BIT           NOT NULL CONSTRAINT DF_MONHOC_TrangThai DEFAULT 1
    );
END
GO

-- Dữ liệu mẫu
IF NOT EXISTS (SELECT 1 FROM dbo.MONHOC)
BEGIN
    INSERT INTO dbo.MONHOC (MaMonHoc, TenMonHoc, SoTinChi, TrangThai) VALUES
    (N'COMP1019', N'Lập trình trên Windows', 3, 1),
    (N'COMP1010', N'Cơ sở dữ liệu', 3, 1),
    (N'COMP1020', N'Lập trình hướng đối tượng', 4, 1),
    (N'COMP1030', N'Cấu trúc dữ liệu và giải thuật', 4, 1),
    (N'COMP9999', N'Môn học cũ (ngưng sử dụng)', 2, 0);
END
GO
