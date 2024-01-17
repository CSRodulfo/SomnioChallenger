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

namespace Application.MainModule.Administration.Resource
{
    public class ServiceResource : IServiceResource
    {
        private readonly IRepositoryResources _repositoryResource;

        public ServiceResource(IRepositoryResources rResource)
        {
            _repositoryResource = rResource;
        }

        public DTOResource GetDTOResource()
        {
            return AdapterResource.ToDTO(_repositoryResource.GetAll().First());
        }

        public IList<DTOResource> ReadResources()
        {
            return AdapterResource.ToDTOs(_repositoryResource.GetAll());
        }

        public DTOResource ReadResource(string name, string culture, int IdMenu)
        {
            return AdapterResource.ToDTO(_repositoryResource.ReadResource(name,culture, IdMenu));
        }
    }
}
