using Application.MainModule.Administration.CompanyManagement.DTO;
using Application.MainModule.Administration.FileManagement.DTO;
using Application.MainModule.Administration.FileManagement.DTOAdapters;
using Application.MainModule.Services;
using Domain.Administration;
using Domain.Entities;
using Domain.Resources.Libraries.PagedData;
using Infrastructure.Cross.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.CompanyManagement
{
    public class ServiceFile : IServiceFile
    {
        private readonly IRepositoryFile _repositoryFile;

        public ServiceFile(IRepositoryFile rFile)
        {
            _repositoryFile = rFile;
        }

        public void Insert(DTOFile file)
        {
            File _file = AdapterFile.ToEntity(file);
            _repositoryFile.Insert(_file);
            Save();
        }

        public DTOFile GetDTOFileByID(int IDFile)
        {
            return AdapterFile.ToDTO(_repositoryFile.GetByID(IDFile));
        }

        private void Save()
        {
            _repositoryFile.UnitOfWork.SaveChanges();
        }
    }
}
