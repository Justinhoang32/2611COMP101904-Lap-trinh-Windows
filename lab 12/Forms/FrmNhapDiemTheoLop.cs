using System.Data;
using System.Globalization;
using System.Text;
using Microsoft.Data.SqlClient;
using QLSinhVienLab12.DAL;

namespace QLSinhVienLab12.Forms
{
    /// <summary>
    /// Form nhập điểm theo lớp: chọn lớp, môn học, tải danh sách sinh viên,
    /// nhập điểm rồi lưu tất cả trong một transaction.
    /// </summary>
    public partial class FrmNhapDiemTheoLop : Form
    {
        private readonly KetQuaDAL _ketQuaDAL = new KetQuaDAL();
        private readonly BindingSource _ketQuaSource = new BindingSource();

        private DataTable _ketQuaTable;      // danh sách đang hiển thị trên lưới
        private string _maLopDangTai;        // lớp/môn của danh sách đang hiển thị,
        private string _maMonDangTai;        // dùng khi lưu để không lưu nhầm môn nếu người dùng đổi ComboBox

        public FrmNhapDiemTheoLop()
        {
            InitializeComponent();
            CauHinhLuoi();

            Load += FrmNhapDiemTheoLop_Load;
            btnTaiDanhSach.Click += btnTaiDanhSach_Click;
            btnLuuTatCa.Click += btnLuuTatCa_Click;
            txtLoc.TextChanged += txtLoc_TextChanged;

            dgvKetQua.CellParsing += dgvKetQua_CellParsing;
            dgvKetQua.CellValidating += dgvKetQua_CellValidating;
            dgvKetQua.CellEndEdit += dgvKetQua_CellEndEdit;
            dgvKetQua.DataError += (s, e) => e.ThrowException = false;
        }

        // ---------- Khởi tạo ----------

