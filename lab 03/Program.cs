using System.Globalization;
using System.Text;

namespace Lab03_QuanLySinhVienOOP;
public class Nguoi
{
    private string _hoTen = string.Empty;
    private DateTime _ngaySinh;

    public Nguoi(string hoTen, DateTime ngaySinh)
    {
        HoTen = hoTen;
        NgaySinh = ngaySinh;
    }

    public string HoTen
    {
        get => _hoTen;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ho ten khong duoc de trong.");
            _hoTen = value.Trim();
        }
    }

    public DateTime NgaySinh
    {
        get => _ngaySinh;
        set
        {
            if (value.Date > DateTime.Today)
                throw new ArgumentException("Ngay sinh khong duoc lon hon ngay hien tai.");
            _ngaySinh = value.Date;
        }
    }

    public virtual string LayThongTin()
    {
        return $"{HoTen} - {NgaySinh:dd/MM/yyyy}";
    }
}
public class SinhVien : Nguoi
{
    private string _maSinhVien = string.Empty;
    private string _maLop = string.Empty;
    private double _diemTrungBinh;

    public SinhVien(string maSinhVien, string hoTen, DateTime ngaySinh, string maLop, double diemTrungBinh)
        : base(hoTen, ngaySinh)
    {
        MaSinhVien = maSinhVien;
        MaLop = maLop;
        DiemTrungBinh = diemTrungBinh;
    }

    public string MaSinhVien
    {
        get => _maSinhVien;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ma sinh vien khong duoc de trong.");
            _maSinhVien = value.Trim();
        }
    }

    public string MaLop
    {
        get => _maLop;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ma lop khong duoc de trong.");
            _maLop = value.Trim();
        }
    }

    public double DiemTrungBinh
    {
        get => _diemTrungBinh;
        set
        {
            if (value < 0 || value > 10)
                throw new ArgumentException("Diem khong hop le (phai tu 0 den 10).");
            _diemTrungBinh = value;
        }
    }

    public string XepLoai()
    {
        if (DiemTrungBinh >= 9) return "Xuat sac";
        if (DiemTrungBinh >= 8) return "Gioi";
        if (DiemTrungBinh >= 7) return "Kha";
        if (DiemTrungBinh >= 5) return "Trung binh";
        return "Yeu";
    }

    public override string LayThongTin()
    {
        return $"{MaSinhVien,-8} | {base.LayThongTin(),-36} | {MaLop,-8} | {DiemTrungBinh,4:0.0} | {XepLoai()}";
    }
}

public class QuanLySinhVien
{
    private readonly List<SinhVien> _danhSach = new();

    public bool Them(SinhVien sinhVien)
    {
        ArgumentNullException.ThrowIfNull(sinhVien);

        if (TimTheoMa(sinhVien.MaSinhVien) != null)
            return false;

        _danhSach.Add(sinhVien);
        return true;
    }
    public bool Sua(string maSinhVien, double diemMoi)
    {
        SinhVien? sinhVien = TimTheoMa(maSinhVien);
        if (sinhVien == null) return false;

        sinhVien.DiemTrungBinh = diemMoi; 
        return true;
    }

    public bool Xoa(string maSinhVien)
    {
        SinhVien? sinhVien = TimTheoMa(maSinhVien);
        if (sinhVien == null) return false;

        return _danhSach.Remove(sinhVien);
    }

    public SinhVien? TimTheoMa(string maSinhVien)
    {
        return _danhSach.FirstOrDefault(sv =>
            string.Equals(sv.MaSinhVien, maSinhVien.Trim(), StringComparison.OrdinalIgnoreCase));
    }

