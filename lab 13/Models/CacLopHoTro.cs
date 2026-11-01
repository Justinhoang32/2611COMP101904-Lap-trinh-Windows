namespace StudentReportDemo.Models
{
    public class LopItem
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }
    }

    public class DongBaoCao
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string TenLop { get; set; }
        public double Diem { get; set; }
        public string KetQua { get; set; }
    }

    public class ThongKeLop
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public int SoSinhVien { get; set; }
        public int SoDat { get; set; }
        public int SoKhongDat { get; set; }
        public double DiemTB { get; set; }
    }
}
