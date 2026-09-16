using System;
using System.Windows.Forms;

namespace Session01_helloWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Gắn sự kiện để thêm danh sách lớp khi vừa mở ứng dụng lên
            this.Load += new System.EventHandler(this.Form1_Load);
        }
        private void txthote_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void txtHoTen_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { }

        // 1. Thêm lựa chọn vào ComboBox khi mở Form
        private void Form1_Load(object sender, EventArgs e)
        {
            cboKhoa.Items.Clear();
            cboKhoa.Items.Add("Khoa Công nghệ Thông tin");
            cboKhoa.Items.Add("Khoa Hóa");
            cboKhoa.Items.Add("Khoa Vật lý");
            cboKhoa.Items.Add("Khoa Toán - Tin");
        }

        // 2. Xử lý nút Hiển thị thông tin
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống!", "Lỗi");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email không được để trống!", "Lỗi");
                return;
            }

            int namSinh;
            int namHienTai = DateTime.Now.Year;
            if (!int.TryParse(txtNamSinh.Text, out namSinh) || namSinh < 1900 || namSinh > namHienTai)
            {
                MessageBox.Show("Năm sinh phải là số nguyên từ năm 1900 đến " + namHienTai, "Lỗi");
                return;
            }

            if (!radNam.Checked && !radNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi");
                return;
            }

            if (cboKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Khoa hoặc Lớp!", "Lỗi");
                return;
            }

            int tuoi = namHienTai - namSinh;
            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";

            string ketQua = "THÔNG TIN SINH VIÊN\r\n" +
                            "Họ tên: " + txtHoTen.Text + "\r\n" +
                            "Tuổi: " + tuoi + "\r\n" +
                            "Email: " + txtEmail.Text + "\r\n" +
                            "Giới tính: " + gioiTinh + "\r\n" +
                            "Khoa/Lớp: " + cboKhoa.SelectedItem.ToString();
            MessageBox.Show(ketQua, "Kết quả");
        }

        // 3. Xử lý nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtNamSinh.Clear();
            txtEmail.Clear();
            radNam.Checked = false;
            radNu.Checked = false;
            cboKhoa.SelectedIndex = -1;
        }

        // 4. Xử lý nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traLoi = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traLoi == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}