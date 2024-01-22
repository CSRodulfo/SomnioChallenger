using Domain.Entities;
using Domain.Resources.Libraries.PagedData;
using Domain.Somnio;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.MySql
{
    public partial class RepositorySomnio : RepositoryMySql<Somnio>, IRepositorySomnio
    {
        public RepositorySomnio() 
        {
        }

        public void GetBySomnio()
        {
            throw new System.NotImplementedException();
        }
        public PagedDataResult<Somnio> GetSomnioAll(PagedDataParameters PagedParameters)
        {
            IQueryable<Somnio> query = base.GetAll().AsQueryable();
            return GetSomnioBy(PagedParameters, query);
        }

        public PagedDataResult<Somnio> GetSomnioByCostFilter(PagedDataParameters PagedParameters)
        {
            IQueryable<Somnio> query = base.GetAll().Where(x => x.TotalCost > 1000).AsQueryable();
            return GetSomnioBy(PagedParameters, query);
        }

        public PagedDataResult<Somnio> GetSomnioByDateDesc(PagedDataParameters PagedParameters)
        {
            IQueryable<Somnio> query = base.GetAll().AsQueryable();

            PagedParameters.OrderDirection = Domain.Resources.Define.OrderBy.Descendent;
            PagedParameters.OrderField = "Date";
                
            return GetSomnioBy(PagedParameters, query);
        }

        private PagedDataResult<Somnio> GetSomnioBy(PagedDataParameters PagedParameters, IQueryable<Somnio> query)
        {
            int total = query.Count();

            if (PagedParameters.OrderDirection == Domain.Resources.Define.OrderBy.Descendent)
                query = query.OrderByDescending(x => x.GetType().GetProperty(PagedParameters.OrderField).GetValue(x, null));
            else
                query = query.OrderBy(x => x.GetType().GetProperty(PagedParameters.OrderField).GetValue(x, null));

            query = query.Skip((PagedParameters.Page - 1) * PagedParameters.Rows)
                .Take(PagedParameters.Rows);

            List<Somnio> result = query.ToList();

            return new PagedDataResult<Somnio>(result, total);
        }
    }
}