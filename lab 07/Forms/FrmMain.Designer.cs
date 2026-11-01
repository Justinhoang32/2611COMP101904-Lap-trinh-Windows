namespace ShopManagerMini.Forms
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            mnuHeThong = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            mnuThoat = new ToolStripMenuItem();
            mnuDanhMuc = new ToolStripMenuItem();
            mnuSanPham = new ToolStripMenuItem();
            mnuKhachHang = new ToolStripMenuItem();
            mnuTroGiup = new ToolStripMenuItem();
            mnuGioiThieu = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblNguoiDung = new ToolStripStatusLabel();
            lblVaiTro = new ToolStripStatusLabel();
            lblThoiGian = new ToolStripStatusLabel();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuHeThong, mnuDanhMuc, mnuTroGiup });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1000, 28);
            menuStrip1.TabIndex = 1;
            // 
            // mnuHeThong
            // 
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuDangXuat, mnuThoat });
            mnuHeThong.Name = "mnuHeThong";
            mnuHeThong.Size = new Size(85, 24);
            mnuHeThong.Text = "Hệ thống";
            // 
            // mnuDangXuat
            // 
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Size = new Size(224, 26);
            mnuDangXuat.Text = "Đăng xuất";
            // 
            // mnuThoat
            // 
            mnuThoat.Name = "mnuThoat";
            mnuThoat.Size = new Size(224, 26);
            mnuThoat.Text = "Thoát";
            // 
            // mnuDanhMuc
            // 
            mnuDanhMuc.DropDownItems.AddRange(new ToolStripItem[] { mnuSanPham, mnuKhachHang });
            mnuDanhMuc.Name = "mnuDanhMuc";
            mnuDanhMuc.Size = new Size(90, 24);
            mnuDanhMuc.Text = "Danh mục";
            // 
            // mnuSanPham
            // 
            mnuSanPham.Name = "mnuSanPham";
            mnuSanPham.Size = new Size(224, 26);
            mnuSanPham.Text = "Quản lý sản phẩm";
            // 
            // mnuKhachHang
            // 
            mnuKhachHang.Name = "mnuKhachHang";
            mnuKhachHang.Size = new Size(224, 26);
            mnuKhachHang.Text = "Quản lý khách hàng";
            // 
            // mnuTroGiup
            // 
            mnuTroGiup.DropDownItems.AddRange(new ToolStripItem[] { mnuGioiThieu });
            mnuTroGiup.Name = "mnuTroGiup";
            mnuTroGiup.Size = new Size(78, 24);
            mnuTroGiup.Text = "Trợ giúp";
            // 
            // mnuGioiThieu
            // 
            mnuGioiThieu.Name = "mnuGioiThieu";
            mnuGioiThieu.Size = new Size(224, 26);
            mnuGioiThieu.Text = "Giới thiệu";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblNguoiDung, lblVaiTro, lblThoiGian });
            statusStrip1.Location = new Point(0, 628);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1000, 22);
            statusStrip1.TabIndex = 2;
            // 
            // lblNguoiDung
            // 
            lblNguoiDung.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblNguoiDung.Name = "lblNguoiDung";
            lblNguoiDung.Size = new Size(4, 16);
            // 
            // lblVaiTro
            // 
            lblVaiTro.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new Size(4, 16);
            // 
            // lblThoiGian
            // 
            lblThoiGian.Name = "lblThoiGian";
            lblThoiGian.Size = new Size(977, 16);
            lblThoiGian.Spring = true;
            lblThoiGian.TextAlign = ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(1000, 650);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ShopManagerMini - Quản lý cửa hàng mini";
            WindowState = FormWindowState.Maximized;
            Load += FrmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem mnuDanhMuc;
        private ToolStripMenuItem mnuSanPham;
        private ToolStripMenuItem mnuKhachHang;
        private ToolStripMenuItem mnuTroGiup;
        private ToolStripMenuItem mnuGioiThieu;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblNguoiDung;
        private ToolStripStatusLabel lblVaiTro;
        private ToolStripStatusLabel lblThoiGian;
        private System.Windows.Forms.Timer timer1;
    }
}
