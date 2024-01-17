using Domain.Core;
using Domain.Entities;
using Domain.Resources.Libraries.PagedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Administration
{
    public partial interface IRepositoryUsers : IRepository<Users>
    {
        PagedDataResult<Users> GetUsersByPage(PagedDataParameters PagedParameters, string userNameFilter);
        PagedDataResult<Users> GetPagedForReport(PagedData PagedParameters, string name);

        Users GetUserByUserName(string userName);
        bool IsDeveloper(string userName);
    }
}
