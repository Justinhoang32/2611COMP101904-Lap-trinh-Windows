/* =====================================================================
   COMP1019 - Lap trinh tren Windows - Buoi 10
   File    : 03_Queries.sql
   Noi dung: 12 truy van bat buoc + cac test rang buoc bo sung
   SV      : Hoang Minh Nhat - MSSV 51.01.104.066 - Nhom 5
   Chay SAU 01_CreateDatabase.sql va 02_InsertSampleData.sql.
   LUU Y   : Cau 5 (UPDATE) va cau 6 (DELETE) thay doi du lieu.
             Muon chay lai tu dau: chay lai file 01 roi file 02.
   ===================================================================== */

USE EduManagerDB;
GO

/* =====================  PHAN A: TRUY VAN CO BAN  ===================== */

-- Cau 1. Liet ke toan bo sinh vien
SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaLop
FROM SINHVIEN;
GO

-- Cau 2. Liet ke sinh vien kem ten lop va ten khoa (JOIN 3 bang)
SELECT sv.MaSV, sv.HoTen, l.TenLop, k.TenKhoa
FROM SINHVIEN sv
INNER JOIN LOP  l ON sv.MaLop  = l.MaLop
INNER JOIN KHOA k ON l.MaKhoa  = k.MaKhoa
ORDER BY sv.MaSV;
GO

-- Cau 3. Tim sinh vien theo mot phan ho ten (LIKE)
SELECT MaSV, HoTen, MaLop
FROM SINHVIEN
WHERE HoTen LIKE N'%Thị%'
ORDER BY HoTen ASC;
GO

-- Cau 4. Liet ke sinh vien theo ma lop
SELECT MaSV, HoTen, GioiTinh
FROM SINHVIEN
WHERE MaLop = 'CNTT01';
GO

/* =====================  PHAN B: UPDATE / DELETE  ===================== */

-- Cau 5. Cap nhat ho ten (va co the ca lop) cua mot sinh vien
-- Truoc khi cap nhat
SELECT MaSV, HoTen, MaLop FROM SINHVIEN WHERE MaSV = 'SV001';

UPDATE SINHVIEN
SET HoTen = N'Nguyễn Văn An (đã sửa)'
WHERE MaSV = 'SV001';            -- luon kiem tra WHERE truoc khi chay UPDATE

-- Sau khi cap nhat
SELECT MaSV, HoTen, MaLop FROM SINHVIEN WHERE MaSV = 'SV001';
GO

-- Cau 6. Xoa mot sinh vien CHUA co du lieu diem
-- 6a. SV008 chua co diem -> duoc xoa (1 dong bi anh huong)
DELETE FROM SINHVIEN
WHERE MaSV = 'SV008'
  AND NOT EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = 'SV008');
SELECT @@ROWCOUNT AS SoDongDaXoa_SV008;

-- 6b. SV001 da co diem -> dieu kien NOT EXISTS sai -> khong xoa (0 dong)
DELETE FROM SINHVIEN
WHERE MaSV = 'SV001'
  AND NOT EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = 'SV001');
SELECT @@ROWCOUNT AS SoDongDaXoa_SV001;

-- Danh sach sinh vien sau khi xoa
SELECT MaSV, HoTen, MaLop FROM SINHVIEN ORDER BY MaSV;
GO

/* =====================  PHAN C: JOIN VA THONG KE  ===================== */

-- Cau 7. Liet ke diem cua tung sinh vien theo tung mon
SELECT sv.MaSV, sv.HoTen, mh.TenMH, kq.Diem
FROM KETQUA kq
INNER JOIN SINHVIEN sv ON kq.MaSV = sv.MaSV
INNER JOIN MONHOC   mh ON kq.MaMH = mh.MaMH
ORDER BY sv.MaSV, mh.TenMH;
GO

-- Cau 8. Tinh diem trung binh cua tung sinh vien
SELECT sv.MaSV, sv.HoTen, ROUND(AVG(kq.Diem), 2) AS DiemTrungBinh
FROM SINHVIEN sv
INNER JOIN KETQUA kq ON sv.MaSV = kq.MaSV
GROUP BY sv.MaSV, sv.HoTen
ORDER BY sv.MaSV;
GO

-- Cau 9. Thong ke so sinh vien theo tung lop
-- (LEFT JOIN de lop chua co sinh vien van hien so luong 0)
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
ORDER BY l.MaLop;
GO

-- Cau 10. Cac lop co tu 2 sinh vien tro len (HAVING loc sau khi gom nhom)
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
HAVING COUNT(sv.MaSV) >= 2
ORDER BY l.MaLop;
GO

