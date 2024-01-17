using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement
{
    public static partial class AdapterMenuForDisplay
    {
        public static DTOMenuForDisplay ToDTO(this Menu entity)
        {
            if (entity == null) return null;

            var dto = new DTOMenuForDisplay();

            dto.Action = entity.Action;
            dto.Controller = entity.Controller;
            dto.Id = entity.IDMenu;
            dto.Roles = AdapterRolesForDisplay.ToDTOs(entity.Roles);
            dto.subMenues = ToDTOs(entity.SubMenues);
            dto.Axis_X = entity.Axis_X;
            dto.Axis_Y = entity.Axis_Y;
            dto.Name = entity.Name;
            dto.Area = entity.Area;

            return dto;
        }

        public static List<DTOMenuForDisplay> ToDTOs(this IEnumerable<Menu> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }
    }
}
