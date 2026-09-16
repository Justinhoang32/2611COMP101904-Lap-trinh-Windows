namespace Session01_helloWindow
{
    partial class Form1
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
            txtungdung = new Label();
            label1 = new Label();
            txtHoTen = new TextBox();
            label2 = new Label();
            txtNamSinh = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            radNam = new RadioButton();
            radNu = new RadioButton();
            groupBox1 = new GroupBox();
            label4 = new Label();
            cboKhoa = new ComboBox();
            btnHienThi = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtungdung
            // 
            txtungdung.AutoSize = true;
            txtungdung.BackColor = SystemColors.ButtonHighlight;
            txtungdung.Font = new Font("Times New Roman", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtungdung.ForeColor = SystemColors.Highlight;
            txtungdung.Location = new Point(21, 18);
            txtungdung.Name = "txtungdung";
            txtungdung.Size = new Size(478, 45);
            txtungdung.TabIndex = 0;
            txtungdung.Text = "THÔNG TIN SINH VIÊN \r\n";
            txtungdung.Click += txthote_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 138);
            label1.Name = "label1";
            label1.Size = new Size(128, 25);
            label1.TabIndex = 1;
            label1.Text = "Họ Và Tên: ";
            label1.Click += txtHoTen_Click;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(137, 136);
            txtHoTen.Multiline = true;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(274, 31);
            txtHoTen.TabIndex = 2;
            txtHoTen.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 187);
            label2.Name = "label2";
            label2.Size = new Size(112, 25);
            label2.TabIndex = 3;
            label2.Text = "Năm Sinh:";
            // 
            // txtNamSinh
            // 
            txtNamSinh.Location = new Point(137, 184);
            txtNamSinh.Multiline = true;
            txtNamSinh.Name = "txtNamSinh";
            txtNamSinh.Size = new Size(274, 31);
            txtNamSinh.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 244);
            label3.Name = "label3";
            label3.Size = new Size(75, 25);
            label3.TabIndex = 5;
            label3.Text = "Email:";
            label3.Click += label2_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(137, 238);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(274, 31);
            txtEmail.TabIndex = 6;
            // 
            // radNam
            // 
            radNam.AutoSize = true;
            radNam.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radNam.Location = new Point(133, 28);
            radNam.Name = "radNam";
            radNam.Size = new Size(82, 29);
            radNam.TabIndex = 7;
            radNam.TabStop = true;
            radNam.Text = "Nam";
            radNam.UseVisualStyleBackColor = true;
            // 
            // radNu
            // 
            radNu.AutoSize = true;
            radNu.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radNu.ForeColor = SystemColors.ActiveCaptionText;
            radNu.Location = new Point(295, 28);
            radNu.Name = "radNu";
            radNu.Size = new Size(66, 29);
            radNu.TabIndex = 8;
            radNu.TabStop = true;
            radNu.Text = "Nữ";
            radNu.UseVisualStyleBackColor = true;
            radNu.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radNu);
            groupBox1.Controls.Add(radNam);
            groupBox1.Font = new Font("Times New Roman", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 295);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(412, 63);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Giới Tính";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 384);
            label4.Name = "label4";
            label4.Size = new Size(116, 25);
            label4.TabIndex = 10;
            label4.Text = "Khoa/Lớp:";
            // 
            // cboKhoa
            // 
            cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Items.AddRange(new object[] { "Khoa Công nghệ Thông tin ", "Khoa Hóa", "Khoa Vật Lý ", "Khoa Toán - Tin" });
            cboKhoa.Location = new Point(137, 384);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(269, 33);
            cboKhoa.TabIndex = 11;
            // 
            // btnHienThi
            // 
            btnHienThi.BackColor = SystemColors.InactiveBorder;
            btnHienThi.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHienThi.Location = new Point(21, 454);
            btnHienThi.Name = "btnHienThi";
            btnHienThi.Size = new Size(130, 49);
            btnHienThi.TabIndex = 12;
            btnHienThi.Text = "Hiển Thị ";
            btnHienThi.UseVisualStyleBackColor = false;
            btnHienThi.Click += btnHienThi_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = SystemColors.InactiveBorder;
            btnXoa.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(196, 454);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(130, 49);
            btnXoa.TabIndex = 13;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.InactiveBorder;
            btnThoat.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(369, 454);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(130, 49);
            btnThoat.TabIndex = 14;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(533, 602);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnHienThi);
            Controls.Add(cboKhoa);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(txtNamSinh);
            Controls.Add(label2);
            Controls.Add(txtHoTen);
            Controls.Add(label1);
            Controls.Add(txtungdung);
            Name = "Form1";
            Text = "Thông Tin Sinh Viên";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtungdung;
        private Label label1;
        private TextBox txtHoTen;
        private Label label2;
        private TextBox txtNamSinh;
        private Label label3;
        private TextBox txtEmail;
        private RadioButton radNam;
        private RadioButton radNu;
        private GroupBox groupBox1;
        private Label label4;
        private ComboBox cboKhoa;
        private Button btnHienThi;
        private Button btnXoa;
        private Button btnThoat;
    }
}
