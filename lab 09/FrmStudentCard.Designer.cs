using System.Drawing.Printing;

namespace StudentCardPrinter
{
    partial class FrmStudentCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpInput = new GroupBox();
            lblStudentId = new Label();
            lblFullName = new Label();
            lblClass = new Label();
            lblFaculty = new Label();
            lblCourse = new Label();
            lblBirthDate = new Label();
            lblGender = new Label();
            lblPhoto = new Label();
            txtStudentId = new TextBox();
            txtFullName = new TextBox();
            cboClass = new ComboBox();
            cboFaculty = new ComboBox();
            txtCourse = new TextBox();
            dtpBirthDate = new DateTimePicker();
            cboGender = new ComboBox();
            picAvatar = new PictureBox();
            btnChoosePhoto = new Button();
            btnPreviewPrint = new Button();
            btnPrint = new Button();
            btnClear = new Button();
            btnExit = new Button();
            grpPreview = new GroupBox();
            pnlCardPreview = new BufferedPanel();
            btnCardColor = new Button();
            btnSavePng = new Button();
            printDocument1 = new PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            printDialog1 = new PrintDialog();

            grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            grpPreview.SuspendLayout();
            SuspendLayout();

            // ----- grpInput -----
            grpInput.Text = "Thông tin sinh viên";
            grpInput.Location = new Point(12, 12);
            grpInput.Size = new Size(405, 598);
            grpInput.Controls.AddRange(new Control[] {
                lblStudentId, txtStudentId, lblFullName, txtFullName, lblClass, cboClass,
                lblFaculty, cboFaculty, lblCourse, txtCourse, lblBirthDate, dtpBirthDate,
                lblGender, cboGender, lblPhoto, picAvatar, btnChoosePhoto,
                btnPreviewPrint, btnPrint, btnClear, btnExit });

            lblStudentId.Text = "Mã sinh viên:";
            lblStudentId.Location = new Point(15, 33);
            lblStudentId.AutoSize = true;
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Location = new Point(125, 30);
            txtStudentId.Size = new Size(255, 27);
            txtStudentId.MaxLength = 15;

            lblFullName.Text = "Họ tên:";
            lblFullName.Location = new Point(15, 73);
            lblFullName.AutoSize = true;
            txtFullName.Name = "txtFullName";
            txtFullName.Location = new Point(125, 70);
            txtFullName.Size = new Size(255, 27);
            txtFullName.MaxLength = 60;

            lblClass.Text = "Lớp:";
            lblClass.Location = new Point(15, 113);
            lblClass.AutoSize = true;
            cboClass.Name = "cboClass";
            cboClass.Location = new Point(125, 110);
            cboClass.Size = new Size(255, 28);

            lblFaculty.Text = "Khoa:";
            lblFaculty.Location = new Point(15, 153);
            lblFaculty.AutoSize = true;
            cboFaculty.Name = "cboFaculty";
            cboFaculty.Location = new Point(125, 150);
            cboFaculty.Size = new Size(255, 28);

            lblCourse.Text = "Khóa học:";
            lblCourse.Location = new Point(15, 193);
            lblCourse.AutoSize = true;
            txtCourse.Name = "txtCourse";
            txtCourse.Location = new Point(125, 190);
            txtCourse.Size = new Size(255, 27);
            txtCourse.MaxLength = 10;

            lblBirthDate.Text = "Ngày sinh:";
            lblBirthDate.Location = new Point(15, 233);
            lblBirthDate.AutoSize = true;
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Format = DateTimePickerFormat.Custom;
            dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            dtpBirthDate.Location = new Point(125, 230);
            dtpBirthDate.Size = new Size(255, 27);

            lblGender.Text = "Giới tính:";
            lblGender.Location = new Point(15, 273);
            lblGender.AutoSize = true;
            cboGender.Name = "cboGender";
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.Location = new Point(125, 270);
            cboGender.Size = new Size(255, 28);

