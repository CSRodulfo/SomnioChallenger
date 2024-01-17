using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using Presentation.AppWPF.Area.Administration.Security.View;
using Presentation.AppWPF.Area.Administration.Generic.View;

using Presentation.AppWPF.Interface;
using Presentation.AppWPF.Presenter;
using Presentation.AppWPF.Common.Controls;

namespace Presentation.AppWPF
{
    /// <summary>
    /// Lógica de interacción para MDIHome.xaml
    /// </summary>
    public partial class MDIHome : Window, IViewHome
    {
        public MDIHome()
        {
            InitializeComponent();
        }

        private void MDIHome_Loaded(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            bool ? dg = login.ShowDialog();
            if (dg == false)
            {
                login.Close();
                System.Windows.Application.Current.Shutdown();
            }
        }
    }
}
