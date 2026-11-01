using EduManager.Data;
using EduManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EduManager.DAL
{
    
    public class MonHocDAL
    {
        public List<MonHoc> GetAll()
        {
            using var db = new EduManagerContext();
            return db.MonHocs.AsNoTracking().OrderBy(m => m.MaMonHoc).ToList();
        }

        public MonHoc GetById(string maMonHoc)
        {
            using var db = new EduManagerContext();
            return db.MonHocs.AsNoTracking().FirstOrDefault(m => m.MaMonHoc == maMonHoc);
        }

        public bool Exists(string maMonHoc)
        {
            using var db = new EduManagerContext();
            return db.MonHocs.Any(m => m.MaMonHoc == maMonHoc);
        }

        public List<MonHoc> Search(string keyword)
        {
            using var db = new EduManagerContext();
            return db.MonHocs.AsNoTracking()
                     .Where(m => m.MaMonHoc.Contains(keyword) || m.TenMonHoc.Contains(keyword))
                     .OrderBy(m => m.MaMonHoc)
                     .ToList();
        }

        public void Add(MonHoc monHoc)
        {
            using var db = new EduManagerContext();
            db.MonHocs.Add(monHoc);
            db.SaveChanges();
        }

        public bool Update(MonHoc monHoc)
        {
            using var db = new EduManagerContext();
            var entity = db.MonHocs.Find(monHoc.MaMonHoc);
            if (entity == null) return false;

            entity.TenMonHoc = monHoc.TenMonHoc;
            entity.SoTinChi = monHoc.SoTinChi;
            entity.TrangThai = monHoc.TrangThai;
            db.SaveChanges();
            return true;
        }

        public bool Delete(string maMonHoc)
        {
            using var db = new EduManagerContext();
            var entity = db.MonHocs.Find(maMonHoc);
            if (entity == null) return false;

            db.MonHocs.Remove(entity);
            db.SaveChanges();
            return true;
        }
    }
}
