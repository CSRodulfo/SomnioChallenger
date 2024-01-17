using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.Authentication
{
    public interface ISecurityRoles
    {
        List<string> GetAllRoles();
        
        List<string> GetRolesForUser();

        void CreateRole(string roleName);

        bool IsUserInRole(string roleName);
    }
}
