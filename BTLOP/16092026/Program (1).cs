using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyNhanVien
{
    // LỚP CHA: NhanVien
    public class NhanVien
    {
        private string maNV = string.Empty;
        private string hoTen = string.Empty;
        private double luongCoBan;

        public string MaNV
        {
            get => maNV;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã nhân viên không được để trống.");
                maNV = value.Trim();
            }
        }

        public string HoTen
        {
            get => hoTen;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Họ tên không được để trống.");
                hoTen = value.Trim();
            }
        }

        public double LuongCoBan
        {
            get => luongCoBan;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Lương cơ bản phải lớn hơn 0.");
                luongCoBan = value;
            }
        }

        public NhanVien(string maNV, string hoTen, double luongCoBan)
        {
            MaNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
        }

        public virtual double TinhLuong()
        {
            return LuongCoBan;
        }

        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"[NV Thường]  Mã: {MaNV,-6} Họ tên: {HoTen,-20} Lương cơ bản: {LuongCoBan,15:N0} đ  => Lương thực nhận: {TinhLuong(),15:N0} đ");
        }
    }

    // LỚP KẾ THỪA: NhanVienVanPhong
    public class NhanVienVanPhong : NhanVien
    {
        private int soNgayLamViec;

        public int SoNgayLamViec
        {
            get => soNgayLamViec;
            set
            {
                if (value < 0 || value > 31)
                    throw new ArgumentException("Số ngày làm việc phải trong khoảng 0-31.");
                soNgayLamViec = value;
            }
        }

        public const double PHU_CAP_MOI_NGAY = 200000;

        public NhanVienVanPhong(string maNV, string hoTen, double luongCoBan, int soNgayLamViec)
            : base(maNV, hoTen, luongCoBan)
        {
            SoNgayLamViec = soNgayLamViec;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + SoNgayLamViec * PHU_CAP_MOI_NGAY;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"[Văn phòng]  Mã: {MaNV,-6} Họ tên: {HoTen,-20} Lương cơ bản: {LuongCoBan,15:N0} đ  Số ngày làm: {SoNgayLamViec,3}  => Lương thực nhận: {TinhLuong(),15:N0} đ");
        }
    }

    // LỚP KẾ THỪA: NhanVienKinhDoanh
    public class NhanVienKinhDoanh : NhanVien
    {
        private double doanhSo;

        public double DoanhSo
        {
            get => doanhSo;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Doanh số phải >= 0.");
                doanhSo = value;
            }
        }

        public const double TY_LE_HOA_HONG = 0.05;

        public NhanVienKinhDoanh(string maNV, string hoTen, double luongCoBan, double doanhSo)
            : base(maNV, hoTen, luongCoBan)
        {
            DoanhSo = doanhSo;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + TY_LE_HOA_HONG * DoanhSo;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"[Kinh doanh] Mã: {MaNV,-6} Họ tên: {HoTen,-20} Lương cơ bản: {LuongCoBan,15:N0} đ  Doanh số: {DoanhSo,15:N0} đ  => Lương thực nhận: {TinhLuong(),15:N0} đ");
        }
    }

    // BONUS - LỚP KẾ THỪA: NhanVienThoiVu
    public class NhanVienThoiVu : NhanVien
    {
        private double soGioLam;
        private double luongTheoGio;

        public double SoGioLam
        {
            get => soGioLam;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Số giờ làm phải >= 0.");
                soGioLam = value;
            }
        }

        public double LuongTheoGio
        {
            get => luongTheoGio;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Lương theo giờ phải > 0.");
                luongTheoGio = value;
            }
        }

        public NhanVienThoiVu(string maNV, string hoTen, double soGioLam, double luongTheoGio)
            : base(maNV, hoTen, Math.Max(soGioLam * luongTheoGio, 1))
        {
            SoGioLam = soGioLam;
            LuongTheoGio = luongTheoGio;
        }

        public override double TinhLuong()
        {
            return SoGioLam * LuongTheoGio;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"[Thời vụ]    Mã: {MaNV,-6} Họ tên: {HoTen,-20} Số giờ làm: {SoGioLam,6:N1}  Lương/giờ: {LuongTheoGio,10:N0} đ  => Lương thực nhận: {TinhLuong(),15:N0} đ");
        }
    }

    // CHƯƠNG TRÌNH CHÍNH
    public static class Program
    {
        private static readonly List<NhanVien> danhSach = new List<NhanVien>();

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            NhapDanhSachBanDau();

            bool tiepTuc = true;
            while (tiepTuc)
            {
                HienThiMenu();
                string luaChon = DocDong();

                switch (luaChon.Trim())
                {
                    case "1":
                        XuatDanhSach();
                        break;
                    case "2":
                        TimTheoMa();
                        break;
                    case "3":
                        TimLuongCaoNhat();
                        break;
                    case "4":
                        TinhTongLuong();
                        break;
                    case "0":
                        tiepTuc = false;
                        Console.WriteLine("Tạm biệt!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");
                        break;
                }
                Console.WriteLine();
            }
        }

        private static void HienThiMenu()
        {
            Console.WriteLine("========== MENU ==========");
            Console.WriteLine("1. Xuất danh sách nhân viên");
            Console.WriteLine("2. Tìm nhân viên theo mã");
            Console.WriteLine("3. Tìm nhân viên có lương cao nhất");
            Console.WriteLine("4. Tính tổng lương công ty phải trả");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn chức năng: ");
        }


        private static void XuatDanhSach()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách rỗng.");
                return;
            }
            Console.WriteLine("--- DANH SÁCH NHÂN VIÊN ---");
            foreach (NhanVien nv in danhSach)
            {
                nv.HienThiThongTin(); 
            }
        }

        private static void TimTheoMa()
        {
            string ma = DocDongBatBuoc("Nhập mã nhân viên cần tìm: ").Trim();
            NhanVien? nv = danhSach.FirstOrDefault(x => x.MaNV.Equals(ma, StringComparison.OrdinalIgnoreCase));
            if (nv == null)
            {
                Console.WriteLine("Không tìm thấy nhân viên có mã: " + ma);
            }
            else
            {
                Console.WriteLine("Đã tìm thấy:");
                nv.HienThiThongTin(); 
            }
        }

        private static void TimLuongCaoNhat()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách rỗng.");
                return;
            }
            NhanVien nvCaoNhat = danhSach.OrderByDescending(nv => nv.TinhLuong()).First();
            Console.WriteLine("Nhân viên có lương cao nhất:");
            nvCaoNhat.HienThiThongTin();
        }

        private static void TinhTongLuong()
        {
            double tong = danhSach.Sum(nv => nv.TinhLuong());
            Console.WriteLine($"Tổng lương công ty phải trả: {tong:N0} đ");
        }


        private static void NhapDanhSachBanDau()
        {
            Console.WriteLine("========== NHẬP DANH SÁCH NHÂN VIÊN ==========");
            int soLuong = DocSoNguyenToiThieu("Nhập số lượng nhân viên cần quản lý (tối thiểu 5): ", 5);

            for (int i = 1; i <= soLuong; i++)
            {
                Console.WriteLine($"--- Nhập nhân viên thứ {i}/{soLuong} ---");
                danhSach.Add(NhapMotNhanVien());
            }

            Console.WriteLine();
            Console.WriteLine($"Đã nhập xong {danhSach.Count} nhân viên.");
            Console.WriteLine();
        }

        private static int DocSoNguyenToiThieu(string thongBao, int min)
        {
            while (true)
            {
                int sl = DocSoNguyen(thongBao);
                if (sl >= min) return sl;
                Console.WriteLine($"Số lượng phải >= {min}, vui lòng nhập lại.");
            }
        }

        private static NhanVien NhapMotNhanVien()
        {
            while (true)
            {
                Console.WriteLine("Chọn loại nhân viên:");
                Console.WriteLine("1. Nhân viên văn phòng");
                Console.WriteLine("2. Nhân viên kinh doanh");
                Console.WriteLine("3. Nhân viên thời vụ");
                string loai = DocDongBatBuoc("Chọn: ").Trim();

                try
                {
                    switch (loai)
                    {
                        case "1": return NhapVanPhong();
                        case "2": return NhapKinhDoanh();
                        case "3": return NhapThoiVu();
                        default:
                            Console.WriteLine("Loại nhân viên không hợp lệ, vui lòng chọn lại.");
                            continue;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Lỗi dữ liệu: " + ex.Message + " Vui lòng nhập lại nhân viên này.");
                }
            }
        }

        // ---------------- Hàm nhập liệu ----------------

        private static NhanVienVanPhong NhapVanPhong()
        {
            string ma = DocDongBatBuoc("Mã NV: ");
            string ten = DocDongBatBuoc("Họ tên: ");
            double luongCoBan = DocSoThuc("Lương cơ bản (> 0): ");
            int soNgay = DocSoNguyen("Số ngày làm việc (0-31): ");
            return new NhanVienVanPhong(ma, ten, luongCoBan, soNgay);
        }

        private static NhanVienKinhDoanh NhapKinhDoanh()
        {
            string ma = DocDongBatBuoc("Mã NV: ");
            string ten = DocDongBatBuoc("Họ tên: ");
            double luongCoBan = DocSoThuc("Lương cơ bản (> 0): ");
            double doanhSo = DocSoThuc("Doanh số (>= 0): ");
            return new NhanVienKinhDoanh(ma, ten, luongCoBan, doanhSo);
        }

        private static NhanVienThoiVu NhapThoiVu()
        {
            string ma = DocDongBatBuoc("Mã NV: ");
            string ten = DocDongBatBuoc("Họ tên: ");
            double soGio = DocSoThuc("Số giờ làm: ");
            double luongGio = DocSoThuc("Lương theo giờ (> 0): ");
            return new NhanVienThoiVu(ma, ten, soGio, luongGio);
        }

        private static double DocSoThuc(string thongBao)
        {
            double kq;
            while (true)
            {
                string dong = DocDongBatBuoc(thongBao);
                if (double.TryParse(dong, out kq)) return kq;
                Console.WriteLine("Giá trị không hợp lệ, vui lòng nhập lại số.");
            }
        }

        private static int DocSoNguyen(string thongBao)
        {
            int kq;
            while (true)
            {
                string dong = DocDongBatBuoc(thongBao);
                if (int.TryParse(dong, out kq)) return kq;
                Console.WriteLine("Giá trị không hợp lệ, vui lòng nhập lại số nguyên.");
            }
        }

        private static string DocDong()
        {
            string? dong = Console.ReadLine();
            if (dong == null)
            {
                Console.WriteLine();
                Console.WriteLine("Không còn dữ liệu đầu vào. Kết thúc chương trình.");
                Environment.Exit(0);
            }
            return dong;
        }

        private static string DocDongBatBuoc(string thongBao)
        {
            Console.Write(thongBao);
            return DocDong();
        }
    }
}