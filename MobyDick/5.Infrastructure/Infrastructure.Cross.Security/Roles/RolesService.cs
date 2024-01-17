using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace Infrastructure.Cross.Security.Roles
{
    public class RolesService : IRolesService
    {
        #region ctors

        private readonly RoleProvider roleProvider;

        public RolesService()
        {
            this.roleProvider = System.Web.Security.Roles.Provider;
        }

        #endregion

        #region IRoleService Members

        public string ApplicationName
        {
            get
            {
                return roleProvider.ApplicationName;
            }
            set
            {
                roleProvider.ApplicationName = value;
            }
        }

        public void AddUsersToRole(string[] usernames, string roleName)
        {
            roleProvider.AddUsersToRoles(usernames, new string[] { roleName });
        }

        public void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            roleProvider.AddUsersToRoles(usernames, roleNames);
        }

        public void AddUserToRole(string username, string roleName)
        {
            roleProvider.AddUsersToRoles(new string[] { username }, new string[] { roleName });
        }

        public void AddUserToRoles(string username, string[] roleNames)
        {
            roleProvider.AddUsersToRoles(new string[] { username }, roleNames);
        }

        public void CreateRole(string roleName)
        {
            roleProvider.CreateRole(roleName);
        }

        public bool DeleteRole(string roleName)
        {
            return roleProvider.DeleteRole(roleName, true);
        }

        public string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            return roleProvider.FindUsersInRole(roleName, usernameToMatch);
        }

        public string[] GetAllRoles()
        {
            return roleProvider.GetAllRoles();
        }

        public string[] GetRolesForUser()
        {
            return System.Web.Security.Roles.GetRolesForUser();
        }

        public string[] GetRolesForUser(string username)
        {
            return roleProvider.GetRolesForUser(username);
        }

        public string[] GetUsersInRole(string roleName)
        {
            return roleProvider.GetUsersInRole(roleName);
        }

        public bool IsUserInRole(string roleName)
        {
            
            return System.Web.Security.Roles.IsUserInRole(roleName);
        }

        public bool IsUserInRole(string username, string roleName)
        {
            return roleProvider.IsUserInRole(username, roleName);
        }

        public void RemoveUserFromRole(string username, string roleName)
        {
            roleProvider.RemoveUsersFromRoles(new string[] { username }, new string[] { roleName });
        }

        public void RemoveUserFromRoles(string username, string[] roleNames)
        {
            roleProvider.RemoveUsersFromRoles(new string[] { username }, roleNames);
        }

        public void RemoveUsersFromRole(string[] usernames, string roleName)
        {
            roleProvider.RemoveUsersFromRoles(usernames, new string[] { roleName });
        }

        public void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            roleProvider.RemoveUsersFromRoles(usernames, roleNames);
        }

        public bool RoleExists(string roleName)
        {
            return roleProvider.RoleExists(roleName);
        }

        #endregion

        #region Additional Members

        /// <summary>
        /// Returns a list of Roles for which the User is not granted.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public IEnumerable<string> AvailableRolesForUser(string userName)
        {
            string[] allRoles = roleProvider.GetAllRoles();
            string[] rolesForUser = roleProvider.GetRolesForUser(userName);
            IEnumerable<string> availabileRolesForUser;

            availabileRolesForUser = allRoles.Except(rolesForUser);

            return availabileRolesForUser;
        }

        #endregion
    }
}
