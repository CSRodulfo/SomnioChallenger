//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2013/07/04 - 10:51:22
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement
{
    [DataContract()]
    public partial class DTORoles
    {
        [DataMember()]
        public Int32 RoleId { get; set; }

        [DataMember()]
        public String RoleName { get; set; }

        [DataMember()]
        public List<DTOMenu> MenusInRole { get; set; }

        public DTORoles()
        {
        }

        public DTORoles(Int32 roleId, String roleName, List<DTOMenu> menusInRole)
        {
			this.RoleId = roleId;
			this.RoleName = roleName;
            this.MenusInRole = menusInRole;
        }
    }
}
