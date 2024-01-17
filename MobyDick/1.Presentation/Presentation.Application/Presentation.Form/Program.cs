using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WebMatrix.WebData;
using Application.MainModule.Security;
using Presentation.DesktopForm.Common;
using Application.MainModule.Administration.Authentication;
using Presentation.DesktopForm.View;
using Presentation.DesktopForm.Area.Administration.Security.Login;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new MDIHome());

        }
    }
}
