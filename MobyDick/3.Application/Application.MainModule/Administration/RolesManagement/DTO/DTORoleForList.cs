using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement
{
    [DataContract()]
    public partial class DTORoleForList
    {
        [DataMember()]
        public Int32 RoleId { get; set; }

        [DataMember()]
        public Domain.Resources.Define.RoleAssignationState AssignationState { get; set; }

        [DataMember()]
        public String RoleName { get; set; }

        [DataMember()]
        public String EnableViewDeleted { get; set; }

        public DTORoleForList()
        {
        }
    }
}
