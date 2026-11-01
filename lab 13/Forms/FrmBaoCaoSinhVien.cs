using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudentReportDemo.Models;

namespace StudentReportDemo.Forms
{
    public partial class FrmBaoCaoSinhVien : Form
    {
        // Dữ liệu gốc (dữ liệu mẫu)
        private List<SinhVien> danhSachSinhVien = new List<SinhVien>();

        public FrmBaoCaoSinhVien()
        {
            InitializeComponent();
        }

        // Chức năng 1: mở Form thì load dữ liệu và ComboBox
        private void FrmBaoCaoSinhVien_Load(object sender, EventArgs e)
        {
            TaoDuLieuMau();
            LoadComboBox();
            XemBaoCao();
        }

        // ================== Dữ liệu và ComboBox ==================

        // Tạo 12 sinh viên thuộc 3 lớp
        private void TaoDuLieuMau()
        {
            danhSachSinhVien = new List<SinhVien>
            {
                new SinhVien { MaSV = "SV001", HoTen = "Nguyễn Văn An",    MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 8.2 },
                new SinhVien { MaSV = "SV002", HoTen = "Trần Thị Bình",    MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 6.5 },
                new SinhVien { MaSV = "SV003", HoTen = "Lê Minh Cường",    MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 4.8 },
                new SinhVien { MaSV = "SV004", HoTen = "Phạm Thanh Dung",  MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 9.1 },
                new SinhVien { MaSV = "SV005", HoTen = "Hoàng Quốc Huy",   MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 7.4 },
                new SinhVien { MaSV = "SV006", HoTen = "Võ Gia Khang",     MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 3.9 },
                new SinhVien { MaSV = "SV007", HoTen = "Đặng Minh Khôi",   MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 5.5 },
                new SinhVien { MaSV = "SV008", HoTen = "Bùi Thảo Linh",    MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 8.0 },
                new SinhVien { MaSV = "SV009", HoTen = "Ngô Tuấn Minh",    MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 6.0 },
                new SinhVien { MaSV = "SV010", HoTen = "Đỗ Bảo Ngọc",      MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 9.3 },
                new SinhVien { MaSV = "SV011", HoTen = "Huỳnh Gia Phúc",   MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 4.2 },
                new SinhVien { MaSV = "SV012", HoTen = "Mai Anh Thư",      MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 7.8 }
            };
        }

        // Load danh sách lớp (dùng LINQ) vào cboLop và các lựa chọn vào cboKetQua
        private void LoadComboBox()
        {
            // GroupBy để mỗi lớp chỉ xuất hiện một lần, OrderBy để sắp xếp theo mã lớp
            List<LopItem> dsLop = danhSachSinhVien
                .GroupBy(sv => sv.MaLop)
                .Select(g => new LopItem { MaLop = g.Key, TenLop = g.First().TenLop })
                .OrderBy(lop => lop.MaLop)
                .ToList();

            // Thêm lựa chọn "Tất cả lớp" ở đầu danh sách
            dsLop.Insert(0, new LopItem { MaLop = "", TenLop = "Tất cả lớp" });

            cboLop.DataSource = dsLop;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";

            cboKetQua.Items.Clear();
            cboKetQua.Items.Add("Tất cả");
            cboKetQua.Items.Add("Đạt");
            cboKetQua.Items.Add("Không đạt");
            cboKetQua.SelectedIndex = 0;
        }

        // ================== Xem báo cáo ==================

