using System;
namespace Presentation.DesktopForm.Area.Administration.Security.Interfaces
{
    public interface IMembershipForm
    {
        bool Login(string Name, string Password, bool persiste = false);
    }
}
