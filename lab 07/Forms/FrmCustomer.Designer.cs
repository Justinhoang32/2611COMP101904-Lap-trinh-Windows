namespace ShopManagerMini.Forms
{
    partial class FrmCustomer
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
            lblMaKH = new Label();
            lblHoTen = new Label();
            lblSoDienThoai = new Label();
            lblLoaiKH = new Label();
            txtMaKH = new TextBox();
            txtHoTen = new TextBox();
            txtSoDienThoai = new TextBox();
            cboLoaiKH = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvKhachHang = new DataGridView();

            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            SuspendLayout();

            grpThongTin.Text = "Thông tin khách hàng";
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Size = new Size(776, 115);
            grpThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpThongTin.Controls.AddRange(new Control[] { lblMaKH, txtMaKH, lblLoaiKH, cboLoaiKH, lblHoTen, txtHoTen, lblSoDienThoai, txtSoDienThoai });

            lblMaKH.Text = "Mã khách hàng:";
            lblMaKH.Location = new Point(20, 33);
            lblMaKH.AutoSize = true;
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Location = new Point(140, 30);
            txtMaKH.Size = new Size(200, 27);
            txtMaKH.MaxLength = 10;

            lblLoaiKH.Text = "Loại khách hàng:";
            lblLoaiKH.Location = new Point(380, 33);
            lblLoaiKH.AutoSize = true;
            cboLoaiKH.Name = "cboLoaiKH";
            cboLoaiKH.Location = new Point(510, 30);
            cboLoaiKH.Size = new Size(200, 28);

            lblHoTen.Text = "Họ tên:";
            lblHoTen.Location = new Point(20, 73);
            lblHoTen.AutoSize = true;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Location = new Point(140, 70);
            txtHoTen.Size = new Size(200, 27);
            txtHoTen.MaxLength = 100;

            lblSoDienThoai.Text = "Số điện thoại:";
            lblSoDienThoai.Location = new Point(380, 73);
            lblSoDienThoai.AutoSize = true;
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Location = new Point(510, 70);
            txtSoDienThoai.Size = new Size(200, 27);
            txtSoDienThoai.MaxLength = 11;

            btnThem.Name = "btnThem";
            btnThem.Text = "Thêm";
            btnThem.Location = new Point(12, 137);
            btnThem.Size = new Size(100, 32);
            btnThem.UseVisualStyleBackColor = true;

            btnSua.Name = "btnSua";
            btnSua.Text = "Sửa";
            btnSua.Location = new Point(122, 137);
            btnSua.Size = new Size(100, 32);
            btnSua.UseVisualStyleBackColor = true;

            btnXoa.Name = "btnXoa";
            btnXoa.Text = "Xóa";
            btnXoa.Location = new Point(232, 137);
            btnXoa.Size = new Size(100, 32);
            btnXoa.UseVisualStyleBackColor = true;

            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Location = new Point(342, 137);
            btnLamMoi.Size = new Size(100, 32);
            btnLamMoi.UseVisualStyleBackColor = true;

            lblTimKiem.Text = "Từ khóa:";
            lblTimKiem.Location = new Point(470, 143);
            lblTimKiem.AutoSize = true;
            lblTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Location = new Point(540, 139);
            txtTimKiem.Size = new Size(150, 27);
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.Location = new Point(698, 137);
            btnTimKiem.Size = new Size(90, 32);
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.UseVisualStyleBackColor = true;

            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.Location = new Point(12, 182);
            dgvKhachHang.Size = new Size(776, 306);
            dgvKhachHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AllowUserToDeleteRows = false;
            dgvKhachHang.MultiSelect = false;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.RowHeadersVisible = false;
            dgvKhachHang.BackgroundColor = SystemColors.Window;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Text = "Quản lý khách hàng";
            Controls.AddRange(new Control[] { grpThongTin, btnThem, btnSua, btnXoa, btnLamMoi, lblTimKiem, txtTimKiem, btnTimKiem, dgvKhachHang });

            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private GroupBox grpThongTin;
        private Label lblMaKH;
        private Label lblHoTen;
        private Label lblSoDienThoai;
        private Label lblLoaiKH;
        private Label lblTimKiem;
        private TextBox txtMaKH;
        private TextBox txtHoTen;
        private TextBox txtSoDienThoai;
        private ComboBox cboLoaiKH;
        private TextBox txtTimKiem;
        private DataGridView dgvKhachHang;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnTimKiem;
    }
}
