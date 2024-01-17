using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using Application.MainModule.Services;
using Domain.Resources.Libraries.PagedData;
using Application.MainModule.Administration.RolesManagement.DTO;

namespace Application.MainModule.Administration.RolesManagement
{
    public interface IServiceRolesManagement
    {
        List<DTORoles> GetAllRolesWithMenus();

        List<DTOMenu> GetAllMenus();

        void AssignRolesToMenus(List<DTORoles> roles);

        DTORoleForMenues GetRoleForMenuesById(int id);

        List<DTOMenuesForRole> GetAllMenuesForRoles();

        void SaveRoleWithMenues(int roleId, List<int> menuIds);

        PagedDataResult<DTORoleForList> GetRolesByPageAndName(PagedDataParameters pagedParameters, string roleName);

        void Delete(int id);

        void Add(DTORoleForList dtoRole);

        void Update(DTORoleForList dtoRole);

        List<DTORoleForAuthorization> GetDTORolesForAuthorizationByString(string[] roles);
    }
}