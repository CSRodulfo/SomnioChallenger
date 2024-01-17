using System;
using System.Windows.Forms;
using Presentation.AppTelerik.Area.Administration.Security.Interfaces;
using Presentation.AppTelerik.Area.Administration.Security.Model;
using Presentation.AppTelerik.Common.Controls;
using Telerik.WinControls;

namespace Presentation.AppTelerik.Area.Administration.Security.Login
{
    public partial class Login : FormBase, IViewLogin
    {
        private Presenter.pLogin _presenter;

        public Login()
        {
            InitializeComponent();
            _presenter = new Presenter.pLogin(this, new MembershipForm());
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if ((txtPassword.Text != "") && (txtUser.Text != ""))
                _presenter.Login(txtUser.Text, txtPassword.Text, false);
            else
                MessageBox.Show("Debe ingresar Usuario y Contraseña", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void MenssageSucceful()
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        public void ErrorMessage()
        {
            MessageBox.Show("Usuario y/o Contraseña incorrectos", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ErrorMessageException(string message)
        {
            MessageBox.Show("Excepcion Interna de Autentifiacacion " + message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
