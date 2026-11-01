namespace QLSinhVienLab12.Forms
{
    partial class FrmNhapDiemTheoLop
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpChon = new GroupBox();
            lblLop = new Label();
            cboLop = new ComboBox();
            lblMonHoc = new Label();
            cboMonHoc = new ComboBox();
            btnTaiDanhSach = new Button();
            lblLoc = new Label();
            txtLoc = new TextBox();
            lblThongKe = new Label();
            dgvKetQua = new DataGridView();
            btnLuuTatCa = new Button();
            chkDemoRollback = new CheckBox();
            statusStrip1 = new StatusStrip();
            lblTrangThai = new ToolStripStatusLabel();

            grpChon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();

            // grpChon
            grpChon.Text = "Chọn lớp và môn học";
            grpChon.Location = new Point(12, 12);
            grpChon.Size = new Size(876, 70);
            grpChon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpChon.Controls.AddRange(new Control[] { lblLop, cboLop, lblMonHoc, cboMonHoc, btnTaiDanhSach });

            lblLop.Text = "Lớp:";
            lblLop.Location = new Point(15, 31);
            lblLop.AutoSize = true;
            cboLop.Name = "cboLop";
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.Location = new Point(60, 28);
            cboLop.Size = new Size(220, 28);

            lblMonHoc.Text = "Môn học:";
            lblMonHoc.Location = new Point(300, 31);
            lblMonHoc.AutoSize = true;
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonHoc.Location = new Point(375, 28);
            cboMonHoc.Size = new Size(250, 28);

            btnTaiDanhSach.Name = "btnTaiDanhSach";
            btnTaiDanhSach.Text = "Tải danh sách";
            btnTaiDanhSach.Location = new Point(645, 26);
            btnTaiDanhSach.Size = new Size(140, 33);
            btnTaiDanhSach.UseVisualStyleBackColor = true;

            // Lọc và thống kê
            lblLoc.Text = "Lọc:";
            lblLoc.Location = new Point(12, 99);
            lblLoc.AutoSize = true;
            txtLoc.Name = "txtLoc";
            txtLoc.PlaceholderText = "Nhập mã SV hoặc họ tên";
            txtLoc.Location = new Point(55, 96);
            txtLoc.Size = new Size(260, 27);

            lblThongKe.Name = "lblThongKe";
            lblThongKe.Location = new Point(340, 99);
            lblThongKe.Size = new Size(548, 23);
            lblThongKe.TextAlign = ContentAlignment.MiddleRight;
            lblThongKe.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // dgvKetQua
            dgvKetQua.Name = "dgvKetQua";
            dgvKetQua.Location = new Point(12, 130);
            dgvKetQua.Size = new Size(876, 378);
            dgvKetQua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.AllowUserToDeleteRows = false;
            dgvKetQua.RowHeadersVisible = true;
            dgvKetQua.MultiSelect = false;
            dgvKetQua.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvKetQua.BackgroundColor = SystemColors.Window;

            // btnLuuTatCa
            btnLuuTatCa.Name = "btnLuuTatCa";
            btnLuuTatCa.Text = "Lưu tất cả";
            btnLuuTatCa.Location = new Point(12, 520);
            btnLuuTatCa.Size = new Size(150, 36);
            btnLuuTatCa.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLuuTatCa.UseVisualStyleBackColor = true;

            chkDemoRollback.Name = "chkDemoRollback";
            chkDemoRollback.Text = "Demo rollback (bỏ qua kiểm tra khoảng điểm ở form, để database tự chặn)";
            chkDemoRollback.Location = new Point(180, 528);
            chkDemoRollback.AutoSize = true;
            chkDemoRollback.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            // statusStrip1
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblTrangThai });
            statusStrip1.Name = "statusStrip1";
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Text = "Sẵn sàng";

            // Form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            MinimumSize = new Size(760, 500);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhập điểm theo lớp";
            Controls.AddRange(new Control[] { grpChon, lblLoc, txtLoc, lblThongKe, dgvKetQua, btnLuuTatCa, chkDemoRollback, statusStrip1 });

            grpChon.ResumeLayout(false);
            grpChon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private GroupBox grpChon;
        private Label lblLop;
        private Label lblMonHoc;
        private Label lblLoc;
        private Label lblThongKe;
        private ComboBox cboLop;
        private ComboBox cboMonHoc;
        private TextBox txtLoc;
        private Button btnTaiDanhSach;
        private Button btnLuuTatCa;
        private CheckBox chkDemoRollback;
        private DataGridView dgvKetQua;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblTrangThai;
    }
}
