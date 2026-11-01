using System.ComponentModel;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    public partial class FrmProduct : Form
    {
        private readonly BindingList<Product> _ds;
        private bool _dangNap;   

        public FrmProduct(BindingList<Product> ds)
        {
            InitializeComponent();
            _ds = ds;
            CauHinhLuoi();
            cboLoaiSP.Items.AddRange(new object[] { "Đồ uống", "Thực phẩm", "Bánh kẹo", "Gia dụng", "Khác" });

            Load += (s, e) => HienThi(_ds);
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            dgvSanPham.SelectionChanged += dgvSanPham_SelectionChanged;
            txtTimKiem.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { btnTimKiem.PerformClick(); e.SuppressKeyPress = true; }
            };
        }


        private void CauHinhLuoi()
        {
            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.Columns.Clear();
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Product.MaSanPham), HeaderText = "Mã SP", Width = 90 });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Product.TenSanPham), HeaderText = "Tên sản phẩm", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Product.LoaiSanPham), HeaderText = "Loại", Width = 120 });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Product.DonGia), HeaderText = "Đơn giá", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Product.SoLuong), HeaderText = "Số lượng", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight } });
        }

        private void HienThi(IEnumerable<Product> ds)
        {
            _dangNap = true;
            dgvSanPham.DataSource = ds.ToList();
            dgvSanPham.ClearSelection();
            _dangNap = false;
        }

        private void LamSachForm()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            cboLoaiSP.SelectedIndex = -1;
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtMaSP.ReadOnly = false;
            txtMaSP.Focus();
        }

        private bool DangChonDong() =>
            dgvSanPham.CurrentRow != null && dgvSanPham.CurrentRow.Selected;

        private static void Canh(string msg) =>
            MessageBox.Show(msg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private static void ThongBao(string msg) =>
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        /// <summary>Đọc và kiểm tra dữ liệu nhập. Trả false (kèm cảnh báo) nếu không hợp lệ.</summary>
        private bool DocForm(out Product sp)
        {
            sp = null;
            string ma = txtMaSP.Text.Trim();
            string ten = txtTenSP.Text.Trim();
            string loai = cboLoaiSP.Text.Trim();

            if (ma.Length == 0) { Canh("Mã sản phẩm không được để trống."); txtMaSP.Focus(); return false; }
            if (ten.Length == 0) { Canh("Tên sản phẩm không được để trống."); txtTenSP.Focus(); return false; }
            if (loai.Length == 0) { Canh("Vui lòng chọn hoặc nhập loại sản phẩm."); cboLoaiSP.Focus(); return false; }
            if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal gia))
            { Canh("Đơn giá phải là một số hợp lệ."); txtDonGia.Focus(); return false; }
            if (gia < 0) { Canh("Đơn giá không được âm."); txtDonGia.Focus(); return false; }
            if (!int.TryParse(txtSoLuong.Text.Trim(), out int sl))
            { Canh("Số lượng phải là một số nguyên hợp lệ."); txtSoLuong.Focus(); return false; }
            if (sl < 0) { Canh("Số lượng không được âm."); txtSoLuong.Focus(); return false; }

            sp = new Product { MaSanPham = ma, TenSanPham = ten, LoaiSanPham = loai, DonGia = gia, SoLuong = sl };
            return true;
        }

        private Product TimTheoMa(string ma) =>
            _ds.FirstOrDefault(p => string.Equals(p.MaSanPham, ma, StringComparison.OrdinalIgnoreCase));


        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangNap || !DangChonDong()) return;
            if (dgvSanPham.CurrentRow.DataBoundItem is Product p)
            {
                txtMaSP.Text = p.MaSanPham;
                txtTenSP.Text = p.TenSanPham;
                cboLoaiSP.Text = p.LoaiSanPham;
                txtDonGia.Text = p.DonGia.ToString("0.##");
                txtSoLuong.Text = p.SoLuong.ToString();
                txtMaSP.ReadOnly = true;   
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!DocForm(out Product sp)) return;
            if (TimTheoMa(sp.MaSanPham) != null)
            { Canh($"Mã sản phẩm \"{sp.MaSanPham}\" đã tồn tại. Vui lòng nhập mã khác."); txtMaSP.Focus(); return; }

            _ds.Add(sp);
            HienThi(_ds);
            LamSachForm();
            ThongBao("Thêm sản phẩm thành công.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!DangChonDong()) { Canh("Vui lòng chọn sản phẩm cần sửa trong danh sách."); return; }
            if (!DocForm(out Product sp)) return;

            var goc = TimTheoMa(sp.MaSanPham);
            if (goc == null) { Canh("Không tìm thấy sản phẩm cần sửa."); return; }

            goc.TenSanPham = sp.TenSanPham;
            goc.LoaiSanPham = sp.LoaiSanPham;
            goc.DonGia = sp.DonGia;
            goc.SoLuong = sp.SoLuong;
            HienThi(_ds);
            LamSachForm();
            ThongBao("Cập nhật sản phẩm thành công.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!DangChonDong()) { Canh("Vui lòng chọn sản phẩm cần xóa trong danh sách."); return; }

            var goc = TimTheoMa(txtMaSP.Text.Trim());
            if (goc == null) { Canh("Không tìm thấy sản phẩm cần xóa."); return; }

            var kq = MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm \"{goc.TenSanPham}\" không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq != DialogResult.Yes) return;

            _ds.Remove(goc);
            HienThi(_ds);
            LamSachForm();
            ThongBao("Xóa sản phẩm thành công.");
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
                : _ds.Where(p => p.MaSanPham.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase)
                              || p.TenSanPham.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase)).ToList();

            HienThi(kq);
            LamSachForm();
            if (kq.Count == 0) ThongBao("Không tìm thấy sản phẩm phù hợp.");
        }
    }
}
