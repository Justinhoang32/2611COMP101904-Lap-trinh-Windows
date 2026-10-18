# Lab 03 - Quản lý sinh viên 
## 2611COMP101904-Lap-trinh-Windows
## Bài Lab: Lab 03- Quản lý sinh viên
## Họ tên sinh viên: Hoàng Minh Nhật
## MSSV: 51.01.104.066
## Nhóm 5

---

## 1. Giới thiệu

Chương trình Console quản lý sinh viên theo hướng đối tượng. Người dùng thao tác qua menu; dữ liệu lưu trong bộ nhớ bằng `List<SinhVien>`. Chương trình không bị dừng khi nhập sai kiểu dữ liệu.

## 2. Kiến thức áp dụng

| Nội dung | Vị trí áp dụng |
|---|---|
| Class, object, property, constructor | `Nguoi`, `SinhVien`, `QuanLySinhVien` |
| Kế thừa | `SinhVien : Nguoi` (gọi `base(...)` trong constructor) |
| Override | `SinhVien.LayThongTin()` ghi đè `Nguoi.LayThongTin()` (`virtual`/`override`) |
| Property có kiểm tra dữ liệu | `DiemTrungBinh` chỉ nhận 0–10; `HoTen`, `MaSinhVien`, `MaLop` không rỗng; `NgaySinh` không ở tương lai |
| `List<SinhVien>` | Lưu danh sách trong `QuanLySinhVien` |
| LINQ | `Where`, `OrderByDescending`, `FirstOrDefault` |
| Xử lý lỗi nhập liệu | `TryParse`/`TryParseExact` trong vòng lặp nhập, `try-catch` trong `Main` |

## 3. Cấu trúc project

Toàn bộ mã nguồn nằm trong **một file `Program.cs`**, chia thành các class riêng biệt và ngăn cách bằng dòng chú thích:

```
Lab03_QuanLySinhVienOOP/
├── Program.cs               
├── Lab03_QuanLySinhVienOOP.csproj
├── .gitignore
├── README.md
└── image/                       
```

| Thứ tự trong `Program.cs` | Class | Vai trò |
|---|---|---|
| 1 | `Nguoi` | Lớp cha |
| 2 | `SinhVien` | Lớp con kế thừa `Nguoi` |
| 3 | `QuanLySinhVien` | Quản lý `List<SinhVien>` |
| 4 | `Program` | Menu, nhập xuất |

> Dù gộp chung một file, các class vẫn tách biệt trách nhiệm: `QuanLySinhVien` xử lý dữ liệu, `Program` chỉ lo giao diện console.

## 4. Mô tả chi tiết các lớp

(Tất cả các lớp dưới đây nằm trong file `Program.cs`.)

### 4.1 `Nguoi` (lớp cha)
- Thuộc tính: `HoTen` (không rỗng), `NgaySinh` (không lớn hơn ngày hiện tại).
- Có constructor `Nguoi(string hoTen, DateTime ngaySinh)`.
- `virtual string LayThongTin()`: trả về `Họ tên - dd/MM/yyyy`, cho phép lớp con override.

### 4.2 `SinhVien` (kế thừa `Nguoi`)
- Thuộc tính riêng: `MaSinhVien`, `MaLop` (không rỗng), `DiemTrungBinh` (0–10, sai sẽ ném `ArgumentException`).
- Constructor `SinhVien(ma, hoTen, ngaySinh, maLop, diem)` gọi `base(hoTen, ngaySinh)`.
- `XepLoai()`:

| Điểm | Xếp loại |
|---|---|
| ≥ 9 | Xuat sac |
| ≥ 8 | Gioi |
| ≥ 7 | Kha |
| ≥ 5 | Trung binh |
| < 5 | Yeu |

- `override LayThongTin()`: gọi `base.LayThongTin()` rồi thêm mã, lớp, điểm, xếp loại.

