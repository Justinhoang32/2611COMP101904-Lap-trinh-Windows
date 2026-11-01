namespace COMP1019_Lab08_SimplePaint
{
    partial class FrmPaint
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            topPanel = new Panel();
            lblMode = new Label();
            cboMode = new ComboBox();
            lblWidth = new Label();
            nudWidth = new NumericUpDown();
            btnColor = new Button();
            chkFill = new CheckBox();
            btnBackColor = new Button();
            btnUndo = new Button();
            btnClear = new Button();
            btnOpenImage = new Button();
            btnSave = new Button();
            lblStatus = new Label();
            canvas = new DrawSurface();

            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudWidth).BeginInit();
            SuspendLayout();

            // topPanel
            topPanel.Name = "topPanel";
            topPanel.Dock = DockStyle.Top;
            topPanel.Height = 52;
            topPanel.BackColor = Color.FromArgb(238, 247, 247);
            topPanel.Controls.AddRange(new Control[] { lblMode, cboMode, lblWidth, nudWidth, btnColor, chkFill, btnBackColor, btnUndo, btnClear, btnOpenImage, btnSave });

            lblMode.Text = "Mode";
            lblMode.Location = new Point(12, 17);
            lblMode.AutoSize = true;

            cboMode.Name = "cboMode";
            cboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMode.Items.AddRange(new object[] { "Pen", "Line", "Rectangle", "Ellipse" });
            cboMode.Location = new Point(62, 13);
            cboMode.Size = new Size(110, 28);

            lblWidth.Text = "Width";
            lblWidth.Location = new Point(185, 17);
            lblWidth.AutoSize = true;

            nudWidth.Name = "nudWidth";
            nudWidth.Minimum = 1;
            nudWidth.Maximum = 20;
            nudWidth.Value = 3;
            nudWidth.Location = new Point(240, 13);
            nudWidth.Size = new Size(60, 27);

            btnColor.Name = "btnColor";
            btnColor.Text = "Color";
            btnColor.Location = new Point(315, 10);
            btnColor.Size = new Size(80, 32);
            btnColor.UseVisualStyleBackColor = false;

            chkFill.Name = "chkFill";
            chkFill.Text = "Fill";
            chkFill.Location = new Point(410, 15);
            chkFill.AutoSize = true;

            btnBackColor.Name = "btnBackColor";
            btnBackColor.Text = "Background";
            btnBackColor.Location = new Point(470, 10);
            btnBackColor.Size = new Size(105, 32);
            btnBackColor.UseVisualStyleBackColor = true;

            btnUndo.Name = "btnUndo";
            btnUndo.Text = "Undo";
            btnUndo.Location = new Point(590, 10);
            btnUndo.Size = new Size(70, 32);
            btnUndo.UseVisualStyleBackColor = true;

            btnClear.Name = "btnClear";
            btnClear.Text = "Clear";
            btnClear.Location = new Point(665, 10);
            btnClear.Size = new Size(70, 32);
            btnClear.UseVisualStyleBackColor = true;

            btnOpenImage.Name = "btnOpenImage";
            btnOpenImage.Text = "Open image";
            btnOpenImage.Location = new Point(750, 10);
            btnOpenImage.Size = new Size(100, 32);
            btnOpenImage.UseVisualStyleBackColor = true;

            btnSave.Name = "btnSave";
            btnSave.Text = "Save PNG";
            btnSave.Location = new Point(855, 10);
            btnSave.Size = new Size(95, 32);
            btnSave.UseVisualStyleBackColor = true;

            // lblStatus
            lblStatus.Name = "lblStatus";
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Height = 26;
            lblStatus.Text = "Ready";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;

            // canvas
            canvas.Name = "canvas";
            canvas.Dock = DockStyle.Fill;
            canvas.BackColor = Color.White;

            // FrmPaint
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            MinimumSize = new Size(980, 400);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "COMP1019 - Simple Paint";
            Controls.Add(canvas);
            Controls.Add(lblStatus);
            Controls.Add(topPanel);

            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudWidth).EndInit();
            ResumeLayout(false);
        }

        private Panel topPanel;
        private Label lblMode;
        private Label lblWidth;
        private ComboBox cboMode;
        private NumericUpDown nudWidth;
        private Button btnColor;
        private CheckBox chkFill;
        private Button btnBackColor;
        private Button btnUndo;
        private Button btnClear;
        private Button btnOpenImage;
        private Button btnSave;
        private Label lblStatus;
        private DrawSurface canvas;
    }
}
