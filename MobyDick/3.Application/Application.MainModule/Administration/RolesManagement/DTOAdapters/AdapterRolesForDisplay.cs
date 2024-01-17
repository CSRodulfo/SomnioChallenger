using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement
{
    public static partial class AdapterRolesForDisplay
    {
        public static DTORolesForDisplay ToDTO(this Roles entity)
        {
            if (entity == null) return null;

            var dto = new DTORolesForDisplay();

            dto.RoleName = entity.RoleName;
            dto.Id = entity.RoleId;

            return dto;
        }

        public static List<DTORolesForDisplay> ToDTOs(this IEnumerable<Roles> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }
    }
}
