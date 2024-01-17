using System;
using System.Windows.Forms;
using Presentation.DesktopForm.Area.Administration.Security.Login;
using Presentation.DesktopForm.Interface;
using Presentation.DesktopForm.Common.Controls;

namespace Presentation.DesktopForm.View
{
    public partial class MDIHome : FormBase, IViewHome
    {
        public MDIHome()
        {
            InitializeComponent();
        }

        private void MDIHome_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            if (login.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                //Main main = new Main();
                //main.ShowDialog();
            }
            else
            {
                this.Close();
            }
        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.components.Components.Count > 0)
                this.components.Components[0].Dispose();

        }

        private void makesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //
        }

        public void OpenVehiclesList()
        {
        }

        public void OpenMakesInsertion()
        {
            MessageBox.Show("Todavia no se hizo esta funcionalidad");
        }


    }
}
