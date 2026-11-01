using EduManager.BLL;
using EduManager.Models;

namespace EduManager.GUI
{

    public partial class FrmMonHoc : Form
    {
        private readonly MonHocBLL _bll = new MonHocBLL();

        public FrmMonHoc()
        {
            InitializeComponent();
            CauHinhLuoi();
            Load += FrmMonHoc_Load;
            dgvMonHoc.SelectionChanged += dgvMonHoc_SelectionChanged;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            txtTimKiem.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { btnTimKiem.PerformClick(); e.SuppressKeyPress = true; }
            };
        }



        private void CauHinhLuoi()
        {
            dgvMonHoc.AutoGenerateColumns = false;
            dgvMonHoc.Columns.Clear();
            dgvMonHoc.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(MonHoc.MaMonHoc), HeaderText = "Mã môn học", Width = 120 });
            dgvMonHoc.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(MonHoc.TenMonHoc), HeaderText = "Tên môn học", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvMonHoc.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(MonHoc.SoTinChi), HeaderText = "Số tín chỉ", Width = 90 });
            dgvMonHoc.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = nameof(MonHoc.TrangThai), HeaderText = "Còn sử dụng", Width = 100 });
        }

        private void FrmMonHoc_Load(object sender, EventArgs e) => LoadDanhSach();



        private void LoadDanhSach(List<MonHoc> ds = null)
        {
            try
            {
                dgvMonHoc.DataSource = ds ?? _bll.LayDanhSach();
                dgvMonHoc.ClearSelection();
                XoaForm();
            }
            catch (Exception)
            {
                HienLoi("Không thể tải danh sách môn học. Vui lòng kiểm tra kết nối SQL Server.");
            }
        }


        private MonHoc LayDuLieuTuForm() => new MonHoc
        {
            MaMonHoc = txtMaMonHoc.Text,
            TenMonHoc = txtTenMonHoc.Text,
            SoTinChi = (int)nudSoTinChi.Value,
            TrangThai = chkTrangThai.Checked
        };

        private void XoaForm()
        {
            txtMaMonHoc.Clear();
            txtTenMonHoc.Clear();
            nudSoTinChi.Value = nudSoTinChi.Minimum;
            chkTrangThai.Checked = true;
            txtMaMonHoc.ReadOnly = false;
            txtMaMonHoc.Focus();
        }

        private static void HienLoi(string msg) =>
            MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private static void HienThongBao(string msg) =>
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void dgvMonHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMonHoc.CurrentRow?.DataBoundItem is MonHoc mh && dgvMonHoc.CurrentRow.Selected)
            {
                txtMaMonHoc.Text = mh.MaMonHoc;
                txtTenMonHoc.Text = mh.TenMonHoc;
                nudSoTinChi.Value = Math.Clamp(mh.SoTinChi, (int)nudSoTinChi.Minimum, (int)nudSoTinChi.Maximum);
                chkTrangThai.Checked = mh.TrangThai;
                txtMaMonHoc.ReadOnly = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var kq = _bll.Them(LayDuLieuTuForm());
            if (kq.ThanhCong) { HienThongBao(kq.ThongBao); LoadDanhSach(); }
            else HienLoi(kq.ThongBao);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvMonHoc.CurrentRow == null || !dgvMonHoc.CurrentRow.Selected)
            {
                HienLoi("Vui lòng chọn môn học cần sửa trong danh sách.");
                return;
            }

            var kq = _bll.Sua(LayDuLieuTuForm());
            if (kq.ThanhCong) { HienThongBao(kq.ThongBao); LoadDanhSach(); }
            else HienLoi(kq.ThongBao);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMonHoc.Text))
            {
                HienLoi("Vui lòng chọn môn học cần xóa trong danh sách.");
                return;
            }

            var hoi = MessageBox.Show(
                $"Bạn có chắc muốn xóa môn học \"{txtMaMonHoc.Text}\" không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi != DialogResult.Yes) return;

            var kq = _bll.Xoa(txtMaMonHoc.Text);
            if (kq.ThanhCong) { HienThongBao(kq.ThongBao); LoadDanhSach(); }
            else HienLoi(kq.ThongBao);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                var ds = _bll.TimKiem(txtTimKiem.Text);
                LoadDanhSach(ds);
                if (ds.Count == 0) HienThongBao("Không tìm thấy môn học phù hợp.");
            }
            catch (Exception)
            {
                HienLoi("Không thể tìm kiếm. Vui lòng kiểm tra kết nối SQL Server.");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadDanhSach();
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {

        }
    }
}
