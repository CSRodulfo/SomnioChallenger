using Domain.Core;
using Domain.Resources.Libraries.PagedData;

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
