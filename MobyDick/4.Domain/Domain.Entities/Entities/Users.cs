using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public partial class Users : IAuditable
    {
        public bool HasAssignedRoles()
        {
            return this.Roles.Count > 0;
        }
    }
}
