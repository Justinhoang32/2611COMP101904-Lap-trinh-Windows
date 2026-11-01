using EduManagerMVP.Models;

namespace EduManagerMVP.Repositories
{
    /// <summary>Hợp đồng lưu/truy xuất dữ liệu môn học.</summary>
    public interface IMonHocRepository
    {
        List<MonHoc> GetAll();
        MonHoc GetById(string ma);
        bool Exists(string ma);
        List<MonHoc> Search(string tuKhoa);
        void Add(MonHoc monHoc);
        bool Delete(string ma);
    }
}
