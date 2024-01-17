using Application.MainModule.Administration.CompanyManagement.DTO;
using Application.MainModule.Administration.FileManagement.DTO;
using Application.MainModule.Administration.FileManagement.DTOAdapters;
using Application.MainModule.Services;
using Domain.Administration;
using Domain.Entities;
using Domain.Repository;
using Domain.Resources.Libraries.PagedData;
using Infrastructure.Cross.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.CompanyManagement
{
    public class ServiceCompany : IServiceCompany
    {
        private readonly IRepositoryCompany _repositoryCompany;
        private readonly IRepositoryFile _repositoryFile;

        public ServiceCompany(IRepositoryCompany rCompany, IRepositoryFile rFile)
        {
            _repositoryCompany = rCompany;
            _repositoryFile = rFile;
        }

        public void Edit(DTOCompany company)
        {
            Update(company);
            Save();
        }

        private void Update(DTOCompany company)
        {
            Company _company = AdapterCompany.ToEntity(company);

            if (company.File != null)
            {
                if (company.File.IdFile == 0 && string.IsNullOrEmpty(company.File.FileName) == false)
                {
                    _repositoryFile.Insert(_company.webpages_File);
                }
            }
            else
            {
                if (company.IdFile > 0)
                {
                    var file = _repositoryFile.GetFileById(company.IdFile);
                    _company.webpages_File = new File();
                    _company.webpages_File.FileName = file.FileName;
                    _company.webpages_File.FileData = file.FileData;
                    _company.webpages_File.MimeType = file.MimeType;
                    _company.webpages_File.Date = file.Date;
                    _repositoryFile.Insert(_company.webpages_File);
                }
            }

            _repositoryCompany.Update(_company);
        }

        public DTOCompany GetDTOCompany()
        {
            //Obtengo el primero xq hay una sola compañía
            return AdapterCompany.ToDTO(_repositoryCompany.GetAll().First());
        }

        private void Save()
        {
            _repositoryCompany.UnitOfWork.SaveChanges();
        }
    }
}
