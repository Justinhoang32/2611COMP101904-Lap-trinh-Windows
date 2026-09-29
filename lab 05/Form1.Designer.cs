namespace WinFormsApp1
{
    partial class Frmdkkh
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtDKKHNH = new Label();
            txtSoDienThoai = new TextBox();
            grbhocvien = new GroupBox();
            dtpNgaySinh = new DateTimePicker();
            txt = new TextBox();
            lblTrangThaiEmail = new Label();
            chkNhanEmail = new CheckBox();
            txtNgaySinh = new Label();
            txtSDT = new Label();
            lblDemKyTu = new Label();
            txtHoTen = new TextBox();
            lblhoten = new Label();
            label2 = new Label();
            grbKhoc = new GroupBox();
            radOnline = new RadioButton();
            lblHocPhi = new Label();
            lblTongTien = new Label();
            lblTongTien1 = new Label();
            lblHocPhiThang = new Label();
            numSoThang = new NumericUpDown();
            lblSoThang = new Label();
            radOffline = new RadioButton();
            lblHinhThucHoc = new Label();
            cboKhoaHoc = new ComboBox();
            lblKhoaHoc = new Label();
            panel1 = new Panel();
            bntThoat = new Button();
            bntLamMoi = new Button();
            bntDangKy = new Button();
            grbhocvien.SuspendLayout();
            grbKhoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtDKKHNH
            // 
            txtDKKHNH.AutoSize = true;
            txtDKKHNH.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 163);
            txtDKKHNH.ForeColor = SystemColors.MenuHighlight;
            txtDKKHNH.Location = new Point(416, 35);
            txtDKKHNH.Margin = new Padding(5, 0, 5, 0);
            txtDKKHNH.Name = "txtDKKHNH";
            txtDKKHNH.Size = new Size(480, 35);
            txtDKKHNH.TabIndex = 0;
            txtDKKHNH.Text = "ĐĂNG KÍ KHÓA HỌC NGẮN HẠN";
            txtDKKHNH.Click += txtDKKHNH_Click;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(151, 98);
            txtSoDienThoai.Margin = new Padding(4, 3, 4, 3);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(338, 30);
            txtSoDienThoai.TabIndex = 1;
            // 
            // grbhocvien
            // 
            grbhocvien.BackColor = SystemColors.Info;
            grbhocvien.Controls.Add(dtpNgaySinh);
            grbhocvien.Controls.Add(txt);
            grbhocvien.Controls.Add(lblTrangThaiEmail);
            grbhocvien.Controls.Add(chkNhanEmail);
            grbhocvien.Controls.Add(txtNgaySinh);
            grbhocvien.Controls.Add(txtSDT);
            grbhocvien.Controls.Add(txtSoDienThoai);
            grbhocvien.Controls.Add(lblDemKyTu);
            grbhocvien.Controls.Add(txtHoTen);
            grbhocvien.Controls.Add(lblhoten);
            grbhocvien.Controls.Add(label2);
            grbhocvien.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            grbhocvien.Location = new Point(13, 90);
            grbhocvien.Margin = new Padding(4, 3, 4, 3);
            grbhocvien.Name = "grbhocvien";
            grbhocvien.Padding = new Padding(4, 3, 4, 3);
            grbhocvien.Size = new Size(567, 331);
            grbhocvien.TabIndex = 2;
            grbhocvien.TabStop = false;
            grbhocvien.Text = "Thông tin học viên ";
            grbhocvien.Enter += grbhocvien_Enter;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CalendarForeColor = SystemColors.ButtonShadow;
            dtpNgaySinh.CalendarTitleForeColor = Color.FloralWhite;
            dtpNgaySinh.CalendarTrailingForeColor = SystemColors.GradientActiveCaption;
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(151, 148);
            dtpNgaySinh.Margin = new Padding(4);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(338, 30);
            dtpNgaySinh.TabIndex = 8;
            // 
            // txt
            // 
            txt.Location = new Point(151, 146);
            txt.Margin = new Padding(4, 3, 4, 3);
            txt.Name = "txt";
            txt.Size = new Size(338, 30);
            txt.TabIndex = 7;
            // 
            // lblTrangThaiEmail
            // 
            lblTrangThaiEmail.AutoSize = true;
            lblTrangThaiEmail.Font = new Font("Arial", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 163);
            lblTrangThaiEmail.ForeColor = SystemColors.ActiveCaptionText;
            lblTrangThaiEmail.Location = new Point(151, 271);
            lblTrangThaiEmail.Margin = new Padding(4, 0, 4, 0);
            lblTrangThaiEmail.Name = "lblTrangThaiEmail";
            lblTrangThaiEmail.Size = new Size(301, 24);
            lblTrangThaiEmail.TabIndex = 6;
            lblTrangThaiEmail.Text = "Không Nhận Email Thông Báo ";
            lblTrangThaiEmail.Click += lblTrangThaiEmail_Click;
            // 
            // chkNhanEmail
            // 
            chkNhanEmail.AutoSize = true;
            chkNhanEmail.ForeColor = SystemColors.ActiveCaptionText;
            chkNhanEmail.Location = new Point(170, 223);
            chkNhanEmail.Margin = new Padding(4);
            chkNhanEmail.Name = "chkNhanEmail";
            chkNhanEmail.Size = new Size(248, 28);
            chkNhanEmail.TabIndex = 5;
            chkNhanEmail.Text = "Nhận Email Thông Báo";
            chkNhanEmail.UseVisualStyleBackColor = true;
            chkNhanEmail.CheckedChanged += chkNhanEmail_CheckedChanged;
            // 
            // txtNgaySinh
            // 
            txtNgaySinh.AutoSize = true;
            txtNgaySinh.ForeColor = SystemColors.Desktop;
            txtNgaySinh.Location = new Point(30, 148);
            txtNgaySinh.Margin = new Padding(4, 0, 4, 0);
            txtNgaySinh.Name = "txtNgaySinh";
            txtNgaySinh.Size = new Size(113, 24);
            txtNgaySinh.TabIndex = 3;
            txtNgaySinh.Text = "Ngày Sinh:";
            txtNgaySinh.Click += txtNgaySinh_Click;
            // 
            // txtSDT
            // 
            txtSDT.AutoSize = true;
            txtSDT.ForeColor = SystemColors.Desktop;
            txtSDT.Location = new Point(30, 101);
            txtSDT.Margin = new Padding(4, 0, 4, 0);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(55, 24);
            txtSDT.TabIndex = 4;
            txtSDT.Text = "SĐT:";
            // 
            // lblDemKyTu
            // 
            lblDemKyTu.AutoSize = true;
            lblDemKyTu.ForeColor = SystemColors.ScrollBar;
            lblDemKyTu.Location = new Point(497, 58);
            lblDemKyTu.Margin = new Padding(4, 0, 4, 0);
            lblDemKyTu.Name = "lblDemKyTu";
            lblDemKyTu.Size = new Size(49, 24);
            lblDemKyTu.TabIndex = 3;
            lblDemKyTu.Text = "0/50";
            lblDemKyTu.Click += lblDemKyTu_Click;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(151, 52);
            txtHoTen.Margin = new Padding(4, 3, 4, 3);
            txtHoTen.MaxLength = 50;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(338, 30);
            txtHoTen.TabIndex = 0;
            txtHoTen.TextChanged += txtHoTen_TextChanged_1;
            // 
            // lblhoten
            // 
            lblhoten.AutoSize = true;
            lblhoten.ForeColor = SystemColors.ActiveCaptionText;
            lblhoten.Location = new Point(30, 58);
            lblhoten.Margin = new Padding(4, 0, 4, 0);
            lblhoten.Name = "lblhoten";
            lblhoten.Size = new Size(85, 24);
            lblhoten.TabIndex = 1;
            lblhoten.Text = "Họ Tên:";
            lblhoten.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 58);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(0, 24);
            label2.TabIndex = 0;
            // 
            // grbKhoc
            // 
            grbKhoc.BackColor = SystemColors.Info;
            grbKhoc.Controls.Add(radOnline);
            grbKhoc.Controls.Add(lblHocPhi);
            grbKhoc.Controls.Add(lblTongTien);
            grbKhoc.Controls.Add(lblTongTien1);
            grbKhoc.Controls.Add(lblHocPhiThang);
            grbKhoc.Controls.Add(numSoThang);
            grbKhoc.Controls.Add(lblSoThang);
            grbKhoc.Controls.Add(radOffline);
            grbKhoc.Controls.Add(lblHinhThucHoc);
            grbKhoc.Controls.Add(cboKhoaHoc);
            grbKhoc.Controls.Add(lblKhoaHoc);
            grbKhoc.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            grbKhoc.Location = new Point(613, 90);
            grbKhoc.Margin = new Padding(4);
            grbKhoc.Name = "grbKhoc";
            grbKhoc.Padding = new Padding(4);
            grbKhoc.Size = new Size(532, 331);
            grbKhoc.TabIndex = 3;
            grbKhoc.TabStop = false;
            grbKhoc.Text = "Thông Tin Khóa Học";
            grbKhoc.Enter += groupBox1_Enter;
            // 
            // radOnline
            // 
            radOnline.AutoSize = true;
            radOnline.ForeColor = SystemColors.ControlText;
            radOnline.Location = new Point(203, 100);
            radOnline.Margin = new Padding(4);
            radOnline.Name = "radOnline";
            radOnline.Size = new Size(92, 28);
            radOnline.TabIndex = 11;
            radOnline.TabStop = true;
            radOnline.Text = "Online";
            radOnline.UseVisualStyleBackColor = true;
            // 
            // lblHocPhi
            // 
            lblHocPhi.AutoSize = true;
            lblHocPhi.ForeColor = Color.DarkOrange;
            lblHocPhi.Location = new Point(201, 199);
            lblHocPhi.Name = "lblHocPhi";
            lblHocPhi.Size = new Size(129, 24);
            lblHocPhi.TabIndex = 10;
            lblHocPhi.Text = "800,000 VND";
            lblHocPhi.Click += lblHocPhi_Click;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Arial", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 163);
            lblTongTien.ForeColor = Color.MediumSeaGreen;
            lblTongTien.Location = new Point(179, 262);
            lblTongTien.Margin = new Padding(4, 0, 4, 0);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(138, 46);
            lblTongTien.TabIndex = 9;
            lblTongTien.Text = "0 VND";
            // 
            // lblTongTien1
            // 
            lblTongTien1.AutoSize = true;
            lblTongTien1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblTongTien1.ForeColor = SystemColors.ControlText;
            lblTongTien1.Location = new Point(34, 271);
            lblTongTien1.Margin = new Padding(4, 0, 4, 0);
            lblTongTien1.Name = "lblTongTien1";
            lblTongTien1.Size = new Size(113, 24);
            lblTongTien1.TabIndex = 8;
            lblTongTien1.Text = "Tổng Tiền:";
            lblTongTien1.Click += label4_Click;
            // 
            // lblHocPhiThang
            // 
            lblHocPhiThang.AutoSize = true;
            lblHocPhiThang.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblHocPhiThang.ForeColor = SystemColors.ControlText;
            lblHocPhiThang.Location = new Point(35, 199);
            lblHocPhiThang.Margin = new Padding(4, 0, 4, 0);
            lblHocPhiThang.Name = "lblHocPhiThang";
            lblHocPhiThang.Size = new Size(157, 24);
            lblHocPhiThang.TabIndex = 7;
            lblHocPhiThang.Text = "Học Phí/Tháng:";
            // 
            // numSoThang
            // 
            numSoThang.Location = new Point(151, 144);
            numSoThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numSoThang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSoThang.Name = "numSoThang";
            numSoThang.Size = new Size(180, 30);
            numSoThang.TabIndex = 6;
            numSoThang.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numSoThang.ValueChanged += numSoThang_ValueChanged;
            // 
            // lblSoThang
            // 
            lblSoThang.AutoSize = true;
            lblSoThang.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblSoThang.ForeColor = SystemColors.ControlText;
            lblSoThang.Location = new Point(34, 146);
            lblSoThang.Margin = new Padding(4, 0, 4, 0);
            lblSoThang.Name = "lblSoThang";
            lblSoThang.Size = new Size(108, 24);
            lblSoThang.TabIndex = 5;
            lblSoThang.Text = "Số Tháng:";
            lblSoThang.Click += label3_Click_1;
            // 
            // radOffline
            // 
            radOffline.AutoSize = true;
            radOffline.ForeColor = SystemColors.ControlText;
            radOffline.Location = new Point(342, 98);
            radOffline.Margin = new Padding(4);
            radOffline.Name = "radOffline";
            radOffline.Size = new Size(123, 28);
            radOffline.TabIndex = 4;
            radOffline.TabStop = true;
            radOffline.Text = "Trực Tiếp";
            radOffline.UseVisualStyleBackColor = true;
            // 
            // lblHinhThucHoc
            // 
            lblHinhThucHoc.AutoSize = true;
            lblHinhThucHoc.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblHinhThucHoc.ForeColor = SystemColors.ControlText;
            lblHinhThucHoc.Location = new Point(35, 101);
            lblHinhThucHoc.Margin = new Padding(4, 0, 4, 0);
            lblHinhThucHoc.Name = "lblHinhThucHoc";
            lblHinhThucHoc.Size = new Size(160, 24);
            lblHinhThucHoc.TabIndex = 2;
            lblHinhThucHoc.Text = "Hình Thức Học:";
            lblHinhThucHoc.UseMnemonic = false;
            lblHinhThucHoc.Click += lblHinhThucHoc_Click;
            // 
            // cboKhoaHoc
            // 
            cboKhoaHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoaHoc.FormattingEnabled = true;
            cboKhoaHoc.Location = new Point(151, 44);
            cboKhoaHoc.Margin = new Padding(4);
            cboKhoaHoc.Name = "cboKhoaHoc";
            cboKhoaHoc.Size = new Size(314, 32);
            cboKhoaHoc.TabIndex = 1;
            cboKhoaHoc.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // lblKhoaHoc
            // 
            lblKhoaHoc.AutoSize = true;
            lblKhoaHoc.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblKhoaHoc.ForeColor = SystemColors.ControlText;
            lblKhoaHoc.Location = new Point(34, 52);
            lblKhoaHoc.Margin = new Padding(4, 0, 4, 0);
            lblKhoaHoc.Name = "lblKhoaHoc";
            lblKhoaHoc.Size = new Size(109, 24);
            lblKhoaHoc.TabIndex = 0;
            lblKhoaHoc.Text = "Khóa Học:";
            lblKhoaHoc.Click += lblKhoaHoc_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(bntThoat);
            panel1.Controls.Add(bntLamMoi);
            panel1.Controls.Add(bntDangKy);
            panel1.Location = new Point(221, 448);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(802, 144);
            panel1.TabIndex = 4;
            // 
            // bntThoat
            // 
            bntThoat.BackColor = Color.Red;
            bntThoat.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            bntThoat.ForeColor = SystemColors.ButtonFace;
            bntThoat.Location = new Point(530, 39);
            bntThoat.Margin = new Padding(4);
            bntThoat.Name = "bntThoat";
            bntThoat.Size = new Size(232, 79);
            bntThoat.TabIndex = 2;
            bntThoat.Text = "Thoát";
            bntThoat.UseVisualStyleBackColor = false;
            bntThoat.Click += bntThoat_Click;
            // 
            // bntLamMoi
            // 
            bntLamMoi.BackColor = Color.DodgerBlue;
            bntLamMoi.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            bntLamMoi.ForeColor = SystemColors.ButtonHighlight;
            bntLamMoi.Location = new Point(270, 39);
            bntLamMoi.Margin = new Padding(4);
            bntLamMoi.Name = "bntLamMoi";
            bntLamMoi.Size = new Size(232, 79);
            bntLamMoi.TabIndex = 1;
            bntLamMoi.Text = "Làm Mới";
            bntLamMoi.UseVisualStyleBackColor = false;
            bntLamMoi.Click += bntLamMoi_Click;
            // 
            // bntDangKy
            // 
            bntDangKy.BackColor = Color.DarkGreen;
            bntDangKy.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            bntDangKy.ForeColor = SystemColors.ButtonHighlight;
            bntDangKy.Location = new Point(5, 39);
            bntDangKy.Margin = new Padding(4);
            bntDangKy.Name = "bntDangKy";
            bntDangKy.Size = new Size(232, 79);
            bntDangKy.TabIndex = 0;
            bntDangKy.Text = "Đăng Kí";
            bntDangKy.UseVisualStyleBackColor = false;
            bntDangKy.Click += bntDangKy_Click;
            // 
            // Frmdkkh
            // 
            AutoScaleDimensions = new SizeF(12F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1158, 634);
            Controls.Add(panel1);
            Controls.Add(grbKhoc);
            Controls.Add(grbhocvien);
            Controls.Add(txtDKKHNH);
            Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            ForeColor = SystemColors.ActiveCaption;
            Margin = new Padding(5, 3, 5, 3);
            Name = "Frmdkkh";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Kí Khóa Học";
            Load += Frmdkkh_Load;
            grbhocvien.ResumeLayout(false);
            grbhocvien.PerformLayout();
            grbKhoc.ResumeLayout(false);
            grbKhoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtDKKHNH;
        private TextBox txtSoDienThoai;
        private GroupBox grbhocvien;
        private Label lblhoten;
        private Label label2;
        private TextBox txtHoTen;
        private Label lblDemKyTu;
        private Label txtNgaySinh;
        private Label txtSDT;
        private Label lblTrangThaiEmail;
        private CheckBox chkNhanEmail;
        private GroupBox grbKhoc;
        private ComboBox cboKhoaHoc;
        private Label lblKhoaHoc;
        private DateTimePicker dtpNgaySinh;
        private Label lblHinhThucHoc;
        private RadioButton radOffline;
        private NumericUpDown numSoThang;
        private Label lblSoThang;
        private Label lblHocPhiThang;
        private Panel panel1;
        private Button bntThoat;
        private Button bntLamMoi;
        private Button bntDangKy;
        private Label lblTongTien1;
        private Label lblTongTien;
        private TextBox txt;
        private Label lblHocPhi;
        private RadioButton radOnline;
    }
}
