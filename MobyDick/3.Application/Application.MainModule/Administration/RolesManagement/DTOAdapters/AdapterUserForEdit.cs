//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2013/09/04 - 11:36:51
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using Application.MainModule.Administration.RolesManagement.DTO;
using Infrastructure.Data;
using System.Data.Objects.DataClasses;
using Domain.Entities;
using Application.MainModule.Administration.FileManagement.DTOAdapters;

namespace Application.MainModule.Administration.RolesManagement.DTOAdapters
{

    /// <summary>
    /// Assembler for <see cref="Users"/> and <see cref="Users"/>.
    /// </summary>
    public static partial class AdapterUserForEdit
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="Users"/> converted from <see cref="Users"/>.</param>
        static partial void OnDTOUserForEdit(this Users entity, DTOUserForEdit dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="Users"/> converted from <see cref="Users"/>.</param>
        static partial void OnEntityUserForEdit(this DTOUserForEdit dto, Users entity);

        /// <summary>
        /// Converts this instance of <see cref="Users"/> to an instance of <see cref="Users"/>.
        /// </summary>
        /// <param name="dto"><see cref="Users"/> to convert.</param>
        public static Users ToEntityUserForEdit(this DTOUserForEdit dto)
        {
            if (dto == null) return null;

            var entity = new Users();

            entity.UserId = dto.UserId;
            entity.UserName = dto.UserName;
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.Email = dto.Email;
            entity.IdCulture = dto.IdCulture;
            entity.File = AdapterFile.ToEntity(dto.File);

            dto.OnEntityUserForEdit(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="Users"/> to an instance of <see cref="Users"/>.
        /// </summary>
        /// <param name="entity"><see cref="Users"/> to convert.</param>
        public static DTOUserForEdit ToDTOUserForEdit(this Users entity)
        {
            if (entity == null) return null;

            var dto = new DTOUserForEdit();

            dto.UserId = entity.UserId;
            dto.UserName = entity.UserName;
            dto.FirstName = entity.FirstName;
            dto.LastName = entity.LastName;
            dto.Email = entity.Email;
            dto.IdCulture = entity.IdCulture;
            dto.File = AdapterFile.ToDTO(entity.File);

            if (dto.File != null)
                dto.FileId = dto.File.IdFile;

            entity.OnDTOUserForEdit(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="Users"/> to an instance of <see cref="Users"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<Users> ToEntitiesUserForEdit(this IEnumerable<DTOUserForEdit> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntityUserForEdit()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="Users"/> to an instance of <see cref="Users"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<DTOUserForEdit> ToDTOsUserForEdit(this IEnumerable<Users> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTOUserForEdit()).ToList();
        }

    }
}