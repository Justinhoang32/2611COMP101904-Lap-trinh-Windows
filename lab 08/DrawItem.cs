using System.Drawing;

namespace COMP1019_Lab08_SimplePaint
{
    /// <summary>
    /// Dữ liệu gốc của một nét vẽ / một hình. Paint event dựa vào danh sách
    /// DrawItem để vẽ lại, nên hình không bị mất khi resize hoặc bị che.
    /// </summary>
    public class DrawItem
    {
        public DrawMode Mode { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }
        public Color Color { get; set; }
        public float Width { get; set; }

        /// <summary>True: tô màu bên trong hình chữ nhật / ellipse.</summary>
        public bool Fill { get; set; }

        /// <summary>Các điểm của nét vẽ tự do (chế độ Pen).</summary>
        public List<Point> Points { get; set; } = new List<Point>();
    }
}
