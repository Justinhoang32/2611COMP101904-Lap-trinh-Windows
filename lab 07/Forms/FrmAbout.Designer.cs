namespace ShopManagerMini.Forms
{
    partial class FrmAbout
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTenUngDung = new Label();
            lblThongTin = new Label();
            btnDong = new Button();
            SuspendLayout();

            lblTenUngDung.Text = "ShopManagerMini";
            lblTenUngDung.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTenUngDung.Location = new Point(0, 20);
            lblTenUngDung.Size = new Size(400, 40);
            lblTenUngDung.TextAlign = ContentAlignment.MiddleCenter;

            lblThongTin.Text =
                "Ứng dụng quản lý cửa hàng mini\r\n" +
                "Phiên bản: 1.0\r\n" +
                "Môn học: COMP1019 - Lập trình trên Windows\r\n" +
                "Lớp: 2611COMP101904\r\n" +
                "Sinh viên: Hoàng Minh Nhật\r\n" +
                "MSSV: 51.01.104.066 - Nhóm 5";
            lblThongTin.Location = new Point(40, 75);
            lblThongTin.Size = new Size(330, 140);

            btnDong.Name = "btnDong";
            btnDong.Text = "Đóng";
            btnDong.Location = new Point(150, 225);
            btnDong.Size = new Size(100, 32);
            btnDong.DialogResult = DialogResult.OK;
            btnDong.UseVisualStyleBackColor = true;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 275);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Giới thiệu";
            AcceptButton = btnDong;
            CancelButton = btnDong;
            Controls.AddRange(new Control[] { lblTenUngDung, lblThongTin, btnDong });
            ResumeLayout(false);
        }

        private Label lblTenUngDung;
        private Label lblThongTin;
        private Button btnDong;
    }
}
