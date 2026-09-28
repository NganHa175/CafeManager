using CafeManagement.Data;
using CafeManagement.Forms.Auth;

namespace CafeManagement
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Database.Initialize();
            Application.Run(new LoginForm());
        }
    }
}
