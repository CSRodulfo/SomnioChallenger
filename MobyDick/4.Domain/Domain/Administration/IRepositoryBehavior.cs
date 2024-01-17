using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Core;
using Domain.Entities;
using Domain.Resources.Libraries.PagedData;

namespace Domain.Administration
{
    public partial interface IRepositoryResources : IRepository<Domain.Entities.Resources>
    {
        Domain.Entities.Resources ReadResource(string name, string culture, int IdMenu);
    }
}
