namespace ShopManagerMini.Forms
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnDangNhap = new Button();
            btnThoat = new Button();
            lblGoiY = new Label();
            SuspendLayout();

            lblTieuDe.Text = "ĐĂNG NHẬP";
            lblTieuDe.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTieuDe.Location = new Point(0, 15);
            lblTieuDe.Size = new Size(360, 32);
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;

            lblUsername.Text = "Tên đăng nhập:";
            lblUsername.Location = new Point(25, 68);
            lblUsername.AutoSize = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Location = new Point(140, 65);
            txtUsername.Size = new Size(195, 27);

            lblPassword.Text = "Mật khẩu:";
            lblPassword.Location = new Point(25, 108);
            lblPassword.AutoSize = true;
            txtPassword.Name = "txtPassword";
            txtPassword.Location = new Point(140, 105);
            txtPassword.Size = new Size(195, 27);
            txtPassword.UseSystemPasswordChar = true;

            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.Location = new Point(140, 150);
            btnDangNhap.Size = new Size(95, 32);
            btnDangNhap.UseVisualStyleBackColor = true;

            btnThoat.Name = "btnThoat";
            btnThoat.Text = "Thoát";
            btnThoat.Location = new Point(240, 150);
            btnThoat.Size = new Size(95, 32);
            btnThoat.DialogResult = DialogResult.Cancel;
            btnThoat.UseVisualStyleBackColor = true;

            lblGoiY.Text = "Tài khoản mẫu: admin/123 hoặc user/123";
            lblGoiY.ForeColor = SystemColors.GrayText;
            lblGoiY.Location = new Point(0, 198);
            lblGoiY.Size = new Size(360, 20);
            lblGoiY.TextAlign = ContentAlignment.MiddleCenter;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 230);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ShopManagerMini - Đăng nhập";
            AcceptButton = btnDangNhap;
            CancelButton = btnThoat;
            Controls.AddRange(new Control[] { lblTieuDe, lblUsername, txtUsername, lblPassword, txtPassword, btnDangNhap, btnThoat, lblGoiY });
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTieuDe;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblGoiY;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnDangNhap;
        private Button btnThoat;
    }
}
