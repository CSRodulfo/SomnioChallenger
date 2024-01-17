using Presentation.AppWPF.Area.Administration.Security.Interfaces;
using Presentation.ServiceDistribution;
using Presentation.ServiceDistribution.ServiceSecurity;

namespace Presentation.AppWPF.Area.Administration.Security.Model
{
    public class MembershipForm : IMembershipForm
    {
        public bool Login(string Name, string Password, bool persiste = false)
        {
            try
            {
                IServiceMembershipProvider p = LocalizadorProxy.GetServiceMembershipProvider();
                return p.Login(Name, Password, persiste);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}