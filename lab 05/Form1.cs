using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Frmdkkh : Form
    {
        int[] dsHocPhi = { 800000, 750000, 700000 };

        public Frmdkkh()
        {
            InitializeComponent();
        }

        private void Frmdkkh_Load(object sender, EventArgs e) { 
    
            cboKhoaHoc.Items.Clear();
            cboKhoaHoc.Items.Add("Lập Trình Windows Form");
            cboKhoaHoc.Items.Add("Lập Trình Web");
            cboKhoaHoc.Items.Add("Cơ Sở Dữ Liệu");

            cboKhoaHoc.SelectedIndex = 0;

            radOnline.Checked = true;
            numSoThang.Minimum = 1; 
            numSoThang.Maximum = 12; 
            numSoThang.Value = 1;    

            lblDemKyTu.Text = txtHoTen.Text.Length.ToString() + "/50";

            TinhVaHienThiTien();
            txtHoTen.Focus();
        }

        private void TinhVaHienThiTien()
        {
            if (cboKhoaHoc.SelectedIndex < 0) return;

            int viTri = cboKhoaHoc.SelectedIndex;
            int hocPhi1Thang = dsHocPhi[viTri];

            int soThang = (int)numSoThang.Value;

            int tongTien = hocPhi1Thang * soThang;
            lblHocPhi.Text = hocPhi1Thang.ToString("N0") + " VNĐ";
            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhVaHienThiTien();
        }

        private void numSoThang_ValueChanged(object sender, EventArgs e)
        {
            TinhVaHienThiTien();
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            lblDemKyTu.Text = txtHoTen.Text.Length.ToString() + "/50";
        }

        private void chkNhanEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNhanEmail.Checked)
            {
                lblTrangThaiEmail.Text = "Có Nhận Email Thông Báo";
            }
            else 
            {
                lblTrangThaiEmail.Text = "Không Nhận Email Thông Báo";
            }
        }

        private void bntDangKy_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Họ Tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus(); 
                return; 
            }

            if (txtSoDienThoai.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            string hoTen = txtHoTen.Text;
            string sdt = txtSoDienThoai.Text;
            string ngaySinh = dtpNgaySinh.Value.ToString("dd/MM/yyyy");
            string khoaHoc = cboKhoaHoc.Text;
            string hinhThuc = radOnline.Checked ? "Online" : "Trực tiếp"; 
            string soThang = numSoThang.Value.ToString();
            string trangThaiEmail = chkNhanEmail.Checked ? "Có" : "Không";
            string tongTien = lblTongTien.Text; 

            string thongTinPhieu = "PHIẾU ĐĂNG KÝ KHÓA HỌC\n" +
                                   "-----------------------------------\n" +
                                   "Họ tên: " + hoTen + "\n" +
                                   "Số điện thoại: " + sdt + "\n" +
                                   "Ngày sinh: " + ngaySinh + "\n" +
                                   "Khóa học: " + khoaHoc + "\n" +
                                   "Hình thức học: " + hinhThuc + "\n" +
                                   "Số tháng: " + soThang + "\n" +
                                   "Tổng tiền: " + tongTien + "\n" +
                                   "Nhận email: " + trangThaiEmail;

            MessageBox.Show(thongTinPhieu, "Đăng Ký Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bntLamMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            chkNhanEmail.Checked = false;
            cboKhoaHoc.SelectedIndex = 0;
            radOnline.Checked = true;
            numSoThang.Value = 1;

            lblDemKyTu.Text = "0/50";
            txtHoTen.Focus();
        }

        private void bntThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?",
                                                  "Xác nhận thoát",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtDKKHNH_Click(object sender, EventArgs e) { }
        private void grbhocvien_Enter(object sender, EventArgs e) { }
        private void lblTrangThaiEmail_Click(object sender, EventArgs e) { }
        private void txtNgaySinh_Click(object sender, EventArgs e) { }
        private void lblDemKyTu_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void lblHinhThucHoc_Click(object sender, EventArgs e) { }
        private void lblKhoaHoc_Click(object sender, EventArgs e) { }
        private void lblHocPhi_Click(object sender, EventArgs e) { }
        private void label3_Click_1(object sender, EventArgs e) { }

        private void txtHoTen_TextChanged_1(object sender, EventArgs e)
        {
            lblDemKyTu.Text = txtHoTen.Text.Length.ToString() + "/50";
        }
        }
    }
