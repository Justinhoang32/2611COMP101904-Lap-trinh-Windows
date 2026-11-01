using EduManagerMVP.Views;

namespace EduManagerMVP
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmMonHoc());
        }
    }
}
