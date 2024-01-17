using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace Infrastructure.Cross.Security.Roles
{
    /// <summary>
    /// Esto es la interfaz de la clase System.Web.Security.Roles
    /// Se resumira la cantidad de metodos que se exponen para no copiar su implementacion
    /// (Se utiliza principalmente RoleProvider)
    /// </summary>
    public interface IRolesService
    {
        string ApplicationName { get; set; }

        void AddUsersToRole(string[] usernames, string roleName);
        void AddUsersToRoles(string[] usernames, string[] roleNames);
        void AddUserToRole(string username, string roleName);
        void AddUserToRoles(string username, string[] roleNames);
        void CreateRole(string roleName);
        bool DeleteRole(string roleName);
        string[] FindUsersInRole(string roleName, string usernameToMatch);
        string[] GetAllRoles();
        string[] GetRolesForUser();
        string[] GetRolesForUser(string username);
        string[] GetUsersInRole(string roleName);

        /// <summary>
        /// Perteneces a System.Web.Security.Roles
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        bool IsUserInRole(string roleName);
        bool IsUserInRole(string username, string roleName);
        void RemoveUserFromRole(string username, string roleName);
        void RemoveUserFromRoles(string username, string[] roleNames);
        void RemoveUsersFromRole(string[] usernames, string roleName);
        void RemoveUsersFromRoles(string[] usernames, string[] roleNames);
        bool RoleExists(string roleName);

        IEnumerable<string> AvailableRolesForUser(string userName);
    }
}
