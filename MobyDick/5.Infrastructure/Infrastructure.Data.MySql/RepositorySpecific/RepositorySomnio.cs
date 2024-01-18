using Domain.Core;
using Domain.Entities;
using Domain.Resources.Libraries.PagedData;
using Domain.Somnio;
using Infrastructure.Data.Core;
using NHibernate;
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

        public PagedDataResult<Somnio> GetSomnioBy(PagedDataParameters PagedParameters, string id)
        {
            IQueryable<Somnio> query = base.GetAll().AsQueryable();

            int total = query.Count();

            if (PagedParameters.OrderDirection == Domain.Resources.Define.OrderBy.Descendant)
                query = query.OrderByDescending(w => w.Date);
            else
                query = query.OrderBy(w => w.Date);

            query = query.Skip((PagedParameters.Page - 1) * PagedParameters.Rows)
                .Take(PagedParameters.Rows);

            List<Somnio> result = query.ToList();

            return new PagedDataResult<Somnio>(result, total);
        }


    }
}