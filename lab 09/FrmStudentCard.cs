using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;

namespace StudentCardPrinter
{
    /// <summary>Form thiết kế và in thẻ sinh viên.</summary>
    public partial class FrmStudentCard : Form
    {

        private const float CardWidth = 540f;
        private const float CardHeight = 340f;

        private static readonly Color DefaultCardColor = Color.FromArgb(238, 247, 247);
        private Color _cardColor = DefaultCardColor;

        public FrmStudentCard()
        {
            InitializeComponent();
            InitializeData();
            RegisterEvents();
        }


        private void InitializeData()
        {
            cboClass.Items.AddRange(new object[] { "K49.CNTT.A", "K49.CNTT.B", "K50.CNTT.A", "K51.CNTT.A" });
            cboFaculty.Items.AddRange(new object[] { "Công nghệ thông tin", "Toán - Tin học", "Vật lý", "Hóa học" });
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });

            cboClass.SelectedIndex = 0;
            cboFaculty.SelectedIndex = 0;
            cboGender.SelectedIndex = 0;
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            printDocument1.DocumentName = "The sinh vien";
        }

        private void RegisterEvents()
        {
            btnChoosePhoto.Click += btnChoosePhoto_Click;
            btnPreviewPrint.Click += btnPreviewPrint_Click;
            btnPrint.Click += btnPrint_Click;
            btnClear.Click += btnClear_Click;
            btnExit.Click += (s, e) => Close();
            btnCardColor.Click += btnCardColor_Click;
            btnSavePng.Click += btnSavePng_Click;

            pnlCardPreview.Paint += pnlCardPreview_Paint;
            printDocument1.PrintPage += printDocument1_PrintPage;  

            txtStudentId.TextChanged += InputChanged;
            txtFullName.TextChanged += InputChanged;
            txtCourse.TextChanged += InputChanged;
            cboClass.SelectedIndexChanged += InputChanged;
            cboClass.TextChanged += InputChanged;
            cboFaculty.SelectedIndexChanged += InputChanged;
            cboFaculty.TextChanged += InputChanged;
            cboGender.SelectedIndexChanged += InputChanged;
            dtpBirthDate.ValueChanged += InputChanged;

            FormClosed += (s, e) =>
            {
                picAvatar.Image?.Dispose();
                printPreviewDialog1.Dispose();
            };
        }



        private void btnChoosePhoto_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title = "Chọn ảnh sinh viên",
                Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
          
                using Image temp = Image.FromFile(dlg.FileName);
                Image copy = new Bitmap(temp);

                Image old = picAvatar.Image;
                picAvatar.Image = copy;
                old?.Dispose();

                pnlCardPreview.Invalidate();
            }
            catch (Exception)
            {
                MessageBox.Show("File được chọn không phải ảnh hợp lệ.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private StudentCardInfo GetStudentInfo()
        {
            return new StudentCardInfo
            {
                StudentId = txtStudentId.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                ClassName = cboClass.Text.Trim(),
                Faculty = cboFaculty.Text.Trim(),
                Course = txtCourse.Text.Trim(),
                BirthDate = dtpBirthDate.Value,
                Gender = cboGender.Text,
                Photo = picAvatar.Image,
                CardColor = _cardColor
            };
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                Warn("Vui lòng nhập mã sinh viên.");
                txtStudentId.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                Warn("Vui lòng nhập họ tên.");
                txtFullName.Focus();
                return false;
            }
            if (picAvatar.Image == null)
            {
                Warn("Vui lòng chọn ảnh sinh viên.");
                btnChoosePhoto.Focus();
                return false;
            }
            if (dtpBirthDate.Value.Date > DateTime.Today)
            {
                Warn("Ngày sinh không được lớn hơn ngày hiện tại.");
                dtpBirthDate.Focus();
                return false;
            }
            return true;
        }

        private static void Warn(string message) =>
            MessageBox.Show(message, "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);

  

        private void InputChanged(object sender, EventArgs e) => pnlCardPreview.Invalidate();

        private void pnlCardPreview_Paint(object sender, PaintEventArgs e)
        {
            Rectangle area = new Rectangle(10, 10, pnlCardPreview.Width - 20, pnlCardPreview.Height - 20);
            DrawStudentCard(e.Graphics, area, GetStudentInfo());
        }


        private void DrawStudentCard(Graphics g, Rectangle target, StudentCardInfo s)
        {
            float scale = Math.Min(target.Width / CardWidth, target.Height / CardHeight);
            if (scale <= 0) return;

            float offsetX = target.Left + (target.Width - CardWidth * scale) / 2f;
            float offsetY = target.Top + (target.Height - CardHeight * scale) / 2f;

            GraphicsState state = g.Save();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            g.TranslateTransform(offsetX, offsetY);
            g.ScaleTransform(scale, scale);

            Color navy = Color.Navy;
            using var schoolFont = new Font("Arial", 15, FontStyle.Bold, GraphicsUnit.Pixel);
            using var titleFont = new Font("Arial", 26, FontStyle.Bold, GraphicsUnit.Pixel);
            using var labelFont = new Font("Arial", 13, FontStyle.Bold, GraphicsUnit.Pixel);
            using var normalFont = new Font("Arial", 13, FontStyle.Regular, GraphicsUnit.Pixel);
            using var noteFont = new Font("Arial", 11, FontStyle.Italic, GraphicsUnit.Pixel);
            using var navyBrush = new SolidBrush(navy);
            using var bgBrush = new SolidBrush(s.CardColor);
            using var borderPen = new Pen(navy, 3);
            using var linePen = new Pen(navy, 1.5f);
            using var center = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            g.FillRectangle(bgBrush, 0, 0, CardWidth, CardHeight);

            g.FillRectangle(navyBrush, 0, 0, CardWidth, 52);
            g.DrawString("TRƯỜNG ĐẠI HỌC SƯ PHẠM TP. HỒ CHÍ MINH", schoolFont, Brushes.White,
                new RectangleF(0, 0, CardWidth, 52), center);

            g.DrawString("THẺ SINH VIÊN", titleFont, navyBrush, new RectangleF(0, 56, CardWidth, 42), center);
            g.DrawLine(linePen, 30, 100, CardWidth - 30, 100);

            RectangleF photoBox = new RectangleF(30, 112, 120, 160);
            g.FillRectangle(Brushes.White, photoBox);
            if (s.Photo != null)
                DrawImageZoom(g, s.Photo, photoBox);
            else
                g.DrawString("Ảnh 3x4", normalFont, Brushes.Gray, photoBox, center);
            g.DrawRectangle(Pens.Gray, photoBox.X, photoBox.Y, photoBox.Width, photoBox.Height);

            float infoX = 175, infoY = 114, step = 28;
            DrawInfoLine(g, "MSSV:", s.StudentId, labelFont, normalFont, infoX, infoY);
            DrawInfoLine(g, "Họ tên:", s.FullName, labelFont, normalFont, infoX, infoY + step);
            DrawInfoLine(g, "Lớp:", s.ClassName, labelFont, normalFont, infoX, infoY + step * 2);
            DrawInfoLine(g, "Khoa:", s.Faculty, labelFont, normalFont, infoX, infoY + step * 3);
            DrawInfoLine(g, "Khóa:", s.Course, labelFont, normalFont, infoX, infoY + step * 4);
            DrawInfoLine(g, "Ngày sinh:", s.BirthDate.ToString("dd/MM/yyyy"), labelFont, normalFont, infoX, infoY + step * 5);
            DrawInfoLine(g, "Giới tính:", s.Gender, labelFont, normalFont, infoX, infoY + step * 6);

            if (!string.IsNullOrWhiteSpace(s.StudentId))
                DrawFakeQr(g, s.StudentId, 440, 205, 77);

            g.DrawString("Thẻ có giá trị trong thời gian học tập tại trường", noteFont, Brushes.DimGray,
                new RectangleF(0, 308, CardWidth, 24), center);

            g.DrawRectangle(borderPen, 1.5f, 1.5f, CardWidth - 3, CardHeight - 3);

            g.Restore(state);
        }

        private static void DrawInfoLine(Graphics g, string label, string value,
            Font labelFont, Font normalFont, float x, float y)
        {
            using var sf = new StringFormat
            {
                Trimming = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.NoWrap
            };

            float valueWidth = (y + 22 > 205) ? 160 : 255;

            g.DrawString(label, labelFont, Brushes.Black, x, y);
            g.DrawString(value ?? string.Empty, normalFont, Brushes.Black,
                new RectangleF(x + 95, y, valueWidth, 22), sf);
        }

        private static void DrawImageZoom(Graphics g, Image image, RectangleF box)
        {
            float ratio = Math.Min(box.Width / image.Width, box.Height / image.Height);
            float width = image.Width * ratio;
            float height = image.Height * ratio;
            float x = box.Left + (box.Width - width) / 2f;
            float y = box.Top + (box.Height - height) / 2f;
            g.DrawImage(image, new RectangleF(x, y, width, height));
        }

        private static void DrawFakeQr(Graphics g, string seedText, float x, float y, float size)
        {
            const int modules = 11;
            float cell = size / modules;

            int seed = 17;
            foreach (char c in seedText) seed = unchecked(seed * 31 + c);
            var rnd = new Random(seed);

            g.FillRectangle(Brushes.White, x - 3, y - 3, size + 6, size + 6);

            for (int r = 0; r < modules; r++)
            {
                for (int c = 0; c < modules; c++)
                {
                    bool finderZone = (r < 4 && c < 4) || (r < 4 && c > modules - 5) || (r > modules - 5 && c < 4);
                    bool dark;
                    if (finderZone)
                    {
                        int rr = r > modules - 5 ? r - (modules - 4) : r;
                        int cc = c > modules - 5 ? c - (modules - 4) : c;
                        dark = rr < 3 && cc < 3 && !(rr == 1 && cc == 1);   // ô định vị có tâm trắng
                    }
                    else
                    {
                        dark = rnd.Next(2) == 1;
                    }
                    if (dark) g.FillRectangle(Brushes.Black, x + c * cell, y + r * cell, cell, cell);
                }
            }
        }



        private void btnPreviewPrint_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.Width = 900;
                printPreviewDialog1.Height = 700;
                printPreviewDialog1.ShowDialog(this);
            }
            catch (InvalidPrinterException)
            {
                MessageBox.Show("Không tìm thấy máy in. Vui lòng cài đặt máy in (ví dụ Microsoft Print to PDF).",
                    "Lỗi máy in", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                printDialog1.Document = printDocument1;
                if (printDialog1.ShowDialog(this) == DialogResult.OK)
                    printDocument1.Print();
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể in. Vui lòng kiểm tra máy in và thử lại.",
                    "Lỗi in ấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            StudentCardInfo info = GetStudentInfo();

            int width = Math.Min((int)CardWidth, e.MarginBounds.Width);
            int height = (int)(width * CardHeight / CardWidth);
            Rectangle area = new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top, width, height);

            DrawStudentCard(e.Graphics, area, info);
            e.HasMorePages = false;
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentId.Clear();
            txtFullName.Clear();
            txtCourse.Clear();
            cboClass.SelectedIndex = cboClass.Items.Count > 0 ? 0 : -1;
            cboFaculty.SelectedIndex = cboFaculty.Items.Count > 0 ? 0 : -1;
            cboGender.SelectedIndex = cboGender.Items.Count > 0 ? 0 : -1;
            dtpBirthDate.Value = DateTime.Today;
            _cardColor = DefaultCardColor;

            Image old = picAvatar.Image;
            picAvatar.Image = null;
            old?.Dispose();

            pnlCardPreview.Invalidate();
            txtStudentId.Focus();
        }


        private void btnCardColor_Click(object sender, EventArgs e)
        {
            using var dlg = new ColorDialog { Color = _cardColor };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _cardColor = dlg.Color;
                pnlCardPreview.Invalidate();
            }
        }

        private void btnSavePng_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            using var dlg = new SaveFileDialog
            {
                Title = "Lưu thẻ sinh viên",
                Filter = "PNG Image|*.png",
                FileName = "the-sinh-vien.png"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                int w = (int)(CardWidth * 2), h = (int)(CardHeight * 2);   // xuất gấp đôi cho nét
                using var bmp = new Bitmap(w, h);
                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    DrawStudentCard(g, new Rectangle(0, 0, w, h), GetStudentInfo());
                }
                bmp.Save(dlg.FileName, ImageFormat.Png);
                MessageBox.Show("Đã lưu thẻ sinh viên thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể lưu file. Vui lòng kiểm tra đường dẫn và quyền ghi file.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
