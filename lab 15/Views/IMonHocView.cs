using EduManagerMVP.Models;

namespace EduManagerMVP.Views
{
    /// <summary>
    /// Interface View: Presenter chỉ làm việc với Form thông qua interface này,
    /// không truy cập trực tiếp TextBox hay DataGridView.
    /// </summary>
    public interface IMonHocView
    {
        string MaMonHoc { get; set; }
        string TenMonHoc { get; set; }
        string SoTinChi { get; set; }     // kiểu string để Presenter kiểm tra "sai kiểu"
        bool TrangThai { get; set; }
        string TuKhoa { get; set; }

        void HienThiDanhSach(List<MonHoc> ds);
        void XoaForm();
        void HienThongBao(string noiDung);
        void HienLoi(string noiDung);
        bool XacNhan(string cauHoi);
    }
}
