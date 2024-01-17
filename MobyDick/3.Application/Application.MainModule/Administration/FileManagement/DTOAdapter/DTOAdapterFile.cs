using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using Application.MainModule.Administration.RolesManagement.DTO;
using Infrastructure.Data;
using Domain.Entities;
using Application.MainModule.Administration.FileManagement.DTO;

namespace Application.MainModule.Administration.FileManagement.DTOAdapters
{
    public static partial class AdapterFile
    {
        static partial void OnDTO(this File entity, DTOFile dto);

        static partial void OnEntity(this DTOFile dto, File entity);

        public static File ToEntity(this DTOFile dto)
        {
            if (dto == null) return null;

            var entity = new File();

            entity.IdFile = dto.IdFile;
            entity.FileData = dto.FileData;
            entity.MimeType = dto.MimeType;
            entity.Date = dto.Date;
            entity.FileName = dto.FileName;

            dto.OnEntity(entity);

            return entity;
        }

        public static DTOFile ToDTO(this File entity)
        {
            if (entity == null) return null;

            var dto = new DTOFile();

            dto.IdFile = entity.IdFile;
            dto.FileData = entity.FileData;
            dto.MimeType = entity.MimeType;
            dto.Date = entity.Date;
            dto.FileName = entity.FileName;

            entity.OnDTO(dto);

            return dto;
        }
    }
}