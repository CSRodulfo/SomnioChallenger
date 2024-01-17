using System.Collections.Generic;
using Infrastructure.Cross.Security.Roles;
using Application.MainModule.Administration.Authentication;

namespace Domain.MainModule.Administration.Security.Authentication
{
    public class SecurityRoles : ISecurityRoles
    {
        private IRolesService service;

        public SecurityRoles(RolesService service)
        {
            this.service = service;
        }

        public List<string> GetAllRoles()
        {
            return new List<string>(service.GetAllRoles());
        }

        public List<string> GetRolesForUser()
        {
            return new List<string>(service.GetRolesForUser());
        }

        public void CreateRole(string roleName)
        {
            service.CreateRole(roleName);
        }

        public bool IsUserInRole(string roleName)
        {
            return service.IsUserInRole(roleName);
        }
    }
}
