using EduManager.DAL;
using EduManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EduManager.BLL
{
  
    public class KetQua
    {
        public bool ThanhCong { get; set; }
        public string ThongBao { get; set; }

        public static KetQua Ok(string msg) => new KetQua { ThanhCong = true, ThongBao = msg };
        public static KetQua Loi(string msg) => new KetQua { ThanhCong = false, ThongBao = msg };
    }

  
    public class MonHocBLL
    {
        private readonly MonHocDAL _dal = new MonHocDAL();

        public List<MonHoc> LayDanhSach() => _dal.GetAll();

        public List<MonHoc> TimKiem(string tuKhoa)
        {
            tuKhoa = (tuKhoa ?? "").Trim();
            return tuKhoa.Length == 0 ? _dal.GetAll() : _dal.Search(tuKhoa);
        }

        public KetQua Them(MonHoc mh)
        {
            var loi = KiemTra(mh);
            if (loi != null) return KetQua.Loi(loi);

            try
            {
                if (_dal.Exists(mh.MaMonHoc))
                    return KetQua.Loi($"Mã môn học \"{mh.MaMonHoc}\" đã tồn tại. Vui lòng nhập mã khác.");

                _dal.Add(mh);
                return KetQua.Ok("Thêm môn học thành công.");
            }
            catch (Exception ex)
            {
                return KetQua.Loi(DichLoi(ex));
            }
        }

        public KetQua Sua(MonHoc mh)
        {
            var loi = KiemTra(mh);
            if (loi != null) return KetQua.Loi(loi);

            try
            {
                return _dal.Update(mh)
                    ? KetQua.Ok("Cập nhật môn học thành công.")
                    : KetQua.Loi("Không tìm thấy môn học cần sửa. Có thể môn học đã bị xóa.");
            }
            catch (Exception ex)
            {
                return KetQua.Loi(DichLoi(ex));
            }
        }

        public KetQua Xoa(string maMonHoc)
        {
            if (string.IsNullOrWhiteSpace(maMonHoc))
                return KetQua.Loi("Vui lòng chọn môn học cần xóa.");

            try
            {
                return _dal.Delete(maMonHoc.Trim())
                    ? KetQua.Ok("Xóa môn học thành công.")
                    : KetQua.Loi("Không tìm thấy môn học cần xóa. Có thể môn học đã bị xóa.");
            }
            catch (Exception ex)
            {
                return KetQua.Loi(DichLoi(ex));
            }
        }

        
        private static string KiemTra(MonHoc mh)
        {
            if (mh == null) return "Dữ liệu môn học không hợp lệ.";

            mh.MaMonHoc = (mh.MaMonHoc ?? "").Trim();
            mh.TenMonHoc = (mh.TenMonHoc ?? "").Trim();

            if (mh.MaMonHoc.Length == 0) return "Mã môn học không được để trống.";
            if (mh.MaMonHoc.Length > 10) return "Mã môn học tối đa 10 ký tự.";
            if (mh.TenMonHoc.Length == 0) return "Tên môn học không được để trống.";
            if (mh.TenMonHoc.Length > 100) return "Tên môn học tối đa 100 ký tự.";
            if (mh.SoTinChi < 1 || mh.SoTinChi > 6) return "Số tín chỉ phải nằm trong khoảng từ 1 đến 6.";
            return null;
        }

        private static string DichLoi(Exception ex)
        {
            if (ex is DbUpdateException)
                return "Không thể lưu dữ liệu. Dữ liệu có thể bị trùng hoặc vi phạm ràng buộc của cơ sở dữ liệu.";
            return "Không thể kết nối hoặc thao tác với cơ sở dữ liệu. " +
                   "Vui lòng kiểm tra SQL Server và chuỗi kết nối.";
        }
    }
}
