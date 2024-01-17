using Application.MainModule.Administration.RolesManagement.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement
{
    public static partial class AdapterMenuesForTreeEdit
    {
        public static Menu ToEntityMenuesForTreeEdit(this DTOMenuesForTreeEdit dto)
        {
            if (dto == null) return null;

            var entity = new Menu();
            entity.IDMenu = dto.IDMenu;
            entity.Name = dto.Name;
            entity.IDParent = dto.IDParent;
            entity.Orden = dto.Orden;
            entity.SubMenues = ToEntitiesMenuesForTreeEdit(dto.SubMenues);

            return entity;
        }

        public static List<Menu> ToEntitiesMenuesForTreeEdit(this IEnumerable<DTOMenuesForTreeEdit> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntityMenuesForTreeEdit()).ToList();
        }
    }
}
