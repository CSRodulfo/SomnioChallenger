using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Presentation.AppWPF.Area.Administration.Security.Interfaces;
using Presentation.AppWPF.Area.Administration.Security.Model;
using Presentation.AppWPF.Common.Controls;

namespace Presentation.AppWPF.Area.Administration.Security.View
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window, IViewLogin
    {
        private Presenter.pLogin _presenter;

        public Login()
        {
            InitializeComponent();
            //this.center();
            _presenter = new Presenter.pLogin(this, new MembershipForm());
        }

        /*public void center()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);        
        }*/

        public void MenssageSucceful()
        {
            this.Hide();
            this.Show();
        }

        public void ErrorMessage()
        {
            MessageBox.Show("Usuario y/o Contraseña incorrectos", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if ((txtPassword.Password != "") && (txtUser.Text != ""))
                _presenter.Login(txtUser.Text, txtPassword.Password, false);
            else
                MessageBox.Show("Debe ingresar Usuario y Contraseña", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
