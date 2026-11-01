using EduManagerMVP.Models;

namespace EduManagerMVP.Repositories
{
    /// <summary>Repository lưu dữ liệu trong bộ nhớ (List) kèm dữ liệu mẫu.</summary>
    public class MonHocRepository : IMonHocRepository
    {
        private readonly List<MonHoc> _ds = new List<MonHoc>
        {
            new MonHoc { MaMonHoc = "COMP1019", TenMonHoc = "Lập trình trên Windows", SoTinChi = 3, TrangThai = true },
            new MonHoc { MaMonHoc = "COMP1010", TenMonHoc = "Cơ sở dữ liệu", SoTinChi = 3, TrangThai = true },
            new MonHoc { MaMonHoc = "COMP1020", TenMonHoc = "Lập trình hướng đối tượng", SoTinChi = 4, TrangThai = true },
            new MonHoc { MaMonHoc = "COMP1030", TenMonHoc = "Cấu trúc dữ liệu và giải thuật", SoTinChi = 4, TrangThai = true },
            new MonHoc { MaMonHoc = "COMP9999", TenMonHoc = "Môn học cũ", SoTinChi = 2, TrangThai = false }
        };

        public List<MonHoc> GetAll() => _ds.OrderBy(m => m.MaMonHoc).ToList();

        public MonHoc GetById(string ma) =>
            _ds.FirstOrDefault(m => string.Equals(m.MaMonHoc, ma, StringComparison.OrdinalIgnoreCase));

        public bool Exists(string ma) => GetById(ma) != null;

        public List<MonHoc> Search(string tuKhoa) =>
            _ds.Where(m => m.MaMonHoc.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase)
                        || m.TenMonHoc.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase))
               .OrderBy(m => m.MaMonHoc).ToList();

        public void Add(MonHoc monHoc) => _ds.Add(monHoc);

        public bool Delete(string ma)
        {
            var mh = GetById(ma);
            return mh != null && _ds.Remove(mh);
        }
    }
}
