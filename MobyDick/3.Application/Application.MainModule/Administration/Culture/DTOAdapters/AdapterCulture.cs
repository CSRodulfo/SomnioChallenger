
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Infrastructure.Data;
using Domain.Entities;
using Application.MainModule.Services;
using Application.MainModule.Administration.Culture.DTO;


namespace Application.MainModule.Administration.Culture
{

    /// <summary>
    /// Assembler for <see cref="Company"/> and <see cref="DTOCompany"/>.
    /// </summary>
    public static partial class AdapterCulture
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="DTOUser"/> converted from <see cref="Users"/>.</param>
        static partial void OnDTO(this Domain.Entities.Culture entity, DTOCulture dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="Users"/> converted from <see cref="DTOUser"/>.</param>
        static partial void OnEntity(this DTOCulture dto, Domain.Entities.Culture entity);

        /// <summary>
        /// Converts this instance of <see cref="DTOUser"/> to an instance of <see cref="Users"/>.
        /// </summary>
        /// <param name="dto"><see cref="DTOUser"/> to convert.</param>
        public static Domain.Entities.Culture ToEntity(this DTOCulture dto)
        {
            if (dto == null) return null;

            var entity = new Domain.Entities.Culture();

            entity.IdCulture = dto.IdCulture;
            entity.Description = dto.Description;
            entity.Code = dto.Code;


            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="Users"/> to an instance of <see cref="DTOUser"/>.
        /// </summary>
        /// <param name="entity"><see cref="Users"/> to convert.</param>
        public static DTOCulture ToDTO(this Domain.Entities.Culture entity)
        {
            if (entity == null) return null;

            var dto = new DTOCulture();

            dto.IdCulture = entity.IdCulture;
            dto.Description = entity.Description;
            dto.Code = entity.Code;

            entity.OnDTO(dto);

            return dto; ;
        }



        /// <summary>
        /// Converts each instance of <see cref="DTOUser"/> to an instance of <see cref="Users"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<Domain.Entities.Culture> ToEntities(this IEnumerable<DTOCulture> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="Users"/> to an instance of <see cref="DTOUser"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<DTOCulture> ToDTOs(this IEnumerable<Domain.Entities.Culture> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }


    }
}
