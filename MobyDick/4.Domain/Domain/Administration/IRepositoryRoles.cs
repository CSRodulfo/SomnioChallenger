using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Core;
using Domain.Entities;
using Domain.Resources.Libraries.PagedData;

namespace Domain.Administration
{
    public partial interface IRepositoryRoles : IRepository<Roles>
    {
        object GetRolByRoleName(string roleName);

        PagedDataResult<Roles> GetAllRolesByPage(PagedDataParameters PagedParameters);

        PagedDataResult<Roles> GetRolesByNameAndPage(PagedDataParameters PagedParameters, string roleName);

        List<Roles> GetRolesByStringList(string[] Roles);
    }
}
