using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement
{
    [DataContract()]
    public partial class DTORoleForMenues
    {
        [DataMember()]
        public Int32 RoleId { get; set; }

        [DataMember()]
        public String RoleName { get; set; }

        [DataMember()]
        public List<DTOMenuesForRole> Menues { get; set; }

        public DTORoleForMenues()
        {
        }
    }
}
