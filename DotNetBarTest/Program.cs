using System;
using System.Windows.Forms;
using SRSmartManufacturing;

namespace GoldArch.DotNetBar.Test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormLogin());

            var frm = new FormLogin();
            frm.ShowDialog();
            if (frm.DialogResult==DialogResult.OK)
            {
                var frmMain = new FormMain();
                FormMain.FormMainInstance = frmMain;
                Application.Run(frmMain);
            }
        }
    }
}
