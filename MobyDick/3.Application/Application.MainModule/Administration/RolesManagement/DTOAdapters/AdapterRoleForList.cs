//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2013/07/04 - 10:51:24
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using Infrastructure.Data;
using Domain.Entities;

namespace Application.MainModule.Administration.RolesManagement
{
    public static partial class AdapterRoleForList
    {
        public static Roles ToEntityRoleForList(this DTORoleForList dto)
        {
            if (dto == null) return null;

            var entity = new Roles();

            entity.RoleId = dto.RoleId;
            entity.RoleName = dto.RoleName;
            entity.EnableViewDeleted = (dto.EnableViewDeleted == "on" ? true : false); 

            return entity;
        }

        public static DTORoleForList ToDTORoleForList(this Roles entity)
        {
            if (entity == null) return null;

            var dto = new DTORoleForList();

            dto.RoleId = entity.RoleId;
            dto.RoleName = entity.RoleName;
            dto.AssignationState = entity.GetMenuStatus();
            dto.EnableViewDeleted = (entity.EnableViewDeleted == true ? "on" : "off");

            return dto;
        }

        public static List<DTORoleForList> ToDTOsRoleForList(this IEnumerable<Roles> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTORoleForList()).ToList();
        }

    }
}