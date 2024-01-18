using Domain.Administration;
using Domain.Somnio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainModule.Somnio
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
    }
}
