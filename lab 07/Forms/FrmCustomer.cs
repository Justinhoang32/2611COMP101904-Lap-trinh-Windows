using System.ComponentModel;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    /// <summary>Form quản lý khách hàng: thêm, sửa, xóa, tìm kiếm và hiển thị.</summary>
    public partial class FrmCustomer : Form
    {
        private readonly BindingList<Customer> _ds;
        private bool _dangNap;

        public FrmCustomer(BindingList<Customer> ds)
        {
            InitializeComponent();
            _ds = ds;
            CauHinhLuoi();
            cboLoaiKH.Items.AddRange(new object[] { "Thường", "VIP", "Thân thiết" });

            Load += (s, e) => HienThi(_ds);
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            dgvKhachHang.SelectionChanged += dgvKhachHang_SelectionChanged;
            txtTimKiem.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { btnTimKiem.PerformClick(); e.SuppressKeyPress = true; }
            };
        }

        private void CauHinhLuoi()
        {
            dgvKhachHang.AutoGenerateColumns = false;
            dgvKhachHang.Columns.Clear();
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Customer.MaKhachHang), HeaderText = "Mã KH", Width = 90 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Customer.HoTen), HeaderText = "Họ tên", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Customer.SoDienThoai), HeaderText = "Số điện thoại", Width = 140 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Customer.LoaiKhachHang), HeaderText = "Loại khách hàng", Width = 140 });
        }

        private void HienThi(IEnumerable<Customer> ds)
        {
            _dangNap = true;
            dgvKhachHang.DataSource = ds.ToList();
            dgvKhachHang.ClearSelection();
            _dangNap = false;
        }

        private void LamSachForm()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            cboLoaiKH.SelectedIndex = -1;
            txtMaKH.ReadOnly = false;
            txtMaKH.Focus();
        }

        private bool DangChonDong() =>
            dgvKhachHang.CurrentRow != null && dgvKhachHang.CurrentRow.Selected;

        private static void Canh(string msg) =>
            MessageBox.Show(msg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private static void ThongBao(string msg) =>
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private bool DocForm(out Customer kh)
        {
            kh = null;
            string ma = txtMaKH.Text.Trim();
            string ten = txtHoTen.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            string loai = cboLoaiKH.Text.Trim();

            if (ma.Length == 0) { Canh("Mã khách hàng không được để trống."); txtMaKH.Focus(); return false; }
            if (ten.Length == 0) { Canh("Họ tên không được để trống."); txtHoTen.Focus(); return false; }
            if (sdt.Length == 0) { Canh("Số điện thoại không được để trống."); txtSoDienThoai.Focus(); return false; }
            if (!sdt.All(char.IsDigit) || sdt.Length < 9 || sdt.Length > 11)
            { Canh("Số điện thoại chỉ gồm chữ số và dài từ 9 đến 11 số."); txtSoDienThoai.Focus(); return false; }
            if (loai.Length == 0) { Canh("Vui lòng chọn loại khách hàng."); cboLoaiKH.Focus(); return false; }

            kh = new Customer { MaKhachHang = ma, HoTen = ten, SoDienThoai = sdt, LoaiKhachHang = loai };
            return true;
        }

        private Customer TimTheoMa(string ma) =>
            _ds.FirstOrDefault(c => string.Equals(c.MaKhachHang, ma, StringComparison.OrdinalIgnoreCase));

        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangNap || !DangChonDong()) return;
            if (dgvKhachHang.CurrentRow.DataBoundItem is Customer c)
            {
                txtMaKH.Text = c.MaKhachHang;
                txtHoTen.Text = c.HoTen;
                txtSoDienThoai.Text = c.SoDienThoai;
                cboLoaiKH.Text = c.LoaiKhachHang;
                txtMaKH.ReadOnly = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!DocForm(out Customer kh)) return;
            if (TimTheoMa(kh.MaKhachHang) != null)
            { Canh($"Mã khách hàng \"{kh.MaKhachHang}\" đã tồn tại. Vui lòng nhập mã khác."); txtMaKH.Focus(); return; }

            _ds.Add(kh);
            HienThi(_ds);
            LamSachForm();
            ThongBao("Thêm khách hàng thành công.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!DangChonDong()) { Canh("Vui lòng chọn khách hàng cần sửa trong danh sách."); return; }
            if (!DocForm(out Customer kh)) return;

            var goc = TimTheoMa(kh.MaKhachHang);
            if (goc == null) { Canh("Không tìm thấy khách hàng cần sửa."); return; }

            goc.HoTen = kh.HoTen;
            goc.SoDienThoai = kh.SoDienThoai;
            goc.LoaiKhachHang = kh.LoaiKhachHang;
            HienThi(_ds);
            LamSachForm();
            ThongBao("Cập nhật khách hàng thành công.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!DangChonDong()) { Canh("Vui lòng chọn khách hàng cần xóa trong danh sách."); return; }

            var goc = TimTheoMa(txtMaKH.Text.Trim());
            if (goc == null) { Canh("Không tìm thấy khách hàng cần xóa."); return; }

            var kq = MessageBox.Show($"Bạn có chắc muốn xóa khách hàng \"{goc.HoTen}\" không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq != DialogResult.Yes) return;

            _ds.Remove(goc);
            HienThi(_ds);
            LamSachForm();
            ThongBao("Xóa khách hàng thành công.");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LamSachForm();
            HienThi(_ds);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            var kq = tuKhoa.Length == 0
                ? _ds.ToList()
                : _ds.Where(c => c.MaKhachHang.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase)
                              || c.HoTen.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase)
                              || c.SoDienThoai.Contains(tuKhoa)).ToList();

            HienThi(kq);
            LamSachForm();
            if (kq.Count == 0) ThongBao("Không tìm thấy khách hàng phù hợp.");
        }
    }
}
