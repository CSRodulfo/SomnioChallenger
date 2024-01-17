using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement
{
    public static partial class AdapterMenuForTitle
    {
        public static DTOMenuForTitle ToDTOForTitle(this Menu entity)
        {
            if (entity == null) return null;

            var dto = new DTOMenuForTitle();

            dto.Action = entity.Action;
            dto.Controller = entity.Controller;
            dto.Id = entity.IDMenu;
            dto.parentMenu = ToDTOForTitle(entity.ParentMenu);
            dto.Name = entity.Name;
            dto.Area = entity.Area;

            return dto;
        }

        public static List<DTOMenuForTitle> ToDTOs(this IEnumerable<Menu> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTOForTitle()).ToList();
        }
    }
}
