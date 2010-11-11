using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Inventory
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
            Login frm = new Login();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                frm.Close();
                Application.Run(new MainPage());
            }
        }
    }
}