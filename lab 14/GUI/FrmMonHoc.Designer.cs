namespace EduManager.GUI
{
    partial class FrmMonHoc
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
            lblMa = new Label();
            txtMaMonHoc = new TextBox();
            lblTen = new Label();
            txtTenMonHoc = new TextBox();
            lblTinChi = new Label();
            nudSoTinChi = new NumericUpDown();
            chkTrangThai = new CheckBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvMonHoc = new DataGridView();
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoTinChi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).BeginInit();
            SuspendLayout();
            // 
            // grpThongTin
            // 
            grpThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpThongTin.Controls.Add(lblMa);
            grpThongTin.Controls.Add(txtMaMonHoc);
            grpThongTin.Controls.Add(lblTen);
            grpThongTin.Controls.Add(txtTenMonHoc);
            grpThongTin.Controls.Add(lblTinChi);
            grpThongTin.Controls.Add(nudSoTinChi);
            grpThongTin.Controls.Add(chkTrangThai);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(776, 150);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin môn học";
            // 
            // lblMa
            // 
            lblMa.AutoSize = true;
            lblMa.Location = new Point(20, 33);
            lblMa.Name = "lblMa";
            lblMa.Size = new Size(95, 20);
            lblMa.TabIndex = 0;
            lblMa.Text = "Mã môn học:";
            // 
            // txtMaMonHoc
            // 
            txtMaMonHoc.Location = new Point(130, 30);
            txtMaMonHoc.MaxLength = 10;
            txtMaMonHoc.Name = "txtMaMonHoc";
            txtMaMonHoc.Size = new Size(200, 27);
            txtMaMonHoc.TabIndex = 1;
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Location = new Point(20, 68);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(97, 20);
            lblTen.TabIndex = 2;
            lblTen.Text = "Tên môn học:";
            // 
            // txtTenMonHoc
            // 
            txtTenMonHoc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTenMonHoc.Location = new Point(130, 65);
            txtTenMonHoc.MaxLength = 100;
            txtTenMonHoc.Name = "txtTenMonHoc";
            txtTenMonHoc.Size = new Size(620, 27);
            txtTenMonHoc.TabIndex = 3;
            // 
            // lblTinChi
            // 
            lblTinChi.AutoSize = true;
            lblTinChi.Location = new Point(20, 103);
            lblTinChi.Name = "lblTinChi";
            lblTinChi.Size = new Size(73, 20);
            lblTinChi.TabIndex = 4;
            lblTinChi.Text = "Số tín chỉ:";
            // 
            // nudSoTinChi
            // 
            nudSoTinChi.Location = new Point(130, 100);
            nudSoTinChi.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            nudSoTinChi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoTinChi.Name = "nudSoTinChi";
            nudSoTinChi.Size = new Size(80, 27);
            nudSoTinChi.TabIndex = 5;
            nudSoTinChi.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // chkTrangThai
            // 
            chkTrangThai.AutoSize = true;
            chkTrangThai.Checked = true;
            chkTrangThai.CheckState = CheckState.Checked;
            chkTrangThai.Location = new Point(260, 102);
            chkTrangThai.Name = "chkTrangThai";
            chkTrangThai.Size = new Size(114, 24);
            chkTrangThai.TabIndex = 6;
            chkTrangThai.Text = "Còn sử dụng";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(15, 178);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 32);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm";
            // 
            // btnSua
            // 
            btnSua.Location = new Point(96, 178);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 32);
            btnSua.TabIndex = 2;
            btnSua.Text = "Sửa";
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(177, 178);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 32);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa";
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(258, 175);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(75, 36);
            btnLamMoi.TabIndex = 4;
            btnLamMoi.Text = "Làm Mới";
            btnLamMoi.Click += btnLamMoi_Click_1;
            // 
            // lblTimKiem
            // 
            lblTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(470, 178);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(65, 20);
            lblTimKiem.TabIndex = 5;
            lblTimKiem.Text = "Từ khóa:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTimKiem.Location = new Point(540, 174);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(150, 27);
            txtTimKiem.TabIndex = 6;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.Location = new Point(339, 171);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(90, 43);
            btnTimKiem.TabIndex = 7;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.Click += btnTimKiem_Click_1;
            // 
            // dgvMonHoc
            // 
            dgvMonHoc.AllowUserToAddRows = false;
            dgvMonHoc.AllowUserToDeleteRows = false;
            dgvMonHoc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMonHoc.BackgroundColor = SystemColors.Info;
            dgvMonHoc.ColumnHeadersHeight = 29;
            dgvMonHoc.Location = new Point(12, 216);
            dgvMonHoc.MultiSelect = false;
            dgvMonHoc.Name = "dgvMonHoc";
            dgvMonHoc.ReadOnly = true;
            dgvMonHoc.RowHeadersVisible = false;
            dgvMonHoc.RowHeadersWidth = 51;
            dgvMonHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMonHoc.Size = new Size(776, 322);
            dgvMonHoc.TabIndex = 8;
            // 
            // FrmMonHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 550);
            Controls.Add(grpThongTin);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(lblTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(btnTimKiem);
            Controls.Add(dgvMonHoc);
            MinimumSize = new Size(816, 589);
            Name = "FrmMonHoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EduManager - Quản lý môn học";
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoTinChi).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private static void ThietLapNut(Button b, string name, string text, int x, int y)
        {
            b.Name = name;
            b.Text = text;
            b.Location = new Point(x, y);
            b.Size = new Size(100, 32);
            b.UseVisualStyleBackColor = true;
        }

        private GroupBox grpThongTin;
        private Label lblMa;
        private Label lblTen;
        private Label lblTinChi;
        private Label lblTimKiem;
        private TextBox txtMaMonHoc;
        private TextBox txtTenMonHoc;
        private NumericUpDown nudSoTinChi;
        private CheckBox chkTrangThai;
        private TextBox txtTimKiem;
        private DataGridView dgvMonHoc;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnTimKiem;
    }
}
