using Application.MainModule.Administration.RolesManagement;
using Domain.Entities;
using Domain.Resources.Libraries.PagedData;
using Domain.Somnio;
using System.Collections.Generic;

namespace Application.MainModule
{
    public class ServiceSomnio : IServiceSomnio
    {
        private readonly IRepositorySomnio _repositorySomnio;

        public ServiceSomnio(IRepositorySomnio rSomnio)
        {
            _repositorySomnio = rSomnio;
        }

        public List<DTOSomnioTable> GetAll()
        {
            var repo = _repositorySomnio.GetAll();
            return AdapterSomnio.ToDTOs(repo);
        }

        public PagedDataResult<DTOSomnioTable> GetSomnioBy(PagedDataParameters pagedParameters, string filterStrategy)
        {
            PagedDataResult<Somnio> pagedData = null;
            if (filterStrategy == "CostFilter")
            {
                pagedData = _repositorySomnio.GetSomnioByCostFilter(pagedParameters);
            }
            else if (filterStrategy == "DateOrder")
            {
                pagedData = _repositorySomnio.GetSomnioByDateDesc(pagedParameters);
            }
            else
            {
                pagedData = _repositorySomnio.GetSomnioAll(pagedParameters);
            }

            return new PagedDataResult<DTOSomnioTable>(AdapterSomnio.ToDTOs(pagedData.Results), pagedData.TotalCount);
        }
    }
}