/* =====================  PHAN D: TEST RANG BUOC  =====================
   Moi test dung TRY...CATCH de script chay tron ven.
   KET QUA DUNG: cot KetQuaTest hien "DA CHAN DUNG" kem ma loi va thong bao loi.
   Neu hien "KHONG CO LOI" nghia la rang buoc chua hoat dong.
   Muon xem loi do SSMS bao that (tab Messages), chay rieng cau INSERT. */

-- Cau 11. Them sinh vien vao lop khong ton tai (loi khoa ngoai FK_SINHVIEN_LOP)
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV999', N'Sinh viên lỗi', '2005-01-01', N'Nam', 'CNTT99');
    SELECT N'KHÔNG CÓ LỖI - rang buoc chua hoat dong!' AS KetQuaTest;
END TRY
BEGIN CATCH
    SELECT N'Cau 11 - ĐÃ CHẶN ĐÚNG (lop khong ton tai)' AS KetQuaTest,
           ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS ThongBaoLoi;
END CATCH;
GO

-- Cau 12. Nhap diem ngoai khoang 0..10 (loi CK_KETQUA_Diem)
BEGIN TRY
    INSERT INTO KETQUA (MaSV, MaMH, Diem) VALUES ('SV001', 'COMP1017', 12);
    SELECT N'KHÔNG CÓ LỖI - rang buoc chua hoat dong!' AS KetQuaTest;
END TRY
BEGIN CATCH
    SELECT N'Cau 12a - ĐÃ CHẶN ĐÚNG (diem = 12)' AS KetQuaTest,
           ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS ThongBaoLoi;
END CATCH;
GO

BEGIN TRY
    INSERT INTO KETQUA (MaSV, MaMH, Diem) VALUES ('SV001', 'COMP1017', -1);
    SELECT N'KHÔNG CÓ LỖI - rang buoc chua hoat dong!' AS KetQuaTest;
END TRY
BEGIN CATCH
    SELECT N'Cau 12b - ĐÃ CHẶN ĐÚNG (diem = -1)' AS KetQuaTest,
           ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS ThongBaoLoi;
END CATCH;
GO

/* =====================  PHAN E: TEST BO SUNG  ===================== */

-- Test 13. Gioi tinh khong thuoc Nam/Nu (loi CK_SINHVIEN_GioiTinh)
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV998', N'Giới tính lỗi', '2005-01-01', N'Khác', 'CNTT01');
    SELECT N'KHÔNG CÓ LỖI - rang buoc chua hoat dong!' AS KetQuaTest;
END TRY
BEGIN CATCH
    SELECT N'Test 13 - ĐÃ CHẶN ĐÚNG (gioi tinh Khac)' AS KetQuaTest,
           ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS ThongBaoLoi;
END CATCH;
GO

-- Test 14. Trung khoa chinh (MaSV SV001 da ton tai)
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV001', N'Trùng mã', '2005-01-01', N'Nam', 'CNTT01');
    SELECT N'KHÔNG CÓ LỖI - rang buoc chua hoat dong!' AS KetQuaTest;
END TRY
BEGIN CATCH
    SELECT N'Test 14 - ĐÃ CHẶN ĐÚNG (trung khoa chinh)' AS KetQuaTest,
           ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS ThongBaoLoi;
END CATCH;
GO

-- Test 15. So tin chi <= 0 (loi CK_MONHOC_SoTinChi)
BEGIN TRY
    INSERT INTO MONHOC (MaMH, TenMH, SoTinChi) VALUES ('COMP9999', N'Môn lỗi', 0);
    SELECT N'KHÔNG CÓ LỖI - rang buoc chua hoat dong!' AS KetQuaTest;
END TRY
BEGIN CATCH
    SELECT N'Test 15 - ĐÃ CHẶN ĐÚNG (so tin chi = 0)' AS KetQuaTest,
           ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS ThongBaoLoi;
END CATCH;
GO

-- Test 16. Xoa sinh vien da co diem (khong xoa duoc vi FK_KETQUA_SINHVIEN)
BEGIN TRY
    DELETE FROM SINHVIEN WHERE MaSV = 'SV002';
    SELECT N'KHÔNG CÓ LỖI - rang buoc chua hoat dong!' AS KetQuaTest;
END TRY
BEGIN CATCH
    SELECT N'Test 16 - ĐÃ CHẶN ĐÚNG (sinh vien da co diem)' AS KetQuaTest,
           ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS ThongBaoLoi;
END CATCH;
GO

-- Truy van bo sung: diem trung binh cua TAT CA sinh vien
-- (sinh vien chua co diem hien NULL nho LEFT JOIN)
SELECT sv.MaSV, sv.HoTen, ROUND(AVG(kq.Diem), 2) AS DiemTrungBinh
FROM SINHVIEN sv
LEFT JOIN KETQUA kq ON sv.MaSV = kq.MaSV
GROUP BY sv.MaSV, sv.HoTen
ORDER BY sv.MaSV;
GO
