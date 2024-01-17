using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using Application.MainModule.Services;
using Domain.Resources.Libraries.PagedData;

namespace Application.MainModule.Administration.Resource
{
    public interface IServiceResource
    {
        IList<DTOResource> ReadResources();
        DTOResource ReadResource(string name, string culture, int IdMenu);
    }
}