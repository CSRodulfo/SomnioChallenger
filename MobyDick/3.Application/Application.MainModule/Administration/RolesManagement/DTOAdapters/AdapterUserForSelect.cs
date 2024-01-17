using Application.MainModule.Administration.RolesManagement.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement.DTOAdapters
{
    public static partial class AdapterUserForSelect
    {

        public static Users ToEntityUserForSelect(this DTOUserForSelect dto)
        {
            if (dto == null) return null;

            var entity = new Users();

            entity.UserId = dto.UserId;
            entity.UserName = dto.UserName;
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;

            entity.Roles = AdapterRoleForUsers.ToEntitiesRoleForUsers(dto.Roles);

            return entity;
        }

        public static DTOUserForSelect ToDTOUserForSelect(this Users entity)
        {
            if (entity == null) return null;

            var dto = new DTOUserForSelect();

            dto.UserId = entity.UserId;
            dto.UserName = entity.UserName;
            dto.FirstName = entity.FirstName;
            dto.LastName = entity.LastName;
            dto.Roles = AdapterRoleForUsers.ToDTOsRoleForUsers(entity.Roles);

            return dto;
        }

        public static List<Users> ToEntitiesUserForSelect(this IEnumerable<DTOUserForSelect> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntityUserForSelect()).ToList();
        }

        public static List<DTOUserForSelect> ToDTOs(this IEnumerable<Users> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTOUserForSelect()).ToList();
        }
    }
}
