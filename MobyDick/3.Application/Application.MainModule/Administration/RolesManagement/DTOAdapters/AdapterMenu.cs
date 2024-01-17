//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2013/07/04 - 10:51:23
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

    /// <summary>
    /// Assembler for <see cref="Menu"/> and <see cref="DTOMenu"/>.
    /// </summary>
    public static partial class AdapterMenu
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="DTOMenu"/> converted from <see cref="Menu"/>.</param>
        static partial void OnDTO(this Menu entity, DTOMenu dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="Menu"/> converted from <see cref="DTOMenu"/>.</param>
        static partial void OnEntity(this DTOMenu dto, Menu entity);

        /// <summary>
        /// Converts this instance of <see cref="DTOMenu"/> to an instance of <see cref="Menu"/>.
        /// </summary>
        /// <param name="dto"><see cref="DTOMenu"/> to convert.</param>
        public static Menu ToEntity(this DTOMenu dto)
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

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="Menu"/> to an instance of <see cref="DTOMenu"/>.
        /// </summary>
        /// <param name="entity"><see cref="Menu"/> to convert.</param>
        public static DTOMenu ToDTOMenu(this Menu entity)
        {
            if (entity == null) return null;

            var dto = new DTOMenu();

            dto.IDMenu = entity.IDMenu;
            dto.Name = entity.Name;
            dto.Area = entity.Area;
            dto.Controller = entity.Controller;
            dto.Action = entity.Action;
            dto.Description = entity.Description;
            dto.IDParent = entity.IDParent;
            dto.IDMenuModule = entity.IDMenuModule;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="DTOMenu"/> to an instance of <see cref="Menu"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<Menu> ToEntities(this IEnumerable<DTOMenu> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="Menu"/> to an instance of <see cref="DTOMenu"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<DTOMenu> ToDTOs(this IEnumerable<Menu> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTOMenu()).ToList();
        }

    }
}
