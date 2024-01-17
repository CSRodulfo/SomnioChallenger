using Application.MainModule.Administration.Culture.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainModule.Administration.Culture.Interfaces
{
    public interface IServiceCulture
    {
        DTOCulture GetDTOCultureById(int id);
    }
}