            lblPhoto.Text = "Ảnh đại diện:";
            lblPhoto.Location = new Point(15, 323);
            lblPhoto.AutoSize = true;
            picAvatar.Name = "picAvatar";
            picAvatar.Location = new Point(125, 320);
            picAvatar.Size = new Size(120, 160);
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            btnChoosePhoto.Name = "btnChoosePhoto";
            btnChoosePhoto.Text = "Chọn ảnh...";
            btnChoosePhoto.Location = new Point(260, 320);
            btnChoosePhoto.Size = new Size(120, 34);
            btnChoosePhoto.UseVisualStyleBackColor = true;

            btnPreviewPrint.Name = "btnPreviewPrint";
            btnPreviewPrint.Text = "Xem trước in";
            btnPreviewPrint.Location = new Point(15, 510);
            btnPreviewPrint.Size = new Size(180, 34);
            btnPreviewPrint.UseVisualStyleBackColor = true;

            btnPrint.Name = "btnPrint";
            btnPrint.Text = "In";
            btnPrint.Location = new Point(205, 510);
            btnPrint.Size = new Size(175, 34);
            btnPrint.UseVisualStyleBackColor = true;

            btnClear.Name = "btnClear";
            btnClear.Text = "Làm mới";
            btnClear.Location = new Point(15, 553);
            btnClear.Size = new Size(180, 34);
            btnClear.UseVisualStyleBackColor = true;

            btnExit.Name = "btnExit";
            btnExit.Text = "Thoát";
            btnExit.Location = new Point(205, 553);
            btnExit.Size = new Size(175, 34);
            btnExit.UseVisualStyleBackColor = true;

            // ----- grpPreview -----
            grpPreview.Text = "Xem trước thẻ sinh viên";
            grpPreview.Location = new Point(430, 12);
            grpPreview.Size = new Size(558, 450);
            grpPreview.Controls.AddRange(new Control[] { pnlCardPreview, btnCardColor, btnSavePng });

            pnlCardPreview.Name = "pnlCardPreview";
            pnlCardPreview.Location = new Point(15, 28);
            pnlCardPreview.Size = new Size(528, 350);
            pnlCardPreview.BackColor = Color.FromArgb(225, 225, 225);
            pnlCardPreview.BorderStyle = BorderStyle.FixedSingle;

            btnCardColor.Name = "btnCardColor";
            btnCardColor.Text = "Màu thẻ...";
            btnCardColor.Location = new Point(15, 395);
            btnCardColor.Size = new Size(130, 34);
            btnCardColor.UseVisualStyleBackColor = true;

            btnSavePng.Name = "btnSavePng";
            btnSavePng.Text = "Lưu PNG...";
            btnSavePng.Location = new Point(155, 395);
            btnSavePng.Size = new Size(130, 34);
            btnSavePng.UseVisualStyleBackColor = true;

            // ----- Print components -----
            printDocument1.DocumentName = "The sinh vien";
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.UseAntiAlias = true;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Visible = false;
            printDialog1.Document = printDocument1;

            // ----- Form -----
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 622);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "COMP1019 - Thiết kế và in thẻ sinh viên";
            Controls.Add(grpInput);
            Controls.Add(grpPreview);

            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            grpPreview.ResumeLayout(false);
            ResumeLayout(false);
        }

        private GroupBox grpInput;
        private GroupBox grpPreview;
        private Label lblStudentId;
        private Label lblFullName;
        private Label lblClass;
        private Label lblFaculty;
        private Label lblCourse;
        private Label lblBirthDate;
        private Label lblGender;
        private Label lblPhoto;
        private TextBox txtStudentId;
        private TextBox txtFullName;
        private ComboBox cboClass;
        private ComboBox cboFaculty;
        private TextBox txtCourse;
        private DateTimePicker dtpBirthDate;
        private ComboBox cboGender;
        private PictureBox picAvatar;
        private Button btnChoosePhoto;
        private Button btnPreviewPrint;
        private Button btnPrint;
        private Button btnClear;
        private Button btnExit;
        private Button btnCardColor;
        private Button btnSavePng;
        private BufferedPanel pnlCardPreview;
        private PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
        private PrintDialog printDialog1;
    }
}