### 4.3 `QuanLySinhVien`
| Phương thức | Mô tả |
|---|---|
| `Them(SinhVien)` | Thêm; trả về `false` nếu trùng mã |
| `Sua(ma, diemMoi)` | Cập nhật điểm; `false` nếu không có mã |
| `Xoa(ma)` | Xóa; `false` nếu không có mã |
| `TimTheoMa(ma)` | `FirstOrDefault` – không phân biệt hoa thường |
| `TimTheoTen(tuKhoa)` | LINQ `Where` + `Contains` |
| `SapXepTheoDiem()` | LINQ `OrderByDescending` |
| `LocSinhVienDat()` | LINQ `Where(sv => sv.DiemTrungBinh >= 5)` |
| `LayDanhSach()` | Trả về bản sao danh sách |

`Main` không thao tác trực tiếp với `List`, chỉ gọi qua `QuanLySinhVien`.

### 4.4 `Program`
- Hiển thị menu, gọi các hàm chức năng (`ThemSinhVien`, `XuatDanhSach`, …).
- Hàm nhập `DocChuoiKhongRong`, `DocNgaySinh`, `DocDiem` lặp lại đến khi nhập đúng.
- Hàm xuất `InTieuDe`, `InDanhSach` in bảng, có thông báo khi danh sách rỗng.

## 5. Xử lý lỗi và validation

| Tình huống | Xử lý |
|---|---|
| Thêm mã trùng | Báo "Ma sinh vien ... da ton tai" |
| Điểm `-1`, `11` hoặc chữ | Báo lỗi và yêu cầu nhập lại |
| Ngày sinh sai định dạng / ở tương lai | Báo lỗi và yêu cầu nhập lại |
| Để trống mã, tên, lớp | Báo lỗi và yêu cầu nhập lại |
| Sửa/xóa/tìm mã không tồn tại | Thông báo không tìm thấy |
| Danh sách rỗng | Thông báo phù hợp |
| Chọn menu sai | Báo lựa chọn không hợp lệ |
| Lỗi bất ngờ | `try-catch` trong `Main`, chương trình tiếp tục chạy |

### 6.1 Menu chính
![Menu chính](images/01_menu.png)

### 6.2 Thêm sinh viên thành công
Dữ liệu mẫu: `SV001 | Nguyễn Văn A | 15/03/2004 | CTK44 | 8.2`
![Thêm thành công](images/02_them_thanh_cong.png)

### 6.3 Thêm lại mã SV001 (báo trùng mã)
![Trùng mã](images/03_trung_ma.png)

### 6.4 Nhập điểm -1 hoặc 11 (báo lỗi, nhập lại)
![Điểm không hợp lệ](images/04_diem_khong_hop_le.png)

### 6.5 Nhập sai kiểu dữ liệu (chữ thay vì số, ngày sai định dạng)
![Sai kiểu dữ liệu](images/05_sai_kieu_du_lieu.png)

### 6.6 Xuất danh sách (có dữ liệu)
![Xuất danh sách](images/06_xuat_danh_sach.png)

### 6.7 Xuất danh sách khi rỗng
![Danh sách rỗng](images/07_danh_sach_rong.png)

### 6.8 Tìm theo mã
![Tìm theo mã](images/08_tim_theo_ma.png)

### 6.9 Tìm theo tên với từ khóa "Nguyễn"
![Tìm theo tên](images/09_tim_theo_ten.png)

### 6.10 Sửa điểm trung bình
![Sửa điểm](images/10_sua_diem.png)

### 6.11 Xóa sinh viên thành công
![Xóa thành công](images/11_xoa_thanh_cong.png)

### 6.12 Xóa mã không tồn tại
![Xóa không tồn tại](images/12_xoa_khong_ton_tai.png)

### 6.13 Sắp xếp theo điểm giảm dần (LINQ)
![Sắp xếp](images/13_sap_xep.png)

### 6.14 Lọc sinh viên đạt (điểm ≥ 5)
![Lọc sinh viên đạt](images/14_loc_dat.png)

### 6.15 Thoát chương trình
![Thoát](images/15_thoat.png)