        // Chức năng 2, 3, 6: lọc theo lớp, kết quả, từ khóa; sắp xếp giảm dần theo điểm
        private void XemBaoCao()
        {
            string maLop = cboLop.SelectedValue?.ToString() ?? "";
            string ketQua = cboKetQua.SelectedItem?.ToString() ?? "Tất cả";
            string tuKhoa = txtTuKhoa.Text.Trim().ToLower();

            List<SinhVien> dsLoc = LocSinhVien(maLop, ketQua, tuKhoa);

            // Chọn các cột cần hiển thị
            List<DongBaoCao> baoCao = dsLoc
                .Select(sv => new DongBaoCao
                {
                    MaSV = sv.MaSV,
                    HoTen = sv.HoTen,
                    TenLop = sv.TenLop,
                    Diem = sv.Diem,
                    KetQua = sv.KetQua
                })
                .ToList();

            dgvBaoCao.DataSource = baoCao;
            DatTieuDeCot();
            CapNhatThongKe(dsLoc);

            if (baoCao.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu phù hợp với điều kiện đã chọn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Lọc + sắp xếp bằng LINQ
        private List<SinhVien> LocSinhVien(string maLop, string ketQua, string tuKhoa)
        {
            IEnumerable<SinhVien> query = danhSachSinhVien;

            if (maLop != "")
            {
                query = query.Where(sv => sv.MaLop == maLop);
            }

            if (ketQua == "Đạt")
            {
                query = query.Where(sv => sv.Diem >= 5);
            }
            else if (ketQua == "Không đạt")
            {
                query = query.Where(sv => sv.Diem < 5);
            }

            if (tuKhoa != "")
            {
                query = query.Where(sv => sv.MaSV.ToLower().Contains(tuKhoa)
                                       || sv.HoTen.ToLower().Contains(tuKhoa));
            }

            return query
                .OrderByDescending(sv => sv.Diem)
                .ThenBy(sv => sv.HoTen)
                .ToList();
        }

        // Đổi tiêu đề cột cho dễ đọc
        private void DatTieuDeCot()
        {
            DoiTieuDe("MaSV", "Mã SV");
            DoiTieuDe("HoTen", "Họ tên");
            DoiTieuDe("TenLop", "Tên lớp");
            DoiTieuDe("Diem", "Điểm");
            DoiTieuDe("KetQua", "Kết quả");
            DoiTieuDe("MaLop", "Mã lớp");
            DoiTieuDe("SoSinhVien", "Số sinh viên");
            DoiTieuDe("SoDat", "Số đạt");
            DoiTieuDe("SoKhongDat", "Số không đạt");
            DoiTieuDe("DiemTB", "Điểm TB");

            if (dgvBaoCao.Columns.Contains("Diem"))
                dgvBaoCao.Columns["Diem"].DefaultCellStyle.Format = "0.0";
            if (dgvBaoCao.Columns.Contains("DiemTB"))
                dgvBaoCao.Columns["DiemTB"].DefaultCellStyle.Format = "0.00";
        }

        private void DoiTieuDe(string tenCot, string tieuDe)
        {
            if (dgvBaoCao.Columns.Contains(tenCot))
            {
                dgvBaoCao.Columns[tenCot].HeaderText = tieuDe;
            }
        }

        // Hiển thị tổng số, số đạt, số không đạt, điểm trung bình của danh sách truyền vào
        private void CapNhatThongKe(List<SinhVien> ds)
        {
            int tong = ds.Count;
            int soDat = ds.Count(sv => sv.Diem >= 5);
            int soKhongDat = ds.Count(sv => sv.Diem < 5);
            double diemTB = tong > 0 ? ds.Average(sv => sv.Diem) : 0;   // tránh lỗi khi danh sách rỗng

            lblThongKe.Text = $"Tổng số sinh viên: {tong} | Đạt: {soDat} | Không đạt: {soKhongDat} | Điểm TB: {diemTB:0.00}";
        }

        // ================== Thống kê theo lớp ==================

        // Chức năng 4: số lượng sinh viên và điểm trung bình từng lớp
        private void ThongKeTheoLop()
        {
            List<ThongKeLop> thongKe = danhSachSinhVien
                .GroupBy(sv => new { sv.MaLop, sv.TenLop })
                .Select(g => new ThongKeLop
                {
                    MaLop = g.Key.MaLop,
                    TenLop = g.Key.TenLop,
                    SoSinhVien = g.Count(),
                    SoDat = g.Count(sv => sv.Diem >= 5),
                    SoKhongDat = g.Count(sv => sv.Diem < 5),
                    DiemTB = g.Average(sv => sv.Diem)
                })
                .OrderBy(t => t.MaLop)
                .ToList();

            dgvBaoCao.DataSource = thongKe;
            DatTieuDeCot();

            // Label hiển thị số liệu của toàn bộ sinh viên
            CapNhatThongKe(danhSachSinhVien);

            if (thongKe.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để thống kê!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ================== Xuất file ==================

        // Chức năng 5: lưu dữ liệu đang hiển thị trên DataGridView ra CSV hoặc TXT
        private void XuatFile()
        {
            if (dgvBaoCao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất file!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using SaveFileDialog hopThoaiLuu = new SaveFileDialog();
            hopThoaiLuu.Filter = "File CSV (*.csv)|*.csv|File văn bản (*.txt)|*.txt";
            hopThoaiLuu.FileName = "BaoCaoSinhVien";
            hopThoaiLuu.Title = "Xuất báo cáo";

            if (hopThoaiLuu.ShowDialog() != DialogResult.OK) return;

            try
            {
                bool laCsv = Path.GetExtension(hopThoaiLuu.FileName).ToLower() == ".csv";
                string dauTach = laCsv ? "," : "\t";

                List<string> cacDong = TaoNoiDungFile(dauTach, laCsv);

                // UTF-8 có BOM để Excel mở file CSV không bị lỗi tiếng Việt
                File.WriteAllLines(hopThoaiLuu.FileName, cacDong, new UTF8Encoding(true));

                MessageBox.Show("Xuất file thành công!\n" + hopThoaiLuu.FileName, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Không ghi được file (file đang được mở ở chương trình khác?):\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Không có quyền ghi vào vị trí đã chọn, hãy chọn thư mục khác!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tạo danh sách các dòng văn bản từ DataGridView (dòng đầu là tiêu đề cột)
        private List<string> TaoNoiDungFile(string dauTach, bool laCsv)
        {
            List<DataGridViewColumn> cacCot = dgvBaoCao.Columns
                .Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .ToList();

            List<string> cacDong = new List<string>();
            cacDong.Add(string.Join(dauTach, cacCot.Select(c => XuLyOGiaTri(c.HeaderText, laCsv))));

            foreach (DataGridViewRow dong in dgvBaoCao.Rows)
            {
                IEnumerable<string> cacO = cacCot.Select(c =>
                {
                    object giaTri = dong.Cells[c.Index].Value;
                    // Dùng InvariantCulture để số thập phân luôn là dấu chấm, không làm vỡ file CSV
                    string text = Convert.ToString(giaTri, CultureInfo.InvariantCulture) ?? "";
                    return XuLyOGiaTri(text, laCsv);
                });
                cacDong.Add(string.Join(dauTach, cacO));
            }

            return cacDong;
        }

        // Với CSV: bao giá trị trong dấu ngoặc kép nếu có dấu phẩy hoặc dấu ngoặc kép
        private string XuLyOGiaTri(string text, bool laCsv)
        {
            if (!laCsv) return text;

            if (text.Contains(",") || text.Contains("\""))
            {
                return "\"" + text.Replace("\"", "\"\"") + "\"";
            }
            return text;
        }

        // ================== Sự kiện nút ==================

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            XemBaoCao();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeTheoLop();
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            XuatFile();
        }
    }
}
