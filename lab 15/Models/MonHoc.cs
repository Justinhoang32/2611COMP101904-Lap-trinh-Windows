namespace EduManagerMVP.Models
{
    /// <summary>Model: dữ liệu một môn học.</summary>
    public class MonHoc
    {
        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public int SoTinChi { get; set; }
        public bool TrangThai { get; set; } = true;
    }
}
