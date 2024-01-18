using Domain.Entities;
using Domain.Resources.Libraries.PagedData;
using Domain.Somnio;
using Infrastructure.Data.Core;
using System.Linq;

namespace Infrastructure.Data.Administration
{
    public partial class RepositorySomnio : RepositoryMySql<SomnioTable>, IRepositorySomnio
    {
        public RepositorySomnio(IQueriableUnitOfWork iUnitOfWork)  
        {
        }

        public void GetBySomnio()
        {
            throw new System.NotImplementedException();
        }

        //public PagedDataResult<Checkpoint> GetCheckpointsByPage(PagedDataParameters PagedParameters, string Code)
        //{
        //    IQueryable<Checkpoint> query = null; // _unitOfWork.CreateSet<Checkpoint>();

        //    if (string.IsNullOrEmpty(Code) == false)
        //        query = query.Where(u => u.Code.Contains(Code));

        //    int total = query.Count();

        //    if (PagedParameters.OrderDirection == Domain.Resources.Define.OrderBy.Descendant)
        //        query = query.OrderByDescending(w => w.Code);
        //    else
        //        query = query.OrderBy(w => w.Code);

        //    query = query.Skip((PagedParameters.Page - 1) * PagedParameters.Rows)
        //        .Take(PagedParameters.Rows);

        //    return new PagedDataResult<Checkpoint>(query.ToList(), total);
        //}


    }
}