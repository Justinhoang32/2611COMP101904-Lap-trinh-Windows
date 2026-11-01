namespace ShopManagerMini.Models
{
    /// <summary>Sản phẩm của cửa hàng.</summary>
    public class Product
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string LoaiSanPham { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
    }
}
