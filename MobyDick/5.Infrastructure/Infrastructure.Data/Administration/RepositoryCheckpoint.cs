using Domain.Administration;
using Domain.Entities;
using Domain.Resources.Libraries.PagedData;
using Infrastructure.Data.Core;
using System.Linq;

namespace Infrastructure.Data.Administration
{
    public partial class RepositoryCheckpoint : Repository<Checkpoint>, IRepositoryCheckpoint
    {
        public PagedDataResult<Checkpoint> GetCheckpointsByPage(PagedDataParameters PagedParameters, string Code)
        {
            IQueryable<Checkpoint> query = _unitOfWork.CreateSet<Checkpoint>();

            if (string.IsNullOrEmpty(Code) == false)
                query = query.Where(u => u.Code.Contains(Code));

            int total = query.Count();

            if (PagedParameters.OrderDirection == Domain.Resources.Define.OrderBy.Descendent)
                query = query.OrderByDescending(w => w.Code);
            else
                query = query.OrderBy(w => w.Code);

            query = query.Skip((PagedParameters.Page - 1) * PagedParameters.Rows)
                .Take(PagedParameters.Rows);

            return new PagedDataResult<Checkpoint>(query.ToList(), total);
        }

        public void DeleteLogic(int id)
        {
            Domain.Entities.Checkpoint checkpoint = this.GetByID(id);


            if (checkpoint.deleted == false)
            {
                checkpoint.deleted = true;
                this.Update(checkpoint);
            }

        }
    }
}
