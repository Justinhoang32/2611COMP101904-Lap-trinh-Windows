# BÁO CÁO ĐỀ TÀI
## Chương trình Console C# — Quản lý Nhân viên
## 2611COMP101904-Lap-trinh-Windows 
## Bài Tập Trên Lớp 
## Họ tên sinh viên: Hoàng Minh Nhật 
## MSSV: 51.01.104.066 
## Nhóm 5
---
## 1. Mục tiêu đề tài

Xây dựng chương trình quản lý nhân viên bằng C# (Console App), áp dụng các kiến thức lập trình hướng đối tượng (OOP):

- **Class & Object**
- **Property** (che giấu dữ liệu, kiểm tra hợp lệ khi gán giá trị)
- **Constructor** (khởi tạo đối tượng, dùng `base(...)` để gọi constructor lớp cha)
- **Encapsulation** (đóng gói)
- **Kế thừa (Inheritance)**
- **Đa hình (Polymorphism)** thông qua từ khóa `virtual` / `override`

---

## 2. Yêu cầu đề bài

- Lớp `NhanVien` (lớp cha): Mã nhân viên, Họ tên, Lương cơ bản (> 0), constructor, phương thức `virtual double TinhLuong()`, `virtual void HienThiThongTin()`.
- Hai lớp kế thừa:
  - **NhanVienVanPhong**: thêm `SoNgayLamViec` (0–31). Lương = Lương cơ bản + Số ngày làm việc × 200.000.
  - **NhanVienKinhDoanh**: thêm `DoanhSo` (≥ 0). Lương = Lương cơ bản + 5% × Doanh số.
- Chương trình chính dùng `List<NhanVien>`. Khi chạy, chương trình bắt người dùng **nhập danh sách nhân viên trước** (tối thiểu 5 người), sau khi nhập xong mới hiển thị menu:
  1. Xuất danh sách nhân viên
  2. Tìm nhân viên theo mã
  3. Tìm nhân viên có lương cao nhất
  4. Tính tổng lương công ty phải trả
  0. Thoát
- **Ràng buộc quan trọng:** khi xuất thông tin và tính lương phải dùng đa hình (`HienThiThongTin()`, `TinhLuong()`), **không được** dùng `if/switch` để kiểm tra kiểu nhân viên.
- **Bonus:** thêm lớp `NhanVienThoiVu` (Số giờ làm, Lương theo giờ; Lương = Số giờ làm × Lương theo giờ) mà **không phải sửa** thuật toán tìm lương cao nhất và tính tổng lương.

---

## 3. Phân tích & thiết kế

### 3.1 Sơ đồ kế thừa

```
                 NhanVien (lớp cha)
          - MaNV, HoTen, LuongCoBan
          - virtual TinhLuong()
          - virtual HienThiThongTin()
                       │
        ┌──────────────┼──────────────────┐
        │              │                  │
NhanVienVanPhong  NhanVienKinhDoanh  NhanVienThoiVu (bonus)
- SoNgayLamViec   - DoanhSo          - SoGioLam, LuongTheoGio
- override        - override         - override
```

### 3.2 Encapsulation

Tất cả thuộc tính của các lớp đều là **Property** với `private` field bên trong; mỗi setter đều kiểm tra tính hợp lệ và ném `ArgumentException` nếu sai (ví dụ: Lương cơ bản phải > 0, Số ngày làm việc phải trong khoảng 0–31, Doanh số phải ≥ 0...). Nhờ vậy dữ liệu nhân viên luôn ở trạng thái hợp lệ.

### 3.3 Kế thừa & `base(...)`

Constructor của `NhanVienVanPhong`, `NhanVienKinhDoanh`, `NhanVienThoiVu` đều gọi `base(maNV, hoTen, luongCoBan)` để tái sử dụng logic khởi tạo và kiểm tra hợp lệ đã có ở lớp cha `NhanVien`, sau đó chỉ khởi tạo thêm thuộc tính riêng của mình.

### 3.4 Đa hình (điểm mấu chốt của đề bài)

Hai phương thức `TinhLuong()` và `HienThiThongTin()` được khai báo `virtual` ở lớp cha và `override` ở từng lớp con với công thức/định dạng riêng. Trong chương trình chính, các chức năng đều thao tác trên biến kiểu `NhanVien` (kiểu cha):

```csharp
// Chức năng 1 — Xuất danh sách: gọi đa hình, không cần biết loại NV
foreach (NhanVien nv in danhSach)
    nv.HienThiThongTin();

// Chức năng 3 — Tìm lương cao nhất: chỉ dựa vào TinhLuong()
NhanVien nvCaoNhat = danhSach.OrderByDescending(nv => nv.TinhLuong()).First();

// Chức năng 4 — Tổng lương: chỉ dựa vào TinhLuong()
double tong = danhSach.Sum(nv => nv.TinhLuong());
```

Vì hai thuật toán ở chức năng 3 và 4 chỉ gọi `TinhLuong()` qua kiểu tham chiếu `NhanVien`, hoàn toàn không có `if/switch` kiểm tra `is NhanVienVanPhong` hay `is NhanVienKinhDoanh` — nên khi thêm lớp `NhanVienThoiVu` (bonus), chỉ cần lớp mới override đúng `TinhLuong()`/`HienThiThongTin()` là mọi chức năng cũ chạy đúng ngay, không phải sửa gì thêm. Đây chính là ý nghĩa thực tế của đa hình: mở rộng hệ thống mà không sửa code cũ (nguyên lý Open/Closed).

---

## 4. Kết quả chạy thử (kèm hình ảnh minh họa)

**Bước 1 — Nhập danh sách nhân viên trước khi vào menu.** Chương trình yêu cầu nhập số lượng nhân viên (tối thiểu 5), sau đó lần lượt cho chọn loại (Văn phòng / Kinh doanh / Thời vụ) và nhập thông tin cho từng người. Nếu dữ liệu không hợp lệ (ví dụ Lương cơ bản ≤ 0), chương trình báo lỗi và bắt nhập lại đúng nhân viên đó:

![Nhập danh sách nhân viên](images/00_nhapds.png)

**Bước 2 — Sau khi nhập đủ số nhân viên, chương trình mới hiển thị menu chính:**

![Menu chính](00.png)

**Chức năng 1 — Xuất danh sách nhân viên** (đa hình gọi đúng `HienThiThongTin()` của từng loại):

![Xuất danh sách](01.png)

**Chức năng 2 — Tìm nhân viên theo mã** (ví dụ nhập `VP01`):

![Tìm theo mã](02.png)

**Chức năng 3 — Tìm nhân viên có lương cao nhất** (so sánh bằng `TinhLuong()`, không cần biết loại NV):

![Lương cao nhất](03.png)

**Chức năng 4 — Tính tổng lương công ty phải trả** (cộng dồn `TinhLuong()` của cả 5 nhân viên: 10.400.000 + 10.100.000 + 7.000.000 + 6.100.000 + 3.000.000 = 36.600.000 đ):

![Tổng lương](04.png)

---
