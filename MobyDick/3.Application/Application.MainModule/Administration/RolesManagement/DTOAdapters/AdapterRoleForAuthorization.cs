using Application.MainModule.Administration.RolesManagement.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement
{
    public static partial class AdapterRoleForAuthorization
    {
        public static DTORoleForAuthorization ToDTORoleForAuthorization(this Roles entity)
        {
            if (entity == null) return null;

            var dto = new DTORoleForAuthorization();

            dto.IDRole = entity.RoleId;
            dto.RoleName = entity.RoleName;
            dto.Menues = AdapterMenuForAuthorization.ToDTOsMenuForAuthorization(entity.Menu);

            return dto;
        }

        public static List<DTORoleForAuthorization> ToDTOsMenuForAuthorization(this IEnumerable<Roles> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTORoleForAuthorization()).ToList();
        }
    }
}
