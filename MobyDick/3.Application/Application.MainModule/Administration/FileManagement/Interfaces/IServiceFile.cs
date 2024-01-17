using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using Application.MainModule.Services;
using Domain.Resources.Libraries.PagedData;
using Application.MainModule.Administration.FileManagement.DTO;

namespace Application.MainModule.Administration.CompanyManagement
{
    public interface IServiceFile
    {
        void Insert(DTOFile file);

        DTOFile GetDTOFileByID(int idFile);
    }
}