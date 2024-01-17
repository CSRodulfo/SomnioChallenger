using Application.MainModule.Administration.RolesManagement.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration
{
    public static partial class AdapterUserForSelectList
    {
        public static DTOUserForSelectListItem ToDTOUserForSelectList(this Users entity)
        {
            if (entity == null) return null;

            var dto = new DTOUserForSelectListItem();

            dto.UserId = entity.UserId;
            dto.UserName = entity.UserName;

            return dto;
        }

        public static List<DTOUserForSelectListItem> ToDTOsUserForSelectList(this IEnumerable<Users> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTOUserForSelectList()).ToList();
        }
    }
}