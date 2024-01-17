using Application.MainModule.Administration.RolesManagement.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement
{
    public interface IServiceMenues
    {
        void Insert(DTOMenuesForInsert dto);

        List<DTOMenu> GetAll();

        List<DTOMenuForList> GetAllMenuDTOForList();

        DTOMenuesForEdit GetDTOMenuesForEditById(int id);

        void Edit(DTOMenuesForTreeEdit dto);

        void AdvEdit(DTOMenuesForEdit dto);

        void Delete(int id);

        bool RequiresAuthorization(string controller, string area);
    }
}