using ShopManagerMini.Forms;

namespace ShopManagerMini
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            while (true)
            {
                using var login = new FrmLogin();
                if (login.ShowDialog() != DialogResult.OK) break;   

                var main = new FrmMain(login.NguoiDung);             
                Application.Run(main);
                if (!main.DangXuat) break;                           
            }
        }
    }
}