    public List<SinhVien> TimTheoTen(string tuKhoa)
    {
        return _danhSach
            .Where(sv => sv.HoTen.Contains(tuKhoa.Trim(), StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

 
    public List<SinhVien> SapXepTheoDiem()
    {
        return _danhSach
            .OrderByDescending(sv => sv.DiemTrungBinh)
            .ThenBy(sv => sv.HoTen)
            .ToList();
    }

    public List<SinhVien> LocSinhVienDat()
    {
        return _danhSach.Where(sv => sv.DiemTrungBinh >= 5).ToList();
    }

    public List<SinhVien> LayDanhSach()
    {
        return new List<SinhVien>(_danhSach); 
    }
}

public class Program
{
    private static readonly QuanLySinhVien QuanLy = new();

    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        bool dangChay = true;
        while (dangChay)
        {
            HienThiMenu();
            string luaChon = (Console.ReadLine() ?? string.Empty).Trim();

            try
            {
                switch (luaChon)
                {
                    case "1": ThemSinhVien(); break;
                    case "2": XuatDanhSach(); break;
                    case "3": TimTheoMa(); break;
                    case "4": TimTheoTen(); break;
                    case "5": SuaDiem(); break;
                    case "6": XoaSinhVien(); break;
                    case "7": SapXepTheoDiem(); break;
                    case "8": LocSinhVienDat(); break;
                    case "0":
                        dangChay = false;
                        Console.WriteLine("Tam biet!");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le, vui long chon lai.");
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"[LOI DU LIEU] {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LOI KHONG XAC DINH] {ex.Message}");
            }
        }
    }

    private static void HienThiMenu()
    {
        Console.WriteLine();
        Console.WriteLine("===== QUAN LY SINH VIEN =====");
        Console.WriteLine("1. Them sinh vien");
        Console.WriteLine("2. Xuat danh sach");
        Console.WriteLine("3. Tim sinh vien theo ma");
        Console.WriteLine("4. Tim sinh vien theo ten");
        Console.WriteLine("5. Sua diem trung binh");
        Console.WriteLine("6. Xoa sinh vien");
        Console.WriteLine("7. Sap xep theo diem giam dan");
        Console.WriteLine("8. Loc sinh vien dat");
        Console.WriteLine("0. Thoat");
        Console.Write("Chon chuc nang: ");
    }

    private static void ThemSinhVien()
    {
        string ma = DocChuoiKhongRong("Nhap ma sinh vien: ");
        if (QuanLy.TimTheoMa(ma) != null)
        {
            Console.WriteLine($"Ma sinh vien '{ma}' da ton tai.");
            return;
        }

        string hoTen = DocChuoiKhongRong("Nhap ho ten: ");
        DateTime ngaySinh = DocNgaySinh("Nhap ngay sinh (dd/MM/yyyy): ");
        string maLop = DocChuoiKhongRong("Nhap ma lop: ");
        double diem = DocDiem("Nhap diem trung binh (0-10): ");

        if (QuanLy.Them(new SinhVien(ma, hoTen, ngaySinh, maLop, diem)))
            Console.WriteLine("Them sinh vien thanh cong.");
        else
            Console.WriteLine($"Ma sinh vien '{ma}' da ton tai.");
    }

    private static void XuatDanhSach()
    {
        InDanhSach(QuanLy.LayDanhSach(), "Danh sach sinh vien dang rong.");
    }

    private static void TimTheoMa()
    {
        string ma = DocChuoiKhongRong("Nhap ma sinh vien can tim: ");
        SinhVien? sinhVien = QuanLy.TimTheoMa(ma);

        if (sinhVien == null)
        {
            Console.WriteLine($"Khong tim thay sinh vien co ma '{ma}'.");
            return;
        }

        InTieuDe();
        Console.WriteLine(sinhVien.LayThongTin());
    }

    private static void TimTheoTen()
    {
        string tuKhoa = DocChuoiKhongRong("Nhap tu khoa ho ten: ");
        InDanhSach(QuanLy.TimTheoTen(tuKhoa), "Khong co sinh vien nao co ten chua tu khoa.");
    }

    private static void SuaDiem()
    {
        string ma = DocChuoiKhongRong("Nhap ma sinh vien can sua diem: ");
        if (QuanLy.TimTheoMa(ma) == null)
        {
            Console.WriteLine($"Khong tim thay sinh vien co ma '{ma}'.");
            return;
        }

        double diemMoi = DocDiem("Nhap diem trung binh moi (0-10): ");
        QuanLy.Sua(ma, diemMoi);
        Console.WriteLine("Cap nhat diem thanh cong.");
    }

    private static void XoaSinhVien()
    {
        string ma = DocChuoiKhongRong("Nhap ma sinh vien can xoa: ");
        if (QuanLy.Xoa(ma))
            Console.WriteLine("Xoa sinh vien thanh cong.");
        else
            Console.WriteLine($"Khong tim thay sinh vien co ma '{ma}'.");
    }

    private static void SapXepTheoDiem()
    {
        InDanhSach(QuanLy.SapXepTheoDiem(), "Danh sach sinh vien dang rong.");
    }

    private static void LocSinhVienDat()
    {
        InDanhSach(QuanLy.LocSinhVienDat(), "Khong co sinh vien nao dat (diem >= 5).");
    }

    private static void InTieuDe()
    {
        Console.WriteLine($"{"Ma SV",-8} | {"Ho ten - Ngay sinh",-36} | {"Lop",-8} | {"Diem",4} | Xep loai");
        Console.WriteLine(new string('-', 80));
    }

    private static void InDanhSach(List<SinhVien> danhSach, string thongBaoRong)
    {
        if (danhSach.Count == 0)
        {
            Console.WriteLine(thongBaoRong);
            return;
        }

        InTieuDe();
        foreach (SinhVien sv in danhSach)
            Console.WriteLine(sv.LayThongTin());
        Console.WriteLine($"Tong cong: {danhSach.Count} sinh vien.");
    }

    private static string DocChuoiKhongRong(string loiNhac)
    {
        while (true)
        {
            Console.Write(loiNhac);
            string input = (Console.ReadLine() ?? string.Empty).Trim();
            if (input.Length > 0) return input;
            Console.WriteLine("Khong duoc de trong, vui long nhap lai.");
        }
    }

    private static DateTime DocNgaySinh(string loiNhac)
    {
        while (true)
        {
            Console.Write(loiNhac);
            string input = (Console.ReadLine() ?? string.Empty).Trim();

            if (!DateTime.TryParseExact(input, "d/M/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime ngaySinh))
                Console.WriteLine("Ngay sinh khong hop le, dinh dang dung: dd/MM/yyyy.");
            else if (ngaySinh.Date > DateTime.Today)
                Console.WriteLine("Ngay sinh khong duoc lon hon ngay hien tai.");
            else
                return ngaySinh;
        }
    }

    private static double DocDiem(string loiNhac)
    {
        while (true)
        {
            Console.Write(loiNhac);
            string input = (Console.ReadLine() ?? string.Empty).Trim().Replace(',', '.');

            if (!double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double diem))
                Console.WriteLine("Vui long nhap mot so hop le.");
            else if (diem < 0 || diem > 10)
                Console.WriteLine("Diem khong hop le (phai tu 0 den 10), vui long nhap lai.");
            else
                return diem;
        }
    }
}
