using System.Drawing;

namespace StudentCardPrinter
{
    /// <summary>
    /// Gom toàn bộ dữ liệu cần vẽ lên thẻ. Tách dữ liệu khỏi control để
    /// cùng một hàm vẽ dùng được cho cả preview, in và lưu PNG.
    /// </summary>
    public class StudentCardInfo
    {
        public string StudentId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string Faculty { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = string.Empty;
        public Image Photo { get; set; }
        public Color CardColor { get; set; } = Color.FromArgb(238, 247, 247);
    }
}
