using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Data.Core;
using Domain.Administration;
using Domain.Entities;
using Domain.Resources.Libraries.PagedData;

namespace Infrastructure.Data.Administration
{
    public partial class RepositoryRoles : Repository<Roles>, IRepositoryRoles
    {
        public object GetRolByRoleName(string roleName)
        {
            throw new NotImplementedException();
        }

        public PagedDataResult<Roles> GetAllRolesByPage(PagedDataParameters PagedParameters)
        {
            IQueryable<Roles> data = _unitOfWork.CreateSet<Roles>();
            StrategyPagedData strategy = StrategyPagedData.GetStrategy(PagedParameters);

            return new PagedDataResult<Roles>(data.PagedData(strategy).ToList(), data.Count());
        }

        public PagedDataResult<Roles> GetRolesByNameAndPage(PagedDataParameters PagedParameters, string roleName)
        {
            IQueryable<Roles> data = _unitOfWork.CreateSet<Roles>();

            IQueryable<Roles> query = data.Where(r => r.RoleName.Contains(roleName));

            int total = query.Count();

            if (PagedParameters.OrderDirection == Domain.Resources.Define.OrderBy.Descendant)
               query = query.OrderByDescending(w => w.RoleName);
            else
                query = query.OrderBy(w => w.RoleName);

            query = query.Skip((PagedParameters.Page - 1) * PagedParameters.Rows)
                .Take(PagedParameters.Rows);

            List<Roles> result = query.ToList();

            return new PagedDataResult<Roles>(result, total);
        }

        public List<Roles> GetRolesByStringList(string[] Roles)
        {
            return _unitOfWork.CreateSet<Roles>().Where(r => Roles.Contains(r.RoleName)).ToList();
        }
    }
}
