using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WallhavenSyncNm.src;

namespace WallhavenSyncNm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SessionManager manager = new SessionManager();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormLogin loginwindow = new FormLogin(manager);
            Application.Run(loginwindow);

            if (!manager.isLoggedIn())
                return;

            Form1 window = new Form1(manager); 
            Application.Run(window);

            
        }
    }
}
