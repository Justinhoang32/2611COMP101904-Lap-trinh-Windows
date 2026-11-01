using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    /// <summary>Form đăng nhập. Trả DialogResult.OK khi đăng nhập thành công.</summary>
    public partial class FrmLogin : Form
    {
        // Tài khoản mẫu (dữ liệu trong bộ nhớ)
        private readonly List<User> _dsUser = new List<User>
        {
            new User { Username = "admin", Password = "123", HoTen = "Quản trị viên", VaiTro = "Admin" },
            new User { Username = "user",  Password = "123", HoTen = "Nhân viên bán hàng", VaiTro = "User" }
        };

        /// <summary>User đăng nhập thành công, FrmMain lấy thông tin từ property này.</summary>
        public User NguoiDung { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
            btnDangNhap.Click += btnDangNhap_Click;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (username.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                (username.Length == 0 ? txtUsername : txtPassword).Focus();
                return;
            }

            var user = _dsUser.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.",
                    "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            NguoiDung = user;
            DialogResult = DialogResult.OK;   // tự đóng form và trả kết quả
        }
    }
}
