using Application.MainModule.Administration.RolesManagement.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement
{
    public static partial class AdapterMenuForList
    {
       /* public static Menu ToEntityDTOMenuForList(this DTOMenu dto)
        {
            if (dto == null) return null;

            var entity = new Menu();

            entity.IDMenu = dto.IDMenu;
            entity.Name = dto.Name;
            entity.Area = dto.Area;
            entity.Controller = dto.Controller;
            entity.Action = dto.Action;
            entity.Description = dto.Description;
            entity.IDParent = dto.IDParent;
            entity.IDMenuModule = dto.IDMenuModule;


            return entity;
        }*/

        public static DTOMenuForList ToDTOMenuForList(this Menu entity)
        {
            if (entity == null) return null;

            DTOMenuForList dto = new DTOMenuForList();

            dto.IDMenu = entity.IDMenu;
            dto.Name = entity.Name;
            dto.Description = entity.Description;

            dto.AssignedRoles = new List<string>();

            foreach (Roles role in entity.Roles)
            {
                dto.AssignedRoles.Add(role.RoleName);
            }

            dto.SubMenues = ToDTOsMenuForList(entity.SubMenues);

            return dto;
        }

        public static List<DTOMenuForList> ToDTOsMenuForList(this IEnumerable<Menu> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTOMenuForList()).ToList();
        }
    }
}
