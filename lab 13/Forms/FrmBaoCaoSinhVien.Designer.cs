namespace StudentReportDemo.Forms
{
    partial class FrmBaoCaoSinhVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.cboKetQua = new System.Windows.Forms.ComboBox();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnXuatFile = new System.Windows.Forms.Button();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.lblThongKe = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.SuspendLayout();
            //
            // lblTieuDe
            //
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.Location = new System.Drawing.Point(20, 10);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(300, 25);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "BÁO CÁO DANH SÁCH SINH VIÊN";
            //
            // lblLop
            //
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(20, 58);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(27, 15);
            this.lblLop.TabIndex = 1;
            this.lblLop.Text = "Lớp:";
            //
            // cboLop
            //
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(70, 55);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(200, 23);
            this.cboLop.TabIndex = 2;
            //
            // lblKetQua
            //
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(290, 58);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(48, 15);
            this.lblKetQua.TabIndex = 3;
            this.lblKetQua.Text = "Kết quả:";
            //
            // cboKetQua
            //
            this.cboKetQua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKetQua.FormattingEnabled = true;
            this.cboKetQua.Location = new System.Drawing.Point(350, 55);
            this.cboKetQua.Name = "cboKetQua";
            this.cboKetQua.Size = new System.Drawing.Size(140, 23);
            this.cboKetQua.TabIndex = 4;
            //
            // lblTuKhoa
            //
            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Location = new System.Drawing.Point(510, 58);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(51, 15);
            this.lblTuKhoa.TabIndex = 5;
            this.lblTuKhoa.Text = "Từ khóa:";
            //
            // txtTuKhoa
            //
            this.txtTuKhoa.Location = new System.Drawing.Point(570, 55);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.PlaceholderText = "Mã SV hoặc họ tên";
            this.txtTuKhoa.Size = new System.Drawing.Size(270, 23);
            this.txtTuKhoa.TabIndex = 6;
            //
            // btnXemBaoCao
            //
            this.btnXemBaoCao.Location = new System.Drawing.Point(20, 95);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(130, 32);
            this.btnXemBaoCao.TabIndex = 7;
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = true;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            //
            // btnThongKe
            //
            this.btnThongKe.Location = new System.Drawing.Point(160, 95);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(130, 32);
            this.btnThongKe.TabIndex = 8;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            //
            // btnXuatFile
            //
            this.btnXuatFile.Location = new System.Drawing.Point(300, 95);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(130, 32);
            this.btnXuatFile.TabIndex = 9;
            this.btnXuatFile.Text = "Xuất file";
            this.btnXuatFile.UseVisualStyleBackColor = true;
            this.btnXuatFile.Click += new System.EventHandler(this.btnXuatFile_Click);
            //
            // dgvBaoCao
            //
            this.dgvBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBaoCao.AllowUserToAddRows = false;
            this.dgvBaoCao.AllowUserToDeleteRows = false;
            this.dgvBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCao.Location = new System.Drawing.Point(20, 145);
            this.dgvBaoCao.MultiSelect = false;
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.ReadOnly = true;
            this.dgvBaoCao.RowHeadersVisible = false;
            this.dgvBaoCao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaoCao.Size = new System.Drawing.Size(820, 320);
            this.dgvBaoCao.TabIndex = 10;
            //
            // lblThongKe
            //
            this.lblThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblThongKe.AutoSize = true;
            this.lblThongKe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblThongKe.Location = new System.Drawing.Point(20, 478);
            this.lblThongKe.Name = "lblThongKe";
            this.lblThongKe.Size = new System.Drawing.Size(200, 19);
            this.lblThongKe.TabIndex = 11;
            this.lblThongKe.Text = "Tổng: 0 | Đạt: 0 | Không đạt: 0 | ĐTB: 0.00";
            //
            // FrmBaoCaoSinhVien
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 510);
            this.Controls.Add(this.lblThongKe);
            this.Controls.Add(this.dgvBaoCao);
            this.Controls.Add(this.btnXuatFile);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnXemBaoCao);
            this.Controls.Add(this.txtTuKhoa);
            this.Controls.Add(this.lblTuKhoa);
            this.Controls.Add(this.cboKetQua);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.lblLop);
            this.Controls.Add(this.lblTieuDe);
            this.Name = "FrmBaoCaoSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo sinh viên bằng LINQ - Lab 13";
            this.Load += new System.EventHandler(this.FrmBaoCaoSinhVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.ComboBox cboKetQua;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnXuatFile;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.Label lblThongKe;
    }
}
