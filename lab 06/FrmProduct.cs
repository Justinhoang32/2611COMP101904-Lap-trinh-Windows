using System.ComponentModel;
using System.Globalization;
using System.Text;
using ProductManager.Models;

namespace ProductManager;

public partial class FrmProduct : Form
{
    // ===================== Dữ liệu =====================
    private static readonly string[] LoaiSanPham = { "Điện tử", "Văn phòng", "Gia dụng", "Thời trang" };
    private static readonly CultureInfo ViVn = new("vi-VN");

    /// <summary>Danh sách gốc, chứa toàn bộ sản phẩm (lưu trong bộ nhớ).</summary>
    private readonly BindingList<Product> products = new();

    /// <summary>Nguồn dữ liệu trung gian cho DataGridView (toàn bộ hoặc kết quả tìm kiếm).</summary>
    private readonly BindingSource productSource = new();

    private string selectedImagePath = string.Empty;
    private string currentKeyword = string.Empty;

    /// <summary>true khi code đang tự gán lại dữ liệu cho lưới, tránh nạp nhầm dữ liệu lên form.</summary>
    private bool suppressSelection;

    public FrmProduct()
    {
        InitializeComponent();
        Shown += FrmProduct_Shown;
    }

    // ===================== Load form =====================
    private void FrmProduct_Load(object? sender, EventArgs e)
    {
        cboLoaiSP.Items.AddRange(LoaiSanPham);
        cboLoaiSP.SelectedIndex = 0;

        LoadSampleData();

        productSource.DataSource = products;
        dgvProducts.DataSource = productSource;

        // Các thuộc tính này đã đặt trong Designer; đặt lại ở đây để dễ đối chiếu với đề bài.
        dgvProducts.ReadOnly = true;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.MultiSelect = false;
        dgvProducts.AllowUserToAddRows = false;

        ClearInput();
        UpdateStatus("Sẵn sàng");
    }

    /// <summary>
    /// DataGridView tự chọn dòng đầu tiên khi form hiện ra; xóa lại để lúc mới mở
    /// chưa có dòng nào được chọn (Sửa/Xóa sẽ báo "chưa chọn dòng").
    /// </summary>
    private void FrmProduct_Shown(object? sender, EventArgs e)
    {
        ClearInput();
    }

    private void LoadSampleData()
    {
        products.Add(new Product
        {
            MaSP = "SP01", TenSP = "Chuột không dây", LoaiSP = "Điện tử",
            DonGia = 150000, SoLuong = 20, NgayNhap = DateTime.Today.AddDays(-30), ConKinhDoanh = true
        });
        products.Add(new Product
        {
            MaSP = "SP02", TenSP = "Bút bi Thiên Long", LoaiSP = "Văn phòng",
            DonGia = 5000, SoLuong = 100, NgayNhap = DateTime.Today.AddDays(-20), ConKinhDoanh = true
        });
        products.Add(new Product
        {
            MaSP = "SP03", TenSP = "Nồi cơm điện 1.8L", LoaiSP = "Gia dụng",
            DonGia = 850000, SoLuong = 8, NgayNhap = DateTime.Today.AddDays(-12), ConKinhDoanh = true
        });
        products.Add(new Product
        {
            MaSP = "SP04", TenSP = "Áo thun cotton", LoaiSP = "Thời trang",
            DonGia = 199000, SoLuong = 35, NgayNhap = DateTime.Today.AddDays(-5), ConKinhDoanh = true
        });
        products.Add(new Product
        {
            MaSP = "SP05", TenSP = "Bàn phím cơ (cũ)", LoaiSP = "Điện tử",
            DonGia = 320000, SoLuong = 0, NgayNhap = DateTime.Today.AddDays(-60), ConKinhDoanh = false
        });
    }

    // ===================== Hàm hỗ trợ chính =====================

