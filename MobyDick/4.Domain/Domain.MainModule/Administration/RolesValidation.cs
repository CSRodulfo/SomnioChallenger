using Application.MainModule.Administration.RolesManagement.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.MainModule.Administration
{
    public class RolesValidation : IRolesValidation
    {
        public List<Roles> GetRolesForParentMenu(Menu parentMenu)
        {
            return GetRoles(parentMenu);
        }

        private List<Roles> GetRoles(Menu parentMenu)
        {
            List<Roles> hierachyRoles = parentMenu.Roles.ToList();

            if (parentMenu.SubMenues.Count > 0)
            {
                foreach (Menu child in parentMenu.SubMenues)
                {
                    hierachyRoles = GetRoles(child);
                }
            }

            foreach (Roles role in parentMenu.Roles)
            {
                if(!hierachyRoles.Any(r=>r.RoleId == role.RoleId))
                    hierachyRoles.Add(role);
            }

            return hierachyRoles;
        }
    }
}