        private void CauHinhLuoi()
        {
            dgvKetQua.AutoGenerateColumns = false;
            dgvKetQua.Columns.Clear();
            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaSV", DataPropertyName = "MaSV", HeaderText = "Mã SV",
                ReadOnly = true, Width = 100, SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colHoTen", DataPropertyName = "HoTen", HeaderText = "Họ tên",
                ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDiem", DataPropertyName = "Diem", HeaderText = "Điểm (0 - 10)", Width = 120,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    // Luôn hiển thị dấu chấm thập phân, không phụ thuộc cấu hình ngôn ngữ của Windows
                    Format = "0.##",
                    FormatProvider = CultureInfo.InvariantCulture,
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });
            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGhiChu", DataPropertyName = "GhiChu", HeaderText = "Ghi chú",
                Width = 220, MaxInputLength = 255, SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvKetQua.DataSource = _ketQuaSource;
        }

        private void FrmNhapDiemTheoLop_Load(object sender, EventArgs e)
        {
            LoadComboBox();
        }

        /// <summary>Đưa danh sách lớp và môn học vào ComboBox (data binding).</summary>
        private void LoadComboBox()
        {
            try
            {
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";
                cboLop.DataSource = _ketQuaDAL.GetLop();

                cboMonHoc.DisplayMember = "TenMon";
                cboMonHoc.ValueMember = "MaMon";
                cboMonHoc.DataSource = _ketQuaDAL.GetMonHoc();

                SetStatus("Sẵn sàng. Chọn lớp và môn học rồi bấm Tải danh sách.");
            }
            catch (Exception ex)
            {
                btnTaiDanhSach.Enabled = false;
                btnLuuTatCa.Enabled = false;
                SetStatus("Không kết nối được cơ sở dữ liệu.", true);
                MessageBox.Show(
                    "Không thể kết nối cơ sở dữ liệu.\n\n" +
                    "Hãy kiểm tra SQL Server đang chạy, đã chạy script QLSinhVienLab12.sql " +
                    "và chuỗi kết nối trong DAL/Database.cs.\n\nChi tiết: " + ex.Message,
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- Tải danh sách ----------

        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            string maLop = cboLop.SelectedValue?.ToString() ?? string.Empty;
            string maMon = cboMonHoc.SelectedValue?.ToString() ?? string.Empty;

            if (maLop.Length == 0 || maMon.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp và môn học.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CoThayDoiChuaLuu())
            {
                var hoi = MessageBox.Show(
                    "Có điểm đã nhập nhưng chưa lưu. Tải danh sách mới sẽ mất các thay đổi này.\nBạn có muốn tiếp tục?",
                    "Thay đổi chưa lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hoi != DialogResult.Yes) return;
            }

            NapDanhSach(maLop, maMon);
        }

        /// <summary>Gọi DAL lấy danh sách và gán vào BindingSource.</summary>
        private void NapDanhSach(string maLop, string maMon)
        {
            try
            {
                DataTable table = _ketQuaDAL.GetKetQuaByLopMon(maLop, maMon);

                txtLoc.Text = string.Empty;
                _ketQuaSource.DataSource = table;
                _ketQuaSource.Filter = null;

                _ketQuaTable = table;
                _maLopDangTai = maLop;
                _maMonDangTai = maMon;

                CapNhatThongKe();
                SetStatus($"Đã tải {table.Rows.Count} sinh viên - lớp {cboLop.Text}, môn {cboMonHoc.Text}.");
            }
            catch (Exception ex)
            {
                SetStatus("Không tải được danh sách.", true);
                MessageBox.Show("Không thể tải danh sách sinh viên.\n\nChi tiết: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CoThayDoiChuaLuu()
        {
            if (_ketQuaTable == null) return false;
            dgvKetQua.EndEdit();
            _ketQuaSource.EndEdit();
            return _ketQuaTable.GetChanges() != null;
        }

        // ---------- Lưu tất cả ----------

        private void btnLuuTatCa_Click(object sender, EventArgs e)
        {
            LuuTatCa();
        }

        private void LuuTatCa()
        {
            if (_ketQuaTable == null || _ketQuaTable.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có danh sách để lưu. Hãy chọn lớp, môn học và bấm Tải danh sách.",
                    "Chưa có dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đẩy giá trị đang sửa trên lưới về DataTable
            if (!dgvKetQua.EndEdit()) return;
            _ketQuaSource.EndEdit();

            if (!ValidateData(_ketQuaTable, out string message, out int rowIndex))
            {
                SetStatus(message, true);
                MessageBox.Show(message, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ChonODiem(rowIndex);
                return;
            }

            try
            {
                int count = _ketQuaDAL.SaveAll(_maMonDangTai, _ketQuaTable);

                // Tải lại từ database để hiển thị đúng dữ liệu đã lưu
                NapDanhSach(_maLopDangTai, _maMonDangTai);
                SetStatus($"Đã lưu thành công {count} dòng.");
                MessageBox.Show($"Đã lưu thành công {count} dòng.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                SetStatus("Lưu thất bại. Đã hoàn tác toàn bộ (rollback).", true);
                MessageBox.Show(
                    "Không thể lưu dữ liệu. Toàn bộ thao tác đã được hoàn tác (rollback), " +
                    "dữ liệu trong cơ sở dữ liệu không bị thay đổi.\n\nChi tiết: " + ex.Message,
                    "Lưu thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Kiểm tra điểm: không rỗng, là số, nằm trong khoảng 0..10.
        /// Nếu bật chkDemoRollback thì bỏ qua kiểm tra khoảng điểm ở form
        /// để database tự chặn và kích hoạt rollback (dùng để demo).
        /// </summary>
        private bool ValidateData(DataTable table, out string message, out int rowIndex)
        {
            message = string.Empty;
            rowIndex = -1;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                string maSV = row["MaSV"].ToString();
                string hoTen = row["HoTen"].ToString();

                if (row.IsNull("Diem"))
                {
                    message = $"Điểm của sinh viên {maSV} ({hoTen}) không được để trống.";
                    rowIndex = i;
                    return false;
                }

                decimal diem = Convert.ToDecimal(row["Diem"]);
                if (!chkDemoRollback.Checked && (diem < 0 || diem > 10))
                {
                    message = $"Điểm của sinh viên {maSV} ({hoTen}) phải nằm trong khoảng từ 0 đến 10.";
                    rowIndex = i;
                    return false;
                }
            }
            return true;
        }

        /// <summary>Đưa con trỏ tới ô điểm của dòng lỗi.</summary>
        private void ChonODiem(int rowIndex)
        {
            txtLoc.Text = string.Empty;   // bỏ lọc để chỉ số dòng trên lưới khớp với DataTable
            if (rowIndex < 0 || rowIndex >= dgvKetQua.Rows.Count) return;

            dgvKetQua.Rows[rowIndex].ErrorText = "Điểm không hợp lệ";
            dgvKetQua.CurrentCell = dgvKetQua.Rows[rowIndex].Cells["colDiem"];
            dgvKetQua.BeginEdit(true);
        }

        // ---------- Nhập điểm trên lưới ----------

        /// <summary>Chuyển chữ người dùng gõ thành số: chấp nhận cả 8.5 và 8,5; ô trống là NULL.</summary>
        private void dgvKetQua_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (dgvKetQua.Columns[e.ColumnIndex].Name != "colDiem") return;

            string text = (e.Value?.ToString() ?? string.Empty).Trim();
            if (text.Length == 0)
            {
                e.Value = DBNull.Value;
                e.ParsingApplied = true;
            }
            else if (TryParseDiem(text, out decimal diem))
            {
                e.Value = diem;
                e.ParsingApplied = true;
            }
        }

        /// <summary>Không cho rời ô điểm nếu nội dung không phải là số.</summary>
        private void dgvKetQua_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvKetQua.Columns[e.ColumnIndex].Name != "colDiem") return;

            string text = (e.FormattedValue?.ToString() ?? string.Empty).Trim();
            if (text.Length > 0 && !TryParseDiem(text, out _))
            {
                dgvKetQua.Rows[e.RowIndex].ErrorText = "Điểm phải là một số (ví dụ 8.5).";
                SetStatus("Điểm phải là một số (ví dụ 8.5).", true);
                e.Cancel = true;
            }
        }

        private void dgvKetQua_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvKetQua.Rows[e.RowIndex].ErrorText = string.Empty;
            CapNhatThongKe();
        }

        private static bool TryParseDiem(string text, out decimal diem)
        {
            return decimal.TryParse(text.Replace(',', '.'),
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture, out diem);
        }

        // ---------- Mở rộng: lọc và thống kê ----------

        private void txtLoc_TextChanged(object sender, EventArgs e)
        {
            if (_ketQuaTable == null) return;

            string keyword = txtLoc.Text.Trim();
            if (keyword.Length == 0)
            {
                _ketQuaSource.Filter = null;
                return;
            }

            string safe = EscapeLikeValue(keyword);
            _ketQuaSource.Filter = $"HoTen LIKE '%{safe}%' OR MaSV LIKE '%{safe}%'";
        }

        /// <summary>Thoát các ký tự đặc biệt trong biểu thức lọc của DataView.</summary>
        private static string EscapeLikeValue(string value)
        {
            var sb = new StringBuilder();
            foreach (char c in value)
            {
                if (c == '\'') sb.Append("''");
                else if (c is '[' or ']' or '*' or '%') sb.Append('[').Append(c).Append(']');
                else sb.Append(c);
            }
            return sb.ToString();
        }

        private void CapNhatThongKe()
        {
            if (_ketQuaTable == null)
            {
                lblThongKe.Text = string.Empty;
                return;
            }

            int total = _ketQuaTable.Rows.Count;
            int daCoDiem = Convert.ToInt32(_ketQuaTable.Compute("COUNT(Diem)", string.Empty));
            object avg = _ketQuaTable.Compute("AVG(Diem)", string.Empty);
            string avgText = avg == DBNull.Value
                ? "-"
                : Convert.ToDecimal(avg).ToString("0.00", CultureInfo.InvariantCulture);

            lblThongKe.Text = $"Sĩ số: {total}   |   Đã có điểm: {daCoDiem}   |   Điểm trung bình: {avgText}";
        }

        private void SetStatus(string text, bool isError = false)
        {
            lblTrangThai.Text = text;
            lblTrangThai.ForeColor = isError ? Color.Firebrick : SystemColors.ControlText;
        }
    }
}
