using Application.MainModule.Administration.RolesManagement.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement
{
    public static partial class AdapterMenuForAuthorization
    {
        public static DTOMenuForAuthorization ToDTOMenuForAuthorization(this Menu entity)
        {
            if (entity == null) return null;

            var dto = new DTOMenuForAuthorization();

            dto.Area = entity.Area;
            dto.Controller = entity.Controller;
            dto.Action = entity.Action;

            return dto;
        }

        public static List<DTOMenuForAuthorization> ToDTOsMenuForAuthorization(this IEnumerable<Menu> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTOMenuForAuthorization()).ToList();
        }
    }
}
