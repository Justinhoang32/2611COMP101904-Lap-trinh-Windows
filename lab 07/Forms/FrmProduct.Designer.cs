namespace ShopManagerMini.Forms
{
    partial class FrmProduct
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpThongTin = new GroupBox();
            lblMaSP = new Label();
            lblTenSP = new Label();
            lblLoaiSP = new Label();
            lblDonGia = new Label();
            lblSoLuong = new Label();
            txtMaSP = new TextBox();
            txtTenSP = new TextBox();
            cboLoaiSP = new ComboBox();
            txtDonGia = new TextBox();
            txtSoLuong = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvSanPham = new DataGridView();

            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            SuspendLayout();

            grpThongTin.Text = "Thông tin sản phẩm";
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Size = new Size(776, 155);
            grpThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpThongTin.Controls.AddRange(new Control[] { lblMaSP, txtMaSP, lblLoaiSP, cboLoaiSP, lblTenSP, txtTenSP, lblDonGia, txtDonGia, lblSoLuong, txtSoLuong });

            lblMaSP.Text = "Mã sản phẩm:";
            lblMaSP.Location = new Point(20, 33);
            lblMaSP.AutoSize = true;
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Location = new Point(130, 30);
            txtMaSP.Size = new Size(200, 27);
            txtMaSP.MaxLength = 10;

            lblLoaiSP.Text = "Loại sản phẩm:";
            lblLoaiSP.Location = new Point(370, 33);
            lblLoaiSP.AutoSize = true;
            cboLoaiSP.Name = "cboLoaiSP";
            cboLoaiSP.Location = new Point(490, 30);
            cboLoaiSP.Size = new Size(200, 28);

            lblTenSP.Text = "Tên sản phẩm:";
            lblTenSP.Location = new Point(20, 73);
            lblTenSP.AutoSize = true;
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Location = new Point(130, 70);
            txtTenSP.Size = new Size(560, 27);
            txtTenSP.MaxLength = 100;
            txtTenSP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblDonGia.Text = "Đơn giá:";
            lblDonGia.Location = new Point(20, 113);
            lblDonGia.AutoSize = true;
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Location = new Point(130, 110);
            txtDonGia.Size = new Size(200, 27);

            lblSoLuong.Text = "Số lượng:";
            lblSoLuong.Location = new Point(370, 113);
            lblSoLuong.AutoSize = true;
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Location = new Point(490, 110);
            txtSoLuong.Size = new Size(200, 27);

            btnThem.Name = "btnThem";
            btnThem.Text = "Thêm";
            btnThem.Location = new Point(12, 177);
            btnThem.Size = new Size(100, 32);
            btnThem.UseVisualStyleBackColor = true;

            btnSua.Name = "btnSua";
            btnSua.Text = "Sửa";
            btnSua.Location = new Point(122, 177);
            btnSua.Size = new Size(100, 32);
            btnSua.UseVisualStyleBackColor = true;

            btnXoa.Name = "btnXoa";
            btnXoa.Text = "Xóa";
            btnXoa.Location = new Point(232, 177);
            btnXoa.Size = new Size(100, 32);
            btnXoa.UseVisualStyleBackColor = true;

            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Location = new Point(342, 177);
            btnLamMoi.Size = new Size(100, 32);
            btnLamMoi.UseVisualStyleBackColor = true;

            lblTimKiem.Text = "Từ khóa:";
            lblTimKiem.Location = new Point(470, 183);
            lblTimKiem.AutoSize = true;
            lblTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Location = new Point(540, 179);
            txtTimKiem.Size = new Size(150, 27);
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.Location = new Point(698, 177);
            btnTimKiem.Size = new Size(90, 32);
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.UseVisualStyleBackColor = true;

            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.Location = new Point(12, 222);
            dgvSanPham.Size = new Size(776, 296);
            dgvSanPham.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSanPham.ReadOnly = true;
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.AllowUserToDeleteRows = false;
            dgvSanPham.MultiSelect = false;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.RowHeadersVisible = false;
            dgvSanPham.BackgroundColor = SystemColors.Window;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 530);
            Text = "Quản lý sản phẩm";
            Controls.AddRange(new Control[] { grpThongTin, btnThem, btnSua, btnXoa, btnLamMoi, lblTimKiem, txtTimKiem, btnTimKiem, dgvSanPham });

            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private GroupBox grpThongTin;
        private Label lblMaSP;
        private Label lblTenSP;
        private Label lblLoaiSP;
        private Label lblDonGia;
        private Label lblSoLuong;
        private Label lblTimKiem;
        private TextBox txtMaSP;
        private TextBox txtTenSP;
        private ComboBox cboLoaiSP;
        private TextBox txtDonGia;
        private TextBox txtSoLuong;
        private TextBox txtTimKiem;
        private DataGridView dgvSanPham;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnTimKiem;
    }
}
