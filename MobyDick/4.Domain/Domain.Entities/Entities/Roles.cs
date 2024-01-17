using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public partial class Roles
    {
        public Domain.Resources.Define.RoleAssignationState GetMenuStatus()
        {
            return this.Menu.Count > 0 ? Domain.Resources.Define.RoleAssignationState.Assigned : Domain.Resources.Define.RoleAssignationState.NotAssigned;
        }
    }
}