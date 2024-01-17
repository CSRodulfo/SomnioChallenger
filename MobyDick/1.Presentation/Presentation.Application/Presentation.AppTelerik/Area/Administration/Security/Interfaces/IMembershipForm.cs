using System;
namespace Presentation.AppTelerik.Area.Administration.Security.Interfaces
{
    public interface IMembershipForm
    {
        bool Login(string Name, string Password, bool persiste = false);
    }
}
