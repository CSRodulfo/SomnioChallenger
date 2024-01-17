using Application.MainModule.Administration.RolesManagement.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement
{
    public static partial class AdapterMenuesForEdit
    {
        public static Menu ToEntityMenuesForEdit(this DTOMenuesForEdit dto)
        {
            if (dto == null) return null;

            var entity = new Menu();
            entity.IDMenu = dto.IDMenu;
            entity.Name = dto.Name;
            entity.ParentMenu = ToEntityMenuesForEdit(dto.ParentMenu);
            entity.IDParent = dto.IDParentMenu != 0 ? dto.IDParentMenu : null;
            entity.Description = dto.Description;


            //Datos de la vista
            entity.Action = dto.Action;
            entity.Area = dto.Area;
            entity.Controller = dto.Controller;


            return entity;
        }

        public static DTOMenuesForEdit ToDTOMenuesForEdit(this Menu entity)
        {
            if (entity == null) return null;

            var dto = new DTOMenuesForEdit();

            dto.IDMenu = entity.IDMenu;
            dto.Name = entity.Name;
            dto.Area = entity.Area;
            dto.Controller = entity.Controller;
            dto.Action = entity.Action;
            dto.Description = entity.Description;
            dto.IDParentMenu = entity.IDParent;

            return dto;
        }
    }
}
