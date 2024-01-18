using Domain.Core;
using Domain.Entities;
using Domain.Resources.Libraries.PagedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Somnio
{
    public interface IRepositorySomnio : IRepository<Entities.Somnio>
    {
        void GetBySomnio();

    }
}
