using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using Infrastructure.Data;
using Domain.Entities;
using Application.MainModule.Services;

namespace Application.MainModule.Administration.RolesManagement
{

    /// <summary>
    /// Assembler for <see cref="Roles"/> and <see cref="DTORoles"/>.
    /// </summary>
    public static partial class AdapterRoleForMenues
    {
        /// <summary>
        /// Converts this instance of <see cref="DTORoles"/> to an instance of <see cref="Roles"/>.
        /// </summary>
        /// <param name="dto"><see cref="DTORoles"/> to convert.</param>
        public static Roles ToEntityRoleForMenues(this DTORoleForMenues dto)
        {
            if (dto == null) return null;

            var entity = new Roles();

            entity.RoleId = dto.RoleId;
            entity.RoleName = dto.RoleName;
            entity.Menu = AdapterMenuesForRole.ToEntitiesMenuesForRole(dto.Menues);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="Roles"/> to an instance of <see cref="DTORoles"/>.
        /// </summary>
        /// <param name="entity"><see cref="Roles"/> to convert.</param>
        public static DTORoleForMenues ToDTORoleForMenues(this Roles entity)
        {
            if (entity == null) return null;

            var dto = new DTORoleForMenues();

            dto.RoleId = entity.RoleId;
            dto.RoleName = entity.RoleName;
            dto.Menues = AdapterMenuesForRole.ToDTOsMenuesForRole(entity.Menu);

            return dto;
        }
    }
}