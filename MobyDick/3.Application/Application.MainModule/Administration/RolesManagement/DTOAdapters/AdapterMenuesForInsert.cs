using Application.MainModule.Administration.RolesManagement.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement
{
    public static partial class AdapterMenuesForInsert
    {

        public static Menu ToEntityMenuesForInsert(this DTOMenuesForInsert dto)
        {
            if (dto == null) return null;

            var entity = new Menu();
            entity.Name = dto.Name;
            entity.ParentMenu = ToEntityMenuesForInsert(dto.ParentMenu);
            entity.IDParent = dto.IDParentMenu != 0 ? dto.IDParentMenu : null;
            entity.Description = dto.Description;


            //Datos de la vista
            entity.Action = dto.Action;
            entity.Area = dto.Area;
            entity.Controller = dto.Controller;
            
            return entity;
        }

    }
}
