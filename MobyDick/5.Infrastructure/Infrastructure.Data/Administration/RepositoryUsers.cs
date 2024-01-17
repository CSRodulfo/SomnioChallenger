using Domain.Administration;
using Domain.Entities;
using Domain.Resources.Libraries.PagedData;
using Infrastructure.Data.Core;
using System.Linq;

namespace Infrastructure.Data.Administration
{
    public partial class RepositoryUsers : Repository<Users>, IRepositoryUsers
    {
        public PagedDataResult<Users> GetUsersByPage(PagedDataParameters PagedParameters, string userNameFilter)
        {
            IQueryable<Users> query = _unitOfWork.CreateSet<Users>();

            if (string.IsNullOrEmpty(userNameFilter)==false)
                query = query.Where(u => u.UserName.Contains(userNameFilter));

            int total = query.Count();

            if (PagedParameters.OrderDirection == Domain.Resources.Define.OrderBy.Descendant)
                query = query.OrderByDescending(w => w.UserName);
            else
                query = query.OrderBy(w => w.UserName);

            query = query.Skip((PagedParameters.Page - 1) * PagedParameters.Rows)
                .Take(PagedParameters.Rows);

            return new PagedDataResult<Users>(query.ToList(), total);
        }

        public PagedDataResult<Users> GetUsersByPage(PagedData PagedParameters, string userNameFilter)
        {
            IQueryable<Users> query = _unitOfWork.CreateSet<Users>();

            if (string.IsNullOrEmpty(userNameFilter) == false)
                query = query.Where(u => u.UserName.Contains(userNameFilter));

            return new PagedDataResult<Users>(query.ToList(), query.Count());
        }

        public bool IsDeveloper(string userName)
        {
            return _unitOfWork.CreateSet<Users>().Any(u => u.UserName == userName && u.Roles.Any(r => r.RoleName.ToLower() == "desarrollador"));
        }

        public Users GetUserByUserName(string userName)
        {
            return _unitOfWork.CreateSet<Users>().SingleOrDefault(u => u.UserName == userName);
        }

        public PagedDataResult<Users> GetPagedForReport(PagedData PagedParameters, string name)
        {
            return GetUsersByPage(PagedParameters, name);

        }
    }
}
