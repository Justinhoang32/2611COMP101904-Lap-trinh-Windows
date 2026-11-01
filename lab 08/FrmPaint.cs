using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace COMP1019_Lab08_SimplePaint
{
    /// <summary>Form chính của ứng dụng Simple Paint.</summary>
    public partial class FrmPaint : Form
    {
        // Danh sách dữ liệu gốc của các nét đã vẽ
        private readonly List<DrawItem> _items = new List<DrawItem>();

        private DrawItem _currentItem;          // nét đang kéo chuột (chưa thả)
        private bool _isDrawing;
        private Color _currentColor = Color.Black;
        private Bitmap _backgroundImage;        // ảnh nền (chức năng nâng cao)

        public FrmPaint()
        {
            InitializeComponent();

            cboMode.SelectedIndex = 0;
            nudWidth.Value = 3;
            btnColor.BackColor = _currentColor;
            btnColor.ForeColor = Color.White;

            canvas.Paint += Canvas_Paint;
            canvas.MouseDown += Canvas_MouseDown;
            canvas.MouseMove += Canvas_MouseMove;
            canvas.MouseUp += Canvas_MouseUp;

            btnColor.Click += BtnColor_Click;
            btnBackColor.Click += BtnBackColor_Click;
            btnUndo.Click += (s, e) => Undo();
            btnClear.Click += BtnClear_Click;
            btnOpenImage.Click += BtnOpenImage_Click;
            btnSave.Click += BtnSave_Click;
            FormClosed += (s, e) => _backgroundImage?.Dispose();
        }

        // ---------- Dữ liệu ----------

        private DrawMode CurrentMode =>
            Enum.TryParse(cboMode.SelectedItem?.ToString(), out DrawMode mode) ? mode : DrawMode.Pen;

        private void Undo()
        {
            if (_items.Count == 0)
            {
                lblStatus.Text = "Không có nét vẽ nào để Undo.";
                return;
            }
            _items.RemoveAt(_items.Count - 1);
            canvas.Invalidate();
        }

        /// <summary>Phím tắt Ctrl+Z để Undo.</summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Z))
            {
                Undo();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // ---------- Nút chức năng ----------

        private void BtnColor_Click(object sender, EventArgs e)
        {
            using var dialog = new ColorDialog { Color = _currentColor };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _currentColor = dialog.Color;
                btnColor.BackColor = _currentColor;
                // đổi màu chữ cho dễ đọc trên màu nền của nút
                btnColor.ForeColor = (_currentColor.GetBrightness() < 0.5f) ? Color.White : Color.Black;
            }
        }

        private void BtnBackColor_Click(object sender, EventArgs e)
        {
            using var dialog = new ColorDialog { Color = canvas.BackColor };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                canvas.BackColor = dialog.Color;
                canvas.Invalidate();
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (_items.Count == 0 && _backgroundImage == null) return;

            var result = MessageBox.Show("Xóa toàn bộ nét vẽ và ảnh nền?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            _items.Clear();
            _backgroundImage?.Dispose();
            _backgroundImage = null;
            canvas.Invalidate();
        }

        private void BtnOpenImage_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Chọn ảnh nền",
                Filter = "Ảnh|*.png;*.jpg;*.jpeg;*.bmp;*.gif"
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                // Copy sang Bitmap mới để không giữ khóa file gốc
                using var tmp = Image.FromFile(dialog.FileName);
                var bmp = new Bitmap(tmp);
                _backgroundImage?.Dispose();
                _backgroundImage = bmp;
                canvas.Invalidate();
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể mở file ảnh này. Vui lòng chọn file ảnh hợp lệ.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (canvas.ClientSize.Width <= 0 || canvas.ClientSize.Height <= 0)
            {
                MessageBox.Show("Vùng vẽ quá nhỏ để lưu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var dialog = new SaveFileDialog
            {
                Title = "Lưu hình vẽ",
                Filter = "PNG Image|*.png",
                FileName = "paint.png"
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                using var bmp = new Bitmap(canvas.ClientSize.Width, canvas.ClientSize.Height);
                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(canvas.BackColor);
                    RenderScene(g, bmp.Size);
                }
                bmp.Save(dialog.FileName, ImageFormat.Png);
                MessageBox.Show("Đã lưu hình thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể lưu file. Vui lòng kiểm tra đường dẫn và quyền ghi file.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ---------- Sự kiện chuột trên canvas ----------

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;   // chuột phải không vẽ

            _isDrawing = true;
            _currentItem = new DrawItem
            {
                Mode = CurrentMode,
                Start = e.Location,
                End = e.Location,
                Color = _currentColor,
                Width = (float)nudWidth.Value,
                Fill = chkFill.Checked
            };

            if (_currentItem.Mode == DrawMode.Pen)
                _currentItem.Points.Add(e.Location);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            lblStatus.Text = $"X = {e.X}, Y = {e.Y}   |   Số nét đã vẽ: {_items.Count}";

            if (!_isDrawing || _currentItem == null) return;

            _currentItem.End = e.Location;
            if (_currentItem.Mode == DrawMode.Pen)
                _currentItem.Points.Add(e.Location);

            canvas.Invalidate();   // yêu cầu vẽ lại, không vẽ trực tiếp ở đây
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_isDrawing || _currentItem == null) return;

            _currentItem.End = e.Location;
            _items.Add(_currentItem);

            _currentItem = null;
            _isDrawing = false;
            canvas.Invalidate();
        }

        // ---------- Vẽ ----------

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            RenderScene(e.Graphics, canvas.ClientSize);
        }

        /// <summary>Vẽ ảnh nền, toàn bộ nét đã lưu và nét đang vẽ lên Graphics cho trước.</summary>
        private void RenderScene(Graphics g, Size size)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (_backgroundImage != null)
                g.DrawImage(_backgroundImage, new Rectangle(Point.Empty, size));

            foreach (DrawItem item in _items)
                DrawOneItem(g, item);

            if (_currentItem != null)
                DrawOneItem(g, _currentItem);
        }

        private void DrawOneItem(Graphics g, DrawItem item)
        {
            using var pen = new Pen(item.Color, item.Width)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };

            Rectangle rect = GetRectangle(item.Start, item.End);

            switch (item.Mode)
            {
                case DrawMode.Pen:
                    DrawFreePen(g, pen, item);
                    break;

                case DrawMode.Line:
                    g.DrawLine(pen, item.Start, item.End);
                    break;

                case DrawMode.Rectangle:
                    if (rect.Width == 0 || rect.Height == 0)
                    {
                        g.DrawLine(pen, item.Start, item.End);   // hình suy biến thành đường thẳng
                        break;
                    }
                    if (item.Fill)
                    {
                        using var brush = new SolidBrush(item.Color);
                        g.FillRectangle(brush, rect);
                    }
                    g.DrawRectangle(pen, rect);
                    break;

                case DrawMode.Ellipse:
                    if (rect.Width == 0 || rect.Height == 0)
                    {
                        g.DrawLine(pen, item.Start, item.End);
                        break;
                    }
                    if (item.Fill)
                    {
                        using var brush = new SolidBrush(item.Color);
                        g.FillEllipse(brush, rect);
                    }
                    g.DrawEllipse(pen, rect);
                    break;
            }
        }

        private static void DrawFreePen(Graphics g, Pen pen, DrawItem item)
        {
            List<Point> points = item.Points;

            if (points.Count == 1)
            {
                // Chỉ click một điểm: vẽ một chấm tròn
                using var brush = new SolidBrush(item.Color);
                float r = item.Width / 2f;
                g.FillEllipse(brush, points[0].X - r, points[0].Y - r, item.Width, item.Width);
                return;
            }

            for (int i = 1; i < points.Count; i++)
                g.DrawLine(pen, points[i - 1], points[i]);
        }

        /// <summary>Tạo hình chữ nhật hợp lệ dù kéo chuột theo hướng nào.</summary>
        private static Rectangle GetRectangle(Point start, Point end)
        {
            int x = Math.Min(start.X, end.X);
            int y = Math.Min(start.Y, end.Y);
            int width = Math.Abs(start.X - end.X);
            int height = Math.Abs(start.Y - end.Y);
            return new Rectangle(x, y, width, height);
        }
    }
}
