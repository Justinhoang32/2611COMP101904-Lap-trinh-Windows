using EduManagerMVP.Models;
using EduManagerMVP.Repositories;
using EduManagerMVP.Views;

namespace EduManagerMVP.Presenters
{
   
    public class MonHocPresenter
    {
        private readonly IMonHocView _view;
        private readonly IMonHocRepository _repo;

        public MonHocPresenter(IMonHocView view, IMonHocRepository repo)
        {
            _view = view;
            _repo = repo;
        }

        public void LoadDanhSach()
        {
            _view.HienThiDanhSach(_repo.GetAll());
        }

        public void ChonMonHoc(string ma)
        {
            var mh = _repo.GetById(ma);
            if (mh == null) return;
            _view.MaMonHoc = mh.MaMonHoc;
            _view.TenMonHoc = mh.TenMonHoc;
            _view.SoTinChi = mh.SoTinChi.ToString();
            _view.TrangThai = mh.TrangThai;
        }

        /// <summary>Thêm môn học mới sau khi kiểm tra dữ liệu.</summary>
        public void ThemMonHoc()
        {
            string ma = (_view.MaMonHoc ?? "").Trim();
            string ten = (_view.TenMonHoc ?? "").Trim();
            string tc = (_view.SoTinChi ?? "").Trim();

            if (ma.Length == 0) { _view.HienLoi("Mã môn học không được để trống."); return; }
            if (ten.Length == 0) { _view.HienLoi("Tên môn học không được để trống."); return; }
            if (tc.Length == 0) { _view.HienLoi("Số tín chỉ không được để trống."); return; }
            if (!int.TryParse(tc, out int soTinChi))
            { _view.HienLoi("Số tín chỉ phải là một số nguyên."); return; }
            if (soTinChi < 1 || soTinChi > 6)
            { _view.HienLoi("Số tín chỉ phải nằm trong khoảng từ 1 đến 6."); return; }
            if (_repo.Exists(ma))
            { _view.HienLoi($"Mã môn học \"{ma}\" đã tồn tại. Vui lòng nhập mã khác."); return; }

            _repo.Add(new MonHoc
            {
                MaMonHoc = ma,
                TenMonHoc = ten,
                SoTinChi = soTinChi,
                TrangThai = _view.TrangThai
            });

            LoadDanhSach();
            _view.XoaForm();
            _view.HienThongBao("Thêm môn học thành công.");
        }

        /// <summary>Xóa môn học theo mã đang nhập/chọn.</summary>
        public void XoaMonHoc()
        {
            string ma = (_view.MaMonHoc ?? "").Trim();
            if (ma.Length == 0)
            { _view.HienLoi("Vui lòng nhập hoặc chọn mã môn học cần xóa."); return; }
            if (!_repo.Exists(ma))
            { _view.HienLoi($"Không tìm thấy môn học có mã \"{ma}\"."); return; }
            if (!_view.XacNhan($"Bạn có chắc muốn xóa môn học \"{ma}\" không?")) return;

            _repo.Delete(ma);
            LoadDanhSach();
            _view.XoaForm();
            _view.HienThongBao("Xóa môn học thành công.");
        }

        public void TimKiem()
        {
            string tuKhoa = (_view.TuKhoa ?? "").Trim();
            var ds = tuKhoa.Length == 0 ? _repo.GetAll() : _repo.Search(tuKhoa);
            _view.HienThiDanhSach(ds);
            if (ds.Count == 0) _view.HienThongBao("Không tìm thấy môn học phù hợp.");
        }

        public void LamMoi()
        {
            _view.TuKhoa = "";
            _view.XoaForm();
            LoadDanhSach();
        }
    }
}
