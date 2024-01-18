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

        public void GetAll()
        {
            var a = _repositorySomnio.GetAll();
        }
    }
}
