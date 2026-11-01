using EduManagerMVP.Models;
using EduManagerMVP.Presenters;
using EduManagerMVP.Repositories;

namespace EduManagerMVP.Views
{
    /// <summary>
    /// View: Form implements IMonHocView. Button Click chỉ gọi Presenter.
    /// </summary>
    public partial class FrmMonHoc : Form, IMonHocView
    {
        private readonly MonHocPresenter _presenter;
        private bool _dangNap;   // true khi đang nạp lưới, tránh kích hoạt sự kiện chọn dòng

        public FrmMonHoc()
        {
            InitializeComponent();
            CauHinhLuoi();
            _presenter = new MonHocPresenter(this, new MonHocRepository());

            Load += (s, e) => _presenter.LoadDanhSach();
            btnThem.Click += (s, e) => _presenter.ThemMonHoc();
            btnXoa.Click += (s, e) => _presenter.XoaMonHoc();
            btnTimKiem.Click += (s, e) => _presenter.TimKiem();
            btnLamMoi.Click += (s, e) => _presenter.LamMoi();
            dgvMonHoc.SelectionChanged += dgvMonHoc_SelectionChanged;
            txtTimKiem.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { _presenter.TimKiem(); e.SuppressKeyPress = true; }
            };
        }

        // ---------- Cài đặt IMonHocView ----------

        public string MaMonHoc { get => txtMaMonHoc.Text; set => txtMaMonHoc.Text = value; }
        public string TenMonHoc { get => txtTenMonHoc.Text; set => txtTenMonHoc.Text = value; }
        public string SoTinChi { get => txtSoTinChi.Text; set => txtSoTinChi.Text = value; }
        public bool TrangThai { get => chkTrangThai.Checked; set => chkTrangThai.Checked = value; }
        public string TuKhoa { get => txtTimKiem.Text; set => txtTimKiem.Text = value; }

        public void HienThiDanhSach(List<MonHoc> ds)
        {
            _dangNap = true;
            dgvMonHoc.DataSource = ds;
            dgvMonHoc.ClearSelection();
            _dangNap = false;
        }

        public void XoaForm()
        {
            txtMaMonHoc.Clear();
            txtTenMonHoc.Clear();
            txtSoTinChi.Clear();
            chkTrangThai.Checked = true;
            txtMaMonHoc.Focus();
        }

        public void HienThongBao(string noiDung) =>
            MessageBox.Show(noiDung, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public void HienLoi(string noiDung) =>
            MessageBox.Show(noiDung, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public bool XacNhan(string cauHoi) =>
            MessageBox.Show(cauHoi, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        // ---------- Hỗ trợ giao diện ----------

        private void CauHinhLuoi()
        {
            dgvMonHoc.AutoGenerateColumns = false;
            dgvMonHoc.Columns.Clear();
            dgvMonHoc.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(MonHoc.MaMonHoc), HeaderText = "Mã môn học", Width = 120 });
            dgvMonHoc.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(MonHoc.TenMonHoc), HeaderText = "Tên môn học", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvMonHoc.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(MonHoc.SoTinChi), HeaderText = "Số tín chỉ", Width = 90 });
            dgvMonHoc.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = nameof(MonHoc.TrangThai), HeaderText = "Còn sử dụng", Width = 100 });
        }

        private void dgvMonHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangNap) return;
            if (dgvMonHoc.CurrentRow != null && dgvMonHoc.CurrentRow.Selected
                && dgvMonHoc.CurrentRow.DataBoundItem is MonHoc mh)
            {
                _presenter.ChonMonHoc(mh.MaMonHoc);
            }
        }
    }
}
