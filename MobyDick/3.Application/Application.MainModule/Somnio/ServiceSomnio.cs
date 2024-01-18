using Application.MainModule.Administration.RolesManagement;
using Domain.Administration;
using Domain.Resources.Libraries.PagedData;
using Domain.Somnio;
using Infrastructure.Data.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

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
            List<DTOSomnioTable> rtn = new List<DTOSomnioTable>();
            var a = _repositorySomnio.GetAll();

            foreach (var table in a)
            {
                DTOSomnioTable dTOSomnioTable = new DTOSomnioTable();
                dTOSomnioTable.Id = table.Id;
                dTOSomnioTable.TotalCost = table.TotalCost;
                dTOSomnioTable.Quantity = table.Quantity;
                dTOSomnioTable.Date = table.Date;
                rtn.Add(dTOSomnioTable);
            }

            return rtn;
        }

        public PagedDataResult<DTOSomnioTable> GetSomnioBy(PagedDataParameters pagedParameters, string id)
        {
            PagedDataResult<Somnio> pagedData = _repositorySomnio.GetSomnioBy(pagedParameters, id);

            return new PagedDataResult<DTOSomnioTable>(AdapterSomnio.ToDTOs(pagedData.Results), pagedData.TotalCount);
        }
    }
}
