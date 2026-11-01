using System.Drawing;
using System.Windows.Forms;

namespace COMP1019_Lab08_SimplePaint
{
    /// <summary>Panel tùy chỉnh bật DoubleBuffered để giảm nhấp nháy khi vẽ.</summary>
    public class DrawSurface : Panel
    {
        public DrawSurface()
        {
            DoubleBuffered = true;
            BackColor = Color.White;
            Dock = DockStyle.Fill;
        }
    }
}
