using System.ComponentModel;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    public partial class FrmMain : Form
    {
        private readonly User _user;

        private readonly BindingList<Product> _sanPham = new BindingList<Product>
        {
            new Product { MaSanPham = "SP001", TenSanPham = "Nước suối 500ml", LoaiSanPham = "Đồ uống", DonGia = 5000, SoLuong = 100 },
            new Product { MaSanPham = "SP002", TenSanPham = "Mì gói", LoaiSanPham = "Thực phẩm", DonGia = 4500, SoLuong = 200 },
            new Product { MaSanPham = "SP003", TenSanPham = "Bánh quy", LoaiSanPham = "Bánh kẹo", DonGia = 15000, SoLuong = 50 },
            new Product { MaSanPham = "SP004", TenSanPham = "Bàn chải đánh răng", LoaiSanPham = "Gia dụng", DonGia = 22000, SoLuong = 30 }
        };

        private readonly BindingList<Customer> _khachHang = new BindingList<Customer>
        {
            new Customer { MaKhachHang = "KH001", HoTen = "Nguyễn Văn An", SoDienThoai = "0901234567", LoaiKhachHang = "Thường" },
            new Customer { MaKhachHang = "KH002", HoTen = "Trần Thị Bình", SoDienThoai = "0912345678", LoaiKhachHang = "VIP" },
            new Customer { MaKhachHang = "KH003", HoTen = "Lê Văn Cường", SoDienThoai = "0987654321", LoaiKhachHang = "Thân thiết" }
        };

        public bool DangXuat { get; private set; }

        public FrmMain(User user)
        {
            InitializeComponent();
            _user = user;

            lblNguoiDung.Text = "Người dùng: " + user.HoTen;
            lblVaiTro.Text = "Vai trò: " + user.VaiTro;
            CapNhatThoiGian();

            timer1.Tick += (s, e) => CapNhatThoiGian();
            timer1.Start();

            mnuSanPham.Click += (s, e) => MoFormCon(() => new FrmProduct(_sanPham));
            mnuKhachHang.Click += (s, e) => MoFormCon(() => new FrmCustomer(_khachHang));
            mnuGioiThieu.Click += (s, e) => { using var f = new FrmAbout(); f.ShowDialog(this); };
            mnuDangXuat.Click += mnuDangXuat_Click;
            mnuThoat.Click += (s, e) => Close();
            FormClosing += FrmMain_FormClosing;
        }

        private void CapNhatThoiGian() =>
            lblThoiGian.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        /// <summary>
        /// Mở Form con MDI. Nếu Form cùng loại đang mở thì kích hoạt Form cũ, không tạo mới.
        /// </summary>
        private void MoFormCon<T>(Func<T> taoMoi) where T : Form
        {
            var formDangMo = MdiChildren.OfType<T>().FirstOrDefault();
            if (formDangMo != null)
            {
                if (formDangMo.WindowState == FormWindowState.Minimized)
                    formDangMo.WindowState = FormWindowState.Normal;
                formDangMo.Activate();
                return;
            }

            var f = taoMoi();
            f.MdiParent = this;
            f.Show();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            var kq = MessageBox.Show("Bạn có chắc muốn đăng xuất không?", "Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq != DialogResult.Yes) return;
            DangXuat = true;
            Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DangXuat) return;   // đăng xuất đã được xác nhận
            var kq = MessageBox.Show("Bạn có chắc muốn thoát chương trình không?", "Xác nhận thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq != DialogResult.Yes) e.Cancel = true;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
