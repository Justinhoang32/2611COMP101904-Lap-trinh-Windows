namespace ShopManagerMini.Models
{
    /// <summary>Tài khoản người dùng đăng nhập hệ thống.</summary>
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string HoTen { get; set; }
        public string VaiTro { get; set; }
    }
}
