using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using Application.MainModule.Services;
using Domain.Resources.Libraries.PagedData;
using Application.MainModule.Administration.FileManagement.DTO;
using Application.MainModule.Administration.CompanyManagement.DTO;

namespace Application.MainModule.Administration.CompanyManagement
{
    public interface IServiceCompany
    {
        void Edit(DTOCompany company);

        DTOCompany GetDTOCompany();
    }
}