    /// <summary>Kiểm tra dữ liệu nhập. <paramref name="editing"/> là sản phẩm đang sửa (bỏ qua khi kiểm tra trùng mã).</summary>
    private bool ValidateInput(Product? editing = null)
    {
        errorProvider1.Clear();
        var errors = new List<string>();
        Control? firstInvalid = null;

        void Fail(Control control, string message)
        {
            errorProvider1.SetError(control, message);
            errors.Add(message);
            firstInvalid ??= control;
        }

        string ma = txtMaSP.Text.Trim();
        if (ma.Length == 0)
        {
            Fail(txtMaSP, "Mã sản phẩm không được để trống");
        }
        else if (products.Any(p => !ReferenceEquals(p, editing)
                                   && string.Equals(p.MaSP, ma, StringComparison.OrdinalIgnoreCase)))
        {
            Fail(txtMaSP, "Mã sản phẩm đã tồn tại");
        }

        if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            Fail(txtTenSP, "Tên sản phẩm không được để trống");

        if (cboLoaiSP.SelectedIndex < 0)
            Fail(cboLoaiSP, "Vui lòng chọn loại sản phẩm");

        if (numDonGia.Value <= 0)
            Fail(numDonGia, "Đơn giá phải lớn hơn 0");

        if (numSoLuong.Value < 0)
            Fail(numSoLuong, "Số lượng phải lớn hơn hoặc bằng 0");

        if (dtpNgayNhap.Value.Date > DateTime.Today)
            Fail(dtpNgayNhap, "Ngày nhập không được lớn hơn ngày hiện tại");

        if (errors.Count == 0)
            return true;

        MessageBox.Show("Dữ liệu chưa hợp lệ:\n- " + string.Join("\n- ", errors),
            "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        firstInvalid?.Focus();
        return false;
    }

    /// <summary>Xóa nội dung nhập, bỏ lỗi ErrorProvider, bỏ chọn dòng trên lưới.</summary>
    private void ClearInput()
    {
        txtMaSP.Clear();
        txtTenSP.Clear();
        cboLoaiSP.SelectedIndex = 0;
        numDonGia.Value = 0;
        numSoLuong.Value = 0;
        dtpNgayNhap.Value = DateTime.Today;
        chkConKinhDoanh.Checked = true;
        SetPicture(null);
        selectedImagePath = string.Empty;
        errorProvider1.Clear();
        dgvProducts.ClearSelection();
        txtMaSP.Focus();
    }

    /// <summary>Đưa dữ liệu của một sản phẩm lên các control nhập liệu.</summary>
    private void LoadProductToForm(Product p)
    {
        errorProvider1.Clear();
        txtMaSP.Text = p.MaSP;
        txtTenSP.Text = p.TenSP;
        cboLoaiSP.SelectedIndex = Math.Max(0, cboLoaiSP.Items.IndexOf(p.LoaiSP));
        SetNumeric(numDonGia, p.DonGia);
        SetNumeric(numSoLuong, p.SoLuong);
        dtpNgayNhap.Value = p.NgayNhap;
        chkConKinhDoanh.Checked = p.ConKinhDoanh;
        selectedImagePath = p.DuongDanAnh;
        SetPicture(LoadImageSafe(p.DuongDanAnh));
        errorProvider1.Clear();
    }

    /// <summary>Cập nhật thanh trạng thái: thông báo, số lượng sản phẩm, tổng giá trị tồn kho.</summary>
    private void UpdateStatus(string message)
    {
        lblStatus.Text = message;

        string count = $"Số sản phẩm: {products.Count}";
        if (productSource.Count != products.Count)
            count += $" (đang hiển thị {productSource.Count})";
        lblCount.Text = count;

        decimal total = products.Sum(p => p.ThanhTien);
        lblTongTon.Text = $"Tổng giá trị tồn kho: {total.ToString("N0", ViVn)} đ";
    }

    /// <summary>Lấy sản phẩm của dòng đang chọn trên lưới; trả về null nếu chưa chọn dòng nào.</summary>
    private Product? GetSelectedProduct()
    {
        if (dgvProducts.SelectedRows.Count == 0)
            return null;
        return dgvProducts.SelectedRows[0].DataBoundItem as Product;
    }

    /// <summary>Lấy sản phẩm đang chọn; nếu chưa chọn thì báo cho người dùng.</summary>
    private Product? RequireSelectedProduct(string action)
    {
        Product? p = GetSelectedProduct();
        if (p == null)
        {
            MessageBox.Show($"Vui lòng chọn một sản phẩm trong danh sách để {action}.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        return p;
    }

    /// <summary>Lọc theo mã/tên (không phân biệt hoa thường). Từ khóa rỗng = hiển thị tất cả.</summary>
    private void ApplyFilter(string keyword)
    {
        currentKeyword = keyword.Trim();
        suppressSelection = true;
        try
        {
            if (currentKeyword.Length == 0)
            {
                productSource.DataSource = products;
            }
            else
            {
                var found = products
                    .Where(p => p.MaSP.Contains(currentKeyword, StringComparison.OrdinalIgnoreCase)
                             || p.TenSP.Contains(currentKeyword, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                productSource.DataSource = new BindingList<Product>(found);
            }
            dgvProducts.ClearSelection();
        }
        finally
        {
            suppressSelection = false;
        }
    }

    private Product CreateProductFromForm() => new()
    {
        MaSP = txtMaSP.Text.Trim(),
        TenSP = txtTenSP.Text.Trim(),
        LoaiSP = cboLoaiSP.Text,
        DonGia = numDonGia.Value,
        SoLuong = (int)numSoLuong.Value,
        NgayNhap = dtpNgayNhap.Value.Date,
        ConKinhDoanh = chkConKinhDoanh.Checked,
        DuongDanAnh = selectedImagePath
    };

    private static void SetNumeric(NumericUpDown control, decimal value)
        => control.Value = Math.Min(Math.Max(value, control.Minimum), control.Maximum);

    private void SetPicture(Image? image)
    {
        picSanPham.Image?.Dispose();
        picSanPham.Image = image;
    }

    /// <summary>Đọc ảnh bằng stream để không khóa file ảnh trên đĩa.</summary>
    private static Image? LoadImageSafe(string path)
    {
        if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            return null;
        try
        {
            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            using var original = Image.FromStream(stream);
            return new Bitmap(original);
        }
        catch (Exception)
        {
            return null;
        }
    }

    // ===================== Thêm / Sửa / Xóa / Làm mới =====================
    private void btnThem_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput())
            return;

        Product p = CreateProductFromForm();
        products.Add(p);

        txtTimKiem.Clear();
        ApplyFilter(string.Empty);
        ClearInput();

        if (dgvProducts.RowCount > 0)
            dgvProducts.FirstDisplayedScrollingRowIndex = dgvProducts.RowCount - 1;

        UpdateStatus($"Đã thêm sản phẩm {p.MaSP}");
    }

    private void btnSua_Click(object? sender, EventArgs e)
    {
        Product? p = RequireSelectedProduct("sửa");
        if (p == null)
            return;
        if (!ValidateInput(editing: p))
            return;

        p.MaSP = txtMaSP.Text.Trim();
        p.TenSP = txtTenSP.Text.Trim();
        p.LoaiSP = cboLoaiSP.Text;
        p.DonGia = numDonGia.Value;
        p.SoLuong = (int)numSoLuong.Value;
        p.NgayNhap = dtpNgayNhap.Value.Date;
        p.ConKinhDoanh = chkConKinhDoanh.Checked;
        p.DuongDanAnh = selectedImagePath;

        productSource.ResetCurrentItem();   // vẽ lại dòng vừa sửa
        UpdateStatus($"Đã cập nhật sản phẩm {p.MaSP}");
    }

    private void btnXoa_Click(object? sender, EventArgs e)
    {
        Product? p = RequireSelectedProduct("xóa");
        if (p == null)
            return;

        DialogResult result = MessageBox.Show(
            $"Bạn có chắc muốn xóa sản phẩm \"{p.TenSP}\" ({p.MaSP})?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

        if (result != DialogResult.Yes)
            return;

        products.Remove(p);
        ApplyFilter(currentKeyword);
        ClearInput();
        UpdateStatus($"Đã xóa sản phẩm {p.MaSP}");
    }

    private void btnLamMoi_Click(object? sender, EventArgs e)
    {
        txtTimKiem.Clear();
        ApplyFilter(string.Empty);
        ClearInput();
        UpdateStatus("Đã làm mới dữ liệu");
    }

    // ===================== Tìm kiếm =====================
    private void tsbTimKiem_Click(object? sender, EventArgs e)
    {
        ApplyFilter(txtTimKiem.Text);

        if (currentKeyword.Length == 0)
            UpdateStatus("Hiển thị toàn bộ sản phẩm");
        else if (productSource.Count == 0)
            UpdateStatus($"Không tìm thấy sản phẩm nào với từ khóa \"{currentKeyword}\"");
        else
            UpdateStatus($"Tìm thấy {productSource.Count} sản phẩm với từ khóa \"{currentKeyword}\"");
    }

    private void mnuTimKiem_Click(object? sender, EventArgs e)
    {
        txtTimKiem.Focus();
        txtTimKiem.SelectAll();
    }

    private void txtTimKiem_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            tsbTimKiem_Click(sender, EventArgs.Empty);
        }
    }

    // ===================== Chọn ảnh =====================
    private void btnChonAnh_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Title = "Chọn ảnh sản phẩm",
            Filter = "Tệp ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Tất cả tệp|*.*"
        };

        if (dialog.ShowDialog() != DialogResult.OK)
            return;

        Image? image = LoadImageSafe(dialog.FileName);
        if (image == null)
        {
            MessageBox.Show("Không đọc được tệp ảnh đã chọn.", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        selectedImagePath = dialog.FileName;
        SetPicture(image);
        UpdateStatus("Đã chọn ảnh sản phẩm");
    }

    // ===================== DataGridView =====================
    private void dgvProducts_SelectionChanged(object? sender, EventArgs e)
    {
        if (suppressSelection)
            return;

        Product? p = GetSelectedProduct();
        if (p != null)
            LoadProductToForm(p);
    }

    /// <summary>Nhấn chuột phải: chọn dòng dưới con trỏ trước khi hiện ContextMenuStrip.</summary>
    private void dgvProducts_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            dgvProducts.CurrentCell = dgvProducts.Rows[e.RowIndex].Cells[e.ColumnIndex];
    }

    private void dgvProducts_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
            cmsXemChiTiet_Click(sender, EventArgs.Empty);
    }

