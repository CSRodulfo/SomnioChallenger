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
        PagedDataResult<Entities.Somnio> GetSomnioAll(PagedDataParameters PagedParameters);
        PagedDataResult<Entities.Somnio> GetSomnioByCostFilter(PagedDataParameters PagedParameters);
        PagedDataResult<Entities.Somnio> GetSomnioByDateDesc(PagedDataParameters PagedParameters);
    }
}
