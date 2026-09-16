using System;

namespace Lab02_QuanLyMang
{
    class Program
    {
        // Mảng dùng chung cho toàn chương trình, và cờ đánh dấu đã nhập mảng hay chưa
        static int[] mang = null;
        static bool daNhapMang = false;

        static void Main(string[] args)
        {
            int luaChon;
            do
            {
                HienThiMenu();
                luaChon = NhapLuaChonMenu();

                switch (luaChon)
                {
                    case 1:
                        mang = NhapMang();
                        daNhapMang = true;
                        Console.WriteLine("Nhap mang thanh cong!");
                        break;

                    case 2:
                        if (KiemTraDaNhapMang())
                            XuatMang(mang);
                        break;

                    case 3:
                        if (KiemTraDaNhapMang())
                            Console.WriteLine("Tong cac phan tu: " + TinhTong(mang));
                        break;

                    case 4:
                        if (KiemTraDaNhapMang())
                        {
                            Console.WriteLine("Gia tri lon nhat: " + TimMax(mang));
                            Console.WriteLine("Gia tri nho nhat: " + TimMin(mang));
                        }
                        break;

                    case 5:
                        if (KiemTraDaNhapMang())
                        {
                            Console.WriteLine("So phan tu chan: " + DemChan(mang));
                            Console.WriteLine("So phan tu le: " + DemLe(mang));
                        }
                        break;

                    case 6:
                        if (KiemTraDaNhapMang())
                        {
                            SapXepTangDan(mang);
                            Console.WriteLine("Mang sau khi sap xep tang dan:");
                            XuatMang(mang);
                        }
                        break;

                    case 7:
                        if (KiemTraDaNhapMang())
                        {
                            int x = NhapSoNguyen("Nhap gia tri can tim x: ");
                            int viTri = TimKiem(mang, x);
                            if (viTri != -1)
                                Console.WriteLine("Tim thay " + x + " tai vi tri " + viTri + " (tinh tu 0)");
                            else
                                Console.WriteLine("Khong tim thay " + x + " trong mang.");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Cam on ban da su dung chuong trinh!");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le, vui long chon lai.");
                        break;
                }

                Console.WriteLine(); 
            } while (luaChon != 0);
        }

   

        // Hiển thị menu chương trình
        static void HienThiMenu()
        {
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1. Nhap mang");
            Console.WriteLine("2. Xuat mang");
            Console.WriteLine("3. Tinh tong");
            Console.WriteLine("4. Tim max/min");
            Console.WriteLine("5. Dem chan/le");
            Console.WriteLine("6. Sap xep tang dan");
            Console.WriteLine("7. Tim kiem");
            Console.WriteLine("0. Thoat");
        }

        // Kiểm tra người dùng đã nhập mảng chưa, nếu chưa thì báo lỗi
        static bool KiemTraDaNhapMang()
        {
            if (!daNhapMang)
            {
                Console.WriteLine("Ban chua nhap mang! Vui long chon '1. Nhap mang' truoc.");
                return false;
            }
            return true;
        }

        // Nhập lựa chọn menu, có kiểm tra dữ liệu nhập (không cho chương trình crash khi nhập chữ)
        static int NhapLuaChonMenu()
        {
            Console.Write("Chon chuc nang: ");
            string input = Console.ReadLine();
            int luaChon;
            // TryParse tra ve false neu nhap khong phai la so, tranh crash chuong trinh
            if (int.TryParse(input, out luaChon))
                return luaChon;
            else
                return -1; // gia tri khong hop le, se roi vao default trong switch
        }

        // Nhập một số nguyên bất kỳ, lặp lại đến khi nhập đúng định dạng số
        static int NhapSoNguyen(string message)
        {
            int soNguyen;
            bool hopLe;
            do
            {
                Console.Write(message);
                string input = Console.ReadLine();
                hopLe = int.TryParse(input, out soNguyen);
                if (!hopLe)
                    Console.WriteLine("Du lieu khong hop le, vui long nhap lai mot so nguyen.");
            } while (!hopLe);

            return soNguyen;
        }

        // Nhập một số nguyên dương (dùng cho số lượng phần tử n)
        static int NhapSoNguyenDuong(string message)
        {
            int soNguyen;
            do
            {
                soNguyen = NhapSoNguyen(message);
                if (soNguyen <= 0)
                    Console.WriteLine("So phai la so nguyen duong, vui long nhap lai.");
            } while (soNguyen <= 0);

            return soNguyen;
        }

        // Nhập mảng: nhập số lượng phần tử rồi nhập từng phần tử
        static int[] NhapMang()
        {
            int n = NhapSoNguyenDuong("Nhap so luong phan tu n: ");
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = NhapSoNguyen("Nhap phan tu thu " + (i + 1) + ": ");
            }

            return a;
        }

        // Xuất toàn bộ phần tử của mảng
        static void XuatMang(int[] a)
        {
            Console.Write("Mang: ");
            foreach (int phanTu in a)
            {
                Console.Write(phanTu + " ");
            }
            Console.WriteLine();
        }

        // Tính tổng các phần tử trong mảng
        static int TinhTong(int[] a)
        {
            int tong = 0;
            foreach (int phanTu in a)
            {
                tong += phanTu;
            }
            return tong;
        }

        // Tìm giá trị lớn nhất trong mảng
        static int TimMax(int[] a)
        {
            int max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max)
                    max = a[i];
            }
            return max;
        }

        // Tìm giá trị nhỏ nhất trong mảng
        static int TimMin(int[] a)
        {
            int min = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min)
                    min = a[i];
            }
            return min;
        }

        // Đếm số lượng phần tử chẵn
        static int DemChan(int[] a)
        {
            int demChan = 0;
            foreach (int phanTu in a)
            {
                if (phanTu % 2 == 0)
                    demChan++;
            }
            return demChan;
        }

        // Đếm số lượng phần tử lẻ
        static int DemLe(int[] a)
        {
            int demLe = 0;
            foreach (int phanTu in a)
            {
                if (phanTu % 2 != 0)
                    demLe++;
            }
            return demLe;
        }

        // Sắp xếp mảng tăng dần
        static void SapXepTangDan(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                int viTriNhoNhat = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < a[viTriNhoNhat])
                        viTriNhoNhat = j;
                }
                // Doi cho phan tu nho nhat tim duoc voi phan tu dang xet
                if (viTriNhoNhat != i)
                {
                    int tam = a[i];
                    a[i] = a[viTriNhoNhat];
                    a[viTriNhoNhat] = tam;
                }
            }
        }

        // Tìm kiếm giá trị x trong mảng, trả về vị trí đầu tiên tìm thấy (hoặc -1 nếu không có)
        static int TimKiem(int[] a, int x)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == x)
                    return i;
            }
            return -1;
        }
    }
}