    private void dgvProducts_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            e.Handled = true;
            btnXoa_Click(sender, EventArgs.Empty);
        }
    }

    // ===================== ContextMenuStrip =====================
    private void cmsSua_Click(object? sender, EventArgs e)
    {
        Product? p = RequireSelectedProduct("sửa");
        if (p == null)
            return;

        LoadProductToForm(p);
        txtTenSP.Focus();
        UpdateStatus($"Đang sửa {p.MaSP}: chỉnh dữ liệu rồi nhấn nút Sửa để lưu");
    }

    private void cmsXemChiTiet_Click(object? sender, EventArgs e)
    {
        Product? p = RequireSelectedProduct("xem chi tiết");
        if (p == null)
            return;

        string detail =
            $"Mã SP: {p.MaSP}\n" +
            $"Tên SP: {p.TenSP}\n" +
            $"Loại: {p.LoaiSP}\n" +
            $"Đơn giá: {p.DonGia.ToString("N0", ViVn)} đ\n" +
            $"Số lượng: {p.SoLuong}\n" +
            $"Ngày nhập: {p.NgayNhap:dd/MM/yyyy}\n" +
            $"Trạng thái: {(p.ConKinhDoanh ? "Còn kinh doanh" : "Ngừng kinh doanh")}\n" +
            $"Thành tiền: {p.ThanhTien.ToString("N0", ViVn)} đ\n" +
            $"Ảnh: {(string.IsNullOrWhiteSpace(p.DuongDanAnh) ? "(chưa có)" : p.DuongDanAnh)}";

        MessageBox.Show(detail, "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    // ===================== Menu =====================
    private void mnuXuat_Click(object? sender, EventArgs e)
    {
        using var dialog = new SaveFileDialog
        {
            Title = "Xuất danh sách sản phẩm",
            Filter = "Tệp văn bản (*.txt)|*.txt",
            FileName = $"DanhSachSanPham_{DateTime.Now:yyyyMMdd}.txt"
        };

        if (dialog.ShowDialog() != DialogResult.OK)
            return;

        var lines = new List<string>
        {
            "MaSP\tTenSP\tLoaiSP\tDonGia\tSoLuong\tNgayNhap\tConKinhDoanh\tThanhTien"
        };
        lines.AddRange(products.Select(p => string.Join('\t',
            p.MaSP, p.TenSP, p.LoaiSP, p.DonGia, p.SoLuong,
            p.NgayNhap.ToString("dd/MM/yyyy"), p.ConKinhDoanh, p.ThanhTien)));

        try
        {
            File.WriteAllLines(dialog.FileName, lines, new UTF8Encoding(true));
            UpdateStatus($"Đã xuất {products.Count} sản phẩm ra {Path.GetFileName(dialog.FileName)}");
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            MessageBox.Show("Không ghi được tệp: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void mnuThoat_Click(object? sender, EventArgs e) => Close();

    private void mnuGioiThieu_Click(object? sender, EventArgs e)
    {
        MessageBox.Show(
            "ProductManager - Lab 05 COMP1019\n" +
            "Quản lý sản phẩm bằng Windows Forms, DataGridView, BindingSource.\n\n" +
            "Phím tắt: Ctrl+N Thêm | Ctrl+E Sửa | Ctrl+D Xóa | Ctrl+F Tìm | F5 Làm mới | Delete (trên lưới) Xóa",
            "Giới thiệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    // ===================== ErrorProvider =====================
    /// <summary>Người dùng sửa lại một ô thì xóa biểu tượng lỗi của ô đó.</summary>
    private void ClearFieldError(object? sender, EventArgs e)
    {
        if (sender is Control control)
            errorProvider1.SetError(control, string.Empty);
    }
}
