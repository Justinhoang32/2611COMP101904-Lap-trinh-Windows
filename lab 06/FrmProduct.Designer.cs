#nullable disable
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProductManager
{
    partial class FrmProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Method hỗ trợ Designer - không sửa nội dung bằng tay nếu không cần thiết.
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            menuStrip1 = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuXuat = new ToolStripMenuItem();
            mnuFileSep = new ToolStripSeparator();
            mnuThoat = new ToolStripMenuItem();
            mnuQuanLy = new ToolStripMenuItem();
            mnuThem = new ToolStripMenuItem();
            mnuSua = new ToolStripMenuItem();
            mnuXoa = new ToolStripMenuItem();
            mnuQuanLySep = new ToolStripSeparator();
            mnuTimKiem = new ToolStripMenuItem();
            mnuLamMoi = new ToolStripMenuItem();
            mnuTroGiup = new ToolStripMenuItem();
            mnuGioiThieu = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            tsbThem = new ToolStripButton();
            tsbSua = new ToolStripButton();
            tsbXoa = new ToolStripButton();
            tsbLamMoi = new ToolStripButton();
            tssTim = new ToolStripSeparator();
            tslTim = new ToolStripLabel();
            txtTimKiem = new ToolStripTextBox();
            tsbTimKiem = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            lblCount = new ToolStripStatusLabel();
            lblTongTon = new ToolStripStatusLabel();
            grpThongTin = new GroupBox();
            lblMaSP = new Label();
            txtMaSP = new TextBox();
            lblTenSP = new Label();
            txtTenSP = new TextBox();
            lblLoaiSP = new Label();
            cboLoaiSP = new ComboBox();
            lblNgayNhap = new Label();
            dtpNgayNhap = new DateTimePicker();
            lblDonGia = new Label();
            numDonGia = new NumericUpDown();
            lblSoLuong = new Label();
            numSoLuong = new NumericUpDown();
            lblTrangThai = new Label();
            chkConKinhDoanh = new CheckBox();
            picSanPham = new PictureBox();
            btnChonAnh = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvProducts = new DataGridView();
            ctmGrid = new ContextMenuStrip(components);
            cmsSua = new ToolStripMenuItem();
            cmsXoa = new ToolStripMenuItem();
            cmsXemChiTiet = new ToolStripMenuItem();
            errorProvider1 = new ErrorProvider(components);
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            grpThongTin.SuspendLayout();
            ((ISupportInitialize)numDonGia).BeginInit();
            ((ISupportInitialize)numSoLuong).BeginInit();
            ((ISupportInitialize)picSanPham).BeginInit();
            ((ISupportInitialize)dgvProducts).BeginInit();
            ctmGrid.SuspendLayout();
            ((ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuFile, mnuQuanLy, mnuTroGiup });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1143, 30);
            menuStrip1.TabIndex = 0;
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuXuat, mnuFileSep, mnuThoat });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(46, 24);
            mnuFile.Text = "&File";
            // 
            // mnuXuat
            // 
            mnuXuat.Name = "mnuXuat";
            mnuXuat.ShortcutKeys = Keys.Control | Keys.S;
            mnuXuat.Size = new Size(317, 26);
            mnuXuat.Text = "Xuất danh sách ra file .txt...";
            mnuXuat.Click += mnuXuat_Click;
            // 
            // mnuFileSep
            // 
            mnuFileSep.Name = "mnuFileSep";
            mnuFileSep.Size = new Size(314, 6);
            // 
            // mnuThoat
            // 
            mnuThoat.Name = "mnuThoat";
            mnuThoat.ShortcutKeys = Keys.Control | Keys.Q;
            mnuThoat.Size = new Size(317, 26);
            mnuThoat.Text = "Thoát";
            mnuThoat.Click += mnuThoat_Click;
            // 
            // mnuQuanLy
            // 
            mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { mnuThem, mnuSua, mnuXoa, mnuQuanLySep, mnuTimKiem, mnuLamMoi });
            mnuQuanLy.Name = "mnuQuanLy";
            mnuQuanLy.Size = new Size(73, 24);
            mnuQuanLy.Text = "&Quản lý";
            // 
            // mnuThem
            // 
            mnuThem.Name = "mnuThem";
            mnuThem.ShortcutKeys = Keys.Control | Keys.N;
            mnuThem.Size = new Size(250, 26);
            mnuThem.Text = "Thêm sản phẩm";
            mnuThem.Click += btnThem_Click;
            // 
            // mnuSua
            // 
            mnuSua.Name = "mnuSua";
            mnuSua.ShortcutKeys = Keys.Control | Keys.E;
            mnuSua.Size = new Size(250, 26);
            mnuSua.Text = "Sửa sản phẩm";
            mnuSua.Click += btnSua_Click;
            // 
            // mnuXoa
            // 
            mnuXoa.Name = "mnuXoa";
            mnuXoa.ShortcutKeys = Keys.Control | Keys.D;
            mnuXoa.Size = new Size(250, 26);
            mnuXoa.Text = "Xóa sản phẩm";
            mnuXoa.Click += btnXoa_Click;
            // 
            // mnuQuanLySep
            // 
            mnuQuanLySep.Name = "mnuQuanLySep";
            mnuQuanLySep.Size = new Size(247, 6);
            // 
            // mnuTimKiem
            // 
            mnuTimKiem.Name = "mnuTimKiem";
            mnuTimKiem.ShortcutKeys = Keys.Control | Keys.F;
            mnuTimKiem.Size = new Size(250, 26);
            mnuTimKiem.Text = "Tìm kiếm";
            mnuTimKiem.Click += mnuTimKiem_Click;
            // 
            // mnuLamMoi
            // 
            mnuLamMoi.Name = "mnuLamMoi";
            mnuLamMoi.ShortcutKeys = Keys.F5;
            mnuLamMoi.Size = new Size(250, 26);
            mnuLamMoi.Text = "Làm mới";
            mnuLamMoi.Click += btnLamMoi_Click;
            // 
            // mnuTroGiup
            // 
            mnuTroGiup.DropDownItems.AddRange(new ToolStripItem[] { mnuGioiThieu });
            mnuTroGiup.Name = "mnuTroGiup";
            mnuTroGiup.Size = new Size(78, 24);
            mnuTroGiup.Text = "&Trợ giúp";
            // 
            // mnuGioiThieu
            // 
            mnuGioiThieu.Name = "mnuGioiThieu";
            mnuGioiThieu.ShortcutKeys = Keys.F1;
            mnuGioiThieu.Size = new Size(180, 26);
            mnuGioiThieu.Text = "Giới thiệu";
            mnuGioiThieu.Click += mnuGioiThieu_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbThem, tsbSua, tsbXoa, tsbLamMoi, tssTim, tslTim, txtTimKiem, tsbTimKiem });
            toolStrip1.Location = new Point(0, 30);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1143, 27);
            toolStrip1.TabIndex = 1;
            // 
            // tsbThem
            // 
            tsbThem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbThem.Name = "tsbThem";
            tsbThem.Size = new Size(50, 24);
            tsbThem.Text = "Thêm";
            tsbThem.ToolTipText = "Thêm sản phẩm (Ctrl+N)";
            tsbThem.Click += btnThem_Click;
            // 
            // tsbSua
            // 
            tsbSua.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbSua.Name = "tsbSua";
            tsbSua.Size = new Size(38, 24);
            tsbSua.Text = "Sửa";
            tsbSua.ToolTipText = "Lưu thay đổi cho sản phẩm đang chọn (Ctrl+E)";
            tsbSua.Click += btnSua_Click;
            // 
            // tsbXoa
            // 
            tsbXoa.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbXoa.Name = "tsbXoa";
            tsbXoa.Size = new Size(39, 24);
            tsbXoa.Text = "Xóa";
            tsbXoa.ToolTipText = "Xóa sản phẩm đang chọn (Ctrl+D)";
            tsbXoa.Click += btnXoa_Click;
            // 
            // tsbLamMoi
            // 
            tsbLamMoi.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbLamMoi.Name = "tsbLamMoi";
            tsbLamMoi.Size = new Size(71, 24);
            tsbLamMoi.Text = "Làm mới";
            tsbLamMoi.ToolTipText = "Làm mới (F5)";
            tsbLamMoi.Click += btnLamMoi_Click;
            // 
            // tssTim
            // 
            tssTim.Name = "tssTim";
            tssTim.Size = new Size(6, 27);
            // 
            // tslTim
            // 
            tslTim.Name = "tslTim";
            tslTim.Size = new Size(68, 24);
            tslTim.Text = "Mã / tên:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.AutoSize = false;
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(228, 27);
            txtTimKiem.ToolTipText = "Nhập mã hoặc tên sản phẩm rồi nhấn Enter";
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            // 
            // tsbTimKiem
            // 
            tsbTimKiem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbTimKiem.Name = "tsbTimKiem";
            tsbTimKiem.Size = new Size(74, 24);
            tsbTimKiem.Text = "Tìm kiếm";
            tsbTimKiem.ToolTipText = "Tìm kiếm (Enter)";
            tsbTimKiem.Click += tsbTimKiem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus, lblCount, lblTongTon });
            statusStrip1.Location = new Point(0, 823);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(1143, 30);
            statusStrip1.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(841, 24);
            lblStatus.Spring = true;
            lblStatus.Text = "Sẵn sàng";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCount
            // 
            lblCount.BorderSides = ToolStripStatusLabelBorderSides.Left;
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(113, 24);
            lblCount.Text = "Số sản phẩm: 0";
            // 
            // lblTongTon
            // 
            lblTongTon.BorderSides = ToolStripStatusLabelBorderSides.Left;
            lblTongTon.Name = "lblTongTon";
            lblTongTon.Size = new Size(172, 24);
            lblTongTon.Text = "Tổng giá trị tồn kho: 0 đ";
            // 
            // grpThongTin
            // 
            grpThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpThongTin.Controls.Add(lblMaSP);
            grpThongTin.Controls.Add(txtMaSP);
            grpThongTin.Controls.Add(lblTenSP);
            grpThongTin.Controls.Add(txtTenSP);
            grpThongTin.Controls.Add(lblLoaiSP);
            grpThongTin.Controls.Add(cboLoaiSP);
            grpThongTin.Controls.Add(lblNgayNhap);
            grpThongTin.Controls.Add(dtpNgayNhap);
            grpThongTin.Controls.Add(lblDonGia);
            grpThongTin.Controls.Add(numDonGia);
            grpThongTin.Controls.Add(lblSoLuong);
            grpThongTin.Controls.Add(numSoLuong);
            grpThongTin.Controls.Add(lblTrangThai);
            grpThongTin.Controls.Add(chkConKinhDoanh);
            grpThongTin.Controls.Add(picSanPham);
            grpThongTin.Controls.Add(btnChonAnh);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnLamMoi);
            grpThongTin.Location = new Point(14, 80);
            grpThongTin.Margin = new Padding(3, 4, 3, 4);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Padding = new Padding(3, 4, 3, 4);
            grpThongTin.Size = new Size(1115, 327);
            grpThongTin.TabIndex = 2;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin sản phẩm";
            // 
            // lblMaSP
            // 
            lblMaSP.AutoSize = true;
            lblMaSP.Location = new Point(18, 47);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Size = new Size(53, 20);
            lblMaSP.TabIndex = 0;
            lblMaSP.Text = "Mã SP:";
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(114, 43);
            txtMaSP.Margin = new Padding(3, 4, 3, 4);
            txtMaSP.MaxLength = 20;
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(262, 27);
            txtMaSP.TabIndex = 0;
            txtMaSP.TextChanged += ClearFieldError;
            // 
            // lblTenSP
            // 
            lblTenSP.AutoSize = true;
            lblTenSP.Location = new Point(18, 95);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(55, 20);
            lblTenSP.TabIndex = 1;
            lblTenSP.Text = "Tên SP:";
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(114, 91);
            txtTenSP.Margin = new Padding(3, 4, 3, 4);
            txtTenSP.MaxLength = 100;
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(262, 27);
            txtTenSP.TabIndex = 1;
            txtTenSP.TextChanged += ClearFieldError;
            // 
            // lblLoaiSP
            // 
            lblLoaiSP.AutoSize = true;
            lblLoaiSP.Location = new Point(18, 143);
            lblLoaiSP.Name = "lblLoaiSP";
            lblLoaiSP.Size = new Size(60, 20);
            lblLoaiSP.TabIndex = 2;
            lblLoaiSP.Text = "Loại SP:";
            // 
            // cboLoaiSP
            // 
            cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiSP.FormattingEnabled = true;
            cboLoaiSP.Location = new Point(114, 139);
            cboLoaiSP.Margin = new Padding(3, 4, 3, 4);
            cboLoaiSP.Name = "cboLoaiSP";
            cboLoaiSP.Size = new Size(262, 28);
            cboLoaiSP.TabIndex = 2;
            cboLoaiSP.SelectedIndexChanged += ClearFieldError;
            // 
            // lblNgayNhap
            // 
            lblNgayNhap.AutoSize = true;
            lblNgayNhap.Location = new Point(18, 191);
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Size = new Size(84, 20);
            lblNgayNhap.TabIndex = 3;
            lblNgayNhap.Text = "Ngày nhập:";
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            dtpNgayNhap.Format = DateTimePickerFormat.Custom;
            dtpNgayNhap.Location = new Point(114, 187);
            dtpNgayNhap.Margin = new Padding(3, 4, 3, 4);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(262, 27);
            dtpNgayNhap.TabIndex = 3;
            dtpNgayNhap.ValueChanged += ClearFieldError;
            // 
            // lblDonGia
            // 
            lblDonGia.AutoSize = true;
            lblDonGia.Location = new Point(423, 47);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Size = new Size(65, 20);
            lblDonGia.TabIndex = 4;
            lblDonGia.Text = "Đơn giá:";
            // 
            // numDonGia
            // 
            numDonGia.Location = new Point(514, 43);
            numDonGia.Margin = new Padding(3, 4, 3, 4);
            numDonGia.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numDonGia.Name = "numDonGia";
            numDonGia.Size = new Size(229, 27);
            numDonGia.TabIndex = 4;
            numDonGia.TextAlign = HorizontalAlignment.Right;
            numDonGia.ThousandsSeparator = true;
            numDonGia.ValueChanged += ClearFieldError;
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Location = new Point(423, 95);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(72, 20);
            lblSoLuong.TabIndex = 5;
            lblSoLuong.Text = "Số lượng:";
            // 
            // numSoLuong
            // 
            numSoLuong.Location = new Point(514, 91);
            numSoLuong.Margin = new Padding(3, 4, 3, 4);
            numSoLuong.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(229, 27);
            numSoLuong.TabIndex = 5;
            numSoLuong.TextAlign = HorizontalAlignment.Right;
            numSoLuong.ThousandsSeparator = true;
            numSoLuong.ValueChanged += ClearFieldError;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(423, 143);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(78, 20);
            lblTrangThai.TabIndex = 6;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // chkConKinhDoanh
            // 
            chkConKinhDoanh.AutoSize = true;
            chkConKinhDoanh.Checked = true;
            chkConKinhDoanh.CheckState = CheckState.Checked;
            chkConKinhDoanh.Location = new Point(514, 141);
            chkConKinhDoanh.Margin = new Padding(3, 4, 3, 4);
            chkConKinhDoanh.Name = "chkConKinhDoanh";
            chkConKinhDoanh.Size = new Size(134, 24);
            chkConKinhDoanh.TabIndex = 6;
            chkConKinhDoanh.Text = "Còn kinh doanh";
            chkConKinhDoanh.UseVisualStyleBackColor = true;
            // 
            // picSanPham
            // 
            picSanPham.BackColor = SystemColors.ControlLight;
            picSanPham.BorderStyle = BorderStyle.FixedSingle;
            picSanPham.Location = new Point(846, 35);
            picSanPham.Margin = new Padding(3, 4, 3, 4);
            picSanPham.Name = "picSanPham";
            picSanPham.Size = new Size(217, 213);
            picSanPham.SizeMode = PictureBoxSizeMode.Zoom;
            picSanPham.TabIndex = 7;
            picSanPham.TabStop = false;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(846, 256);
            btnChonAnh.Margin = new Padding(3, 4, 3, 4);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(217, 43);
            btnChonAnh.TabIndex = 7;
            btnChonAnh.Text = "Chọn ảnh...";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(18, 256);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(109, 45);
            btnThem.TabIndex = 8;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(134, 256);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(109, 45);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(249, 256);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(109, 45);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(365, 256);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(109, 45);
            btnLamMoi.TabIndex = 11;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 247, 252);
            dgvProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.BackgroundColor = SystemColors.Window;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProducts.ColumnHeadersHeight = 32;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProducts.ContextMenuStrip = ctmGrid;
            dgvProducts.Location = new Point(14, 421);
            dgvProducts.Margin = new Padding(3, 4, 3, 4);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.RowTemplate.Height = 27;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(1115, 392);
            dgvProducts.TabIndex = 12;
            dgvProducts.CellDoubleClick += dgvProducts_CellDoubleClick;
            dgvProducts.CellMouseDown += dgvProducts_CellMouseDown;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            dgvProducts.KeyDown += dgvProducts_KeyDown;
            // 
            // ctmGrid
            // 
            ctmGrid.ImageScalingSize = new Size(20, 20);
            ctmGrid.Items.AddRange(new ToolStripItem[] { cmsSua, cmsXoa, cmsXemChiTiet });
            ctmGrid.Name = "ctmGrid";
            ctmGrid.Size = new Size(158, 76);
            // 
            // cmsSua
            // 
            cmsSua.Name = "cmsSua";
            cmsSua.Size = new Size(157, 24);
            cmsSua.Text = "Sửa";
            cmsSua.Click += cmsSua_Click;
            // 
            // cmsXoa
            // 
            cmsXoa.Name = "cmsXoa";
            cmsXoa.Size = new Size(157, 24);
            cmsXoa.Text = "Xóa";
            cmsXoa.Click += btnXoa_Click;
            // 
            // cmsXemChiTiet
            // 
            cmsXemChiTiet.Name = "cmsXemChiTiet";
            cmsXemChiTiet.Size = new Size(157, 24);
            cmsXemChiTiet.Text = "Xem chi tiết";
            cmsXemChiTiet.Click += cmsXemChiTiet_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // FrmProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 853);
            Controls.Add(dgvProducts);
            Controls.Add(grpThongTin);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 9F);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1026, 784);
            Name = "FrmProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý sản phẩm";
            Load += FrmProduct_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((ISupportInitialize)numDonGia).EndInit();
            ((ISupportInitialize)numSoLuong).EndInit();
            ((ISupportInitialize)picSanPham).EndInit();
            ((ISupportInitialize)dgvProducts).EndInit();
            ctmGrid.ResumeLayout(false);
            ((ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // ----- MenuStrip -----
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuXuat;
        private ToolStripSeparator mnuFileSep;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem mnuQuanLy;
        private ToolStripMenuItem mnuThem;
        private ToolStripMenuItem mnuSua;
        private ToolStripMenuItem mnuXoa;
        private ToolStripSeparator mnuQuanLySep;
        private ToolStripMenuItem mnuTimKiem;
        private ToolStripMenuItem mnuLamMoi;
        private ToolStripMenuItem mnuTroGiup;
        private ToolStripMenuItem mnuGioiThieu;

        // ----- ToolStrip -----
        private ToolStrip toolStrip1;
        private ToolStripButton tsbThem;
        private ToolStripButton tsbSua;
        private ToolStripButton tsbXoa;
        private ToolStripButton tsbLamMoi;
        private ToolStripSeparator tssTim;
        private ToolStripLabel tslTim;
        private ToolStripTextBox txtTimKiem;
        private ToolStripButton tsbTimKiem;

        // ----- StatusStrip -----
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblCount;
        private ToolStripStatusLabel lblTongTon;

        // ----- GroupBox và control nhập liệu -----
        private GroupBox grpThongTin;
        private Label lblMaSP;
        private TextBox txtMaSP;
        private Label lblTenSP;
        private TextBox txtTenSP;
        private Label lblLoaiSP;
        private ComboBox cboLoaiSP;
        private Label lblNgayNhap;
        private DateTimePicker dtpNgayNhap;
        private Label lblDonGia;
        private NumericUpDown numDonGia;
        private Label lblSoLuong;
        private NumericUpDown numSoLuong;
        private Label lblTrangThai;
        private CheckBox chkConKinhDoanh;
        private PictureBox picSanPham;
        private Button btnChonAnh;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;

        // ----- DataGridView -----
        private DataGridView dgvProducts;
        private DataGridViewTextBoxColumn colMaSP;
        private DataGridViewTextBoxColumn colTenSP;
        private DataGridViewTextBoxColumn colLoaiSP;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colNgayNhap;
        private DataGridViewCheckBoxColumn colConKinhDoanh;
        private DataGridViewTextBoxColumn colThanhTien;

        // ----- ContextMenuStrip & ErrorProvider -----
        private ContextMenuStrip ctmGrid;
        private ToolStripMenuItem cmsSua;
        private ToolStripMenuItem cmsXoa;
        private ToolStripMenuItem cmsXemChiTiet;
        private ErrorProvider errorProvider1;
    }
}
