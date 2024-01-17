using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement.DTO
{
    [DataContract()]
    public partial class DTORoleForUsers
    {
        [DataMember()]
        public Int32 RoleId { get; set; }

        [DataMember()]
        public String RoleName { get; set; }

        public DTORoleForUsers()
        {
        }
    }
}
