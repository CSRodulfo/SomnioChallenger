using Application.MainModule.Administration.Culture.DTO;
using Application.MainModule.Administration.Culture.Interfaces;
using Domain.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainModule.Administration.Culture
{
    public class ServiceCulture : IServiceCulture
    {
        private readonly IRepositoryCulture _repositoryCulture;

        public ServiceCulture(IRepositoryCulture rCulture)
        {
            _repositoryCulture = rCulture;
        }

        public DTOCulture GetDTOCultureById(int id)
        {
            return AdapterCulture.ToDTO(_repositoryCulture.GetByID(id));
        }
    }
}

