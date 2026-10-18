using System;
using System.Collections.Generic;

namespace QuanLySanPham
{    public interface IEntity
    {
        string Id { get; }
    }
    public class SanPham : IEntity
    {
        private string maSP;
        private string tenSP;
        private decimal donGia;
        private int soLuong;

        public SanPham(string maSP, string tenSP, decimal donGia, int soLuong)
        {
            MaSP = maSP;
            TenSP = tenSP;
            DonGia = donGia;
            SoLuong = soLuong;
        }

        public string Id
        {
            get
            {
                return MaSP;
            }
        }

        public string MaSP
        {
            get
            {
                return maSP;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Ma san pham khong duoc rong!");
                }

                maSP = value.Trim();
            }
        }

        public string TenSP
        {
            get
            {
                return tenSP;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Ten san pham khong duoc rong!");
                }

                tenSP = value.Trim();
            }
        }

        public decimal DonGia
        {
            get
            {
                return donGia;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Don gia khong duoc am!");
                }

                donGia = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("So luong khong duoc am!");
                }

                soLuong = value;
            }
        }

        public override string ToString()
        {
            return "Ma: " + MaSP +
                   " | Ten: " + TenSP +
                   " | Gia: " + DonGia +
                   " | So luong: " + SoLuong;
        }
    }

    public class TrungMaSanPhamException : Exception
    {
        public TrungMaSanPhamException(string maSP)
            : base("San pham co ma '" + maSP + "' da ton tai!")
        {
        }
    }
    public class KhongTimThaySanPhamException : Exception
    {
        public KhongTimThaySanPhamException(string maSP)
            : base("Khong tim thay san pham co ma '" + maSP + "'!")
        {
        }
    }

    public class Repository<T> where T : IEntity
    {
        private List<T> danhSach;

        public Repository()
        {
            danhSach = new List<T>();
        }

        public void Them(T doiTuong)
        {
            danhSach.Add(doiTuong);
        }

        public bool Xoa(string ma)
        {
            T doiTuong = TimTheoMa(ma);

            if (doiTuong != null)
            {
                danhSach.Remove(doiTuong);
                return true;
            }

            return false;
        }

        public T TimTheoMa(string ma)
        {
            foreach (T doiTuong in danhSach)
            {
                if (doiTuong.Id.ToLower() == ma.ToLower())
                {
                    return doiTuong;
                }
            }

            return default(T);
        }
        public List<T> Tim(Func<T, bool> dieuKien)
        {
            List<T> ketQua = new List<T>();

            foreach (T doiTuong in danhSach)
            {
                if (dieuKien(doiTuong))
                {
                    ketQua.Add(doiTuong);
                }
            }

            return ketQua;
        }

        public List<T> LayTatCa()
        {
            return new List<T>(danhSach);
        }
    }

    public class QuanLySanPham
    {
        private Repository<SanPham> khoSanPham;

        public event Action<SanPham> ThemThanhCong;

        public event Action<SanPham> XoaThanhCong;

        public QuanLySanPham()
        {
            khoSanPham = new Repository<SanPham>();
        }

        public void ThemSanPham(SanPham sanPham)
        {
            SanPham sanPhamCu = khoSanPham.TimTheoMa(sanPham.MaSP);

            if (sanPhamCu != null)
            {
                throw new TrungMaSanPhamException(sanPham.MaSP);
            }

            khoSanPham.Them(sanPham);

            if (ThemThanhCong != null)
            {
                ThemThanhCong(sanPham);
            }
        }

        public void XoaSanPham(string maSP)
        {
            SanPham sanPham = khoSanPham.TimTheoMa(maSP);

            if (sanPham == null)
            {
                throw new KhongTimThaySanPhamException(maSP);
            }

            khoSanPham.Xoa(maSP);

            if (XoaThanhCong != null)
            {
                XoaThanhCong(sanPham);
            }
        }

        public List<SanPham> LayTatCa()
        {
            return khoSanPham.LayTatCa();
        }

        public SanPham TimTheoMa(string maSP)
        {
            return khoSanPham.TimTheoMa(maSP);
        }

        public List<SanPham> Loc(Func<SanPham, bool> dieuKien)
        {
            return khoSanPham.Tim(dieuKien);
        }

        public List<SanPham> TimTheoTen(string tuKhoa)
        {
            return Loc(delegate (SanPham sanPham)
            {
                return sanPham.TenSP.ToLower().Contains(tuKhoa.ToLower());
            });
        }
        public List<SanPham> LocTheoGia(decimal giaMin, decimal giaMax)
        {
            if (giaMin < 0 || giaMax < 0)
            {
                throw new ArgumentException("Gia khong duoc am!");
            }

            if (giaMin > giaMax)
            {
                throw new ArgumentException(
                    "Gia nho nhat phai nho hon hoac bang gia lon nhat!");
            }

            return Loc(delegate (SanPham sanPham)
            {
                return sanPham.DonGia >= giaMin &&
                       sanPham.DonGia <= giaMax;
            });
        }

        public decimal TinhTongGiaTriKho()
        {
            decimal tong = 0;

            List<SanPham> danhSach = khoSanPham.LayTatCa();

            foreach (SanPham sanPham in danhSach)
            {
                tong = tong + sanPham.DonGia * sanPham.SoLuong;
            }

            return tong;
        }
    }
    public class Program
    {
        static QuanLySanPham quanLy = new QuanLySanPham();

        static void Main(string[] args)
        {
            quanLy.ThemThanhCong += KhiThemSanPham;
            quanLy.XoaThanhCong += KhiXoaSanPham;

            bool dangChay = true;

            while (dangChay)
            {
                HienThiMenu();

                Console.Write("Chon: ");
                string luaChon = Console.ReadLine();

                try
                {
                    switch (luaChon)
                    {
                        case "1":
                            ThemSanPham();
                            break;

                        case "2":
                            XuatDanhSach();
                            break;

                        case "3":
                            TimTheoMa();
                            break;

                        case "4":
                            TimTheoTen();
                            break;

                        case "5":
                            LocTheoGia();
                            break;

                        case "6":
                            XoaSanPham();
                            break;

                        case "7":
                            TinhTongGiaTriKho();
                            break;

                        case "0":
                            dangChay = false;
                            Console.WriteLine("Cam on ban da su dung chuong trinh!");
                            break;

                        default:
                            Console.WriteLine("Lua chon khong hop le!");
                            break;
                    }
                }
                catch (TrungMaSanPhamException ex)
                {
                    Console.WriteLine("LOI: " + ex.Message);
                }
                catch (KhongTimThaySanPhamException ex)
                {
                    Console.WriteLine("LOI: " + ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("LOI: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("LOI: " + ex.Message);
                }

                Console.WriteLine();
            }
        }

        static void HienThiMenu()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("      QUAN LY SAN PHAM");
            Console.WriteLine("1. Them san pham");
            Console.WriteLine("2. Xuat danh sach");
            Console.WriteLine("3. Tim theo ma");
            Console.WriteLine("4. Tim theo ten");
            Console.WriteLine("5. Loc theo khoang gia");
            Console.WriteLine("6. Xoa san pham");
            Console.WriteLine("7. Tinh tong gia tri kho");
            Console.WriteLine("0. Thoat");
            Console.WriteLine("==============================");
        }

        static void ThemSanPham()
        {
            Console.Write("Nhap ma san pham: ");
            string maSP = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(maSP))
            {
                Console.WriteLine("Ma san pham khong duoc rong!");
                Console.Write("Nhap lai ma san pham: ");
                maSP = Console.ReadLine();
            }

            Console.Write("Nhap ten san pham: ");
            string tenSP = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(tenSP))
            {
                Console.WriteLine("Ten san pham khong duoc rong!");
                Console.Write("Nhap lai ten san pham: ");
                tenSP = Console.ReadLine();
            }

            decimal donGia = NhapSoThuc("Nhap don gia: ");
            int soLuong = NhapSoNguyen("Nhap so luong: ");

            SanPham sanPham = new SanPham(
                maSP,
                tenSP,
                donGia,
                soLuong
            );

            quanLy.ThemSanPham(sanPham);
        }

        static void XuatDanhSach()
        {
            List<SanPham> danhSach = quanLy.LayTatCa();

            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sach san pham dang rong!");
                return;
            }

            Console.WriteLine(" DANH SACH SAN PHAM ");

            foreach (SanPham sanPham in danhSach)
            {
                Console.WriteLine(sanPham);
            }

            Console.WriteLine("Tong so: " + danhSach.Count + " san pham");
        }

        static void TimTheoMa()
        {
            Console.Write("Nhap ma san pham can tim: ");
            string maSP = Console.ReadLine();

            SanPham sanPham = quanLy.TimTheoMa(maSP);

            if (sanPham == null)
            {
                Console.WriteLine("Khong tim thay san pham!");
            }
            else
            {
                Console.WriteLine("San pham tim thay:");
                Console.WriteLine(sanPham);
            }
        }

        static void TimTheoTen()
        {
            Console.Write("Nhap tu khoa ten: ");
            string tuKhoa = Console.ReadLine();

            List<SanPham> ketQua = quanLy.TimTheoTen(tuKhoa);

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Khong tim thay san pham nao!");
                return;
            }

            Console.WriteLine(" KET QUA TIM KIEM ");

            foreach (SanPham sanPham in ketQua)
            {
                Console.WriteLine(sanPham);
            }
        }
        static void LocTheoGia()
        {
            decimal giaMin = NhapSoThuc("Nhap gia nho nhat: ");
            decimal giaMax = NhapSoThuc("Nhap gia lon nhat: ");

            List<SanPham> ketQua =
                quanLy.LocTheoGia(giaMin, giaMax);

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Khong co san pham trong khoang gia nay!");
                return;
            }

            Console.WriteLine("SAN PHAM TRONG KHOANG GIA ");

            foreach (SanPham sanPham in ketQua)
            {
                Console.WriteLine(sanPham);
            }
        }
        static void XoaSanPham()
        {
            Console.Write("Nhap ma san pham can xoa: ");
            string maSP = Console.ReadLine();

            quanLy.XoaSanPham(maSP);
        }

        static void TinhTongGiaTriKho()
        {
            decimal tong = quanLy.TinhTongGiaTriKho();

            Console.WriteLine(
                "Tong gia tri kho: " + tong + " VND"
            );
        }

        static decimal NhapSoThuc(string thongBao)
        {
            decimal giaTri;

            while (true)
            {
                Console.Write(thongBao);

                if (decimal.TryParse(Console.ReadLine(), out giaTri))
                {
                    if (giaTri >= 0)
                    {
                        return giaTri;
                    }

                    Console.WriteLine("Gia tri khong duoc am!");
                }
                else
                {
                    Console.WriteLine("Vui long nhap so hop le!");
                }
            }
        }

        static int NhapSoNguyen(string thongBao)
        {
            int giaTri;

            while (true)
            {
                Console.Write(thongBao);

                if (int.TryParse(Console.ReadLine(), out giaTri))
                {
                    if (giaTri >= 0)
                    {
                        return giaTri;
                    }

                    Console.WriteLine("So luong khong duoc am!");
                }
                else
                {
                    Console.WriteLine("Vui long nhap so nguyen!");
                }
            }
        }
        static void KhiThemSanPham(SanPham sanPham)
        {
            Console.WriteLine(
                "Da them san pham: " +
                sanPham.MaSP +
                " - " +
                sanPham.TenSP
            );
        }

        static void KhiXoaSanPham(SanPham sanPham)
        {
            Console.WriteLine(
                "Da xoa san pham: " +
                sanPham.MaSP +
                " - " +
                sanPham.TenSP
            );
        }
    }
}