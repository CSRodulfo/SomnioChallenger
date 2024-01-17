using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using Domain.Repository;
using Application.MainModule.Security;
using Application.MainModule.Services;
using Domain.Administration;
using Domain.Resources.Libraries.PagedData;
using Application.MainModule.Administration.RolesManagement.DTO;


namespace Application.MainModule.Administration.RolesManagement
{
    public class ServiceRolesManagement : IServiceRolesManagement
    {
        private readonly IRepositoryMenu _repositoryMenu;
        private readonly IRepositoryRoles _repositoryRoles;

        public ServiceRolesManagement(IRepositoryMenu rMenu, IRepositoryRoles rRoles)
        {
            _repositoryMenu = rMenu;
            _repositoryRoles = rRoles;
        }

        public List<DTORoles> GetAllRolesWithMenus()
        {
            return AdapterRoles.ToDTOs(_repositoryRoles.GetAll());
        }

        public List<DTOMenu> GetAllMenus()
        {
            return AdapterMenu.ToDTOs(_repositoryMenu.GetAll());
        }

        public List<DTOMenuesForRole> GetAllMenuesForRoles()
        {
            return AdapterMenuesForRole.ToDTOsMenuesForRole(_repositoryMenu.GetParentMenuItems());
        }

        public void AssignRolesToMenus(List<DTORoles> roles)
        {
            foreach (DTORoles item in roles)
            {
                Roles rol = _repositoryRoles.GetByID(item.RoleId);
                List<Menu> menuesAsignados = new List<Menu>();

                foreach (DTOMenu m in item.MenusInRole)
                {
                    menuesAsignados.Add(_repositoryMenu.GetByID(m.IDMenu));
                }

                rol.Menu = menuesAsignados;
            }

            _repositoryRoles.UnitOfWork.SaveChanges();
        }

        public DTORoleForMenues GetRoleForMenuesById(int id)
        {
            return AdapterRoleForMenues.ToDTORoleForMenues(_repositoryRoles.GetByID(id));
        }

        public void SaveRoleWithMenues(int roleId, List<int> menuIds)
        {
            Roles role = _repositoryRoles.GetByID(roleId);

            //MENUS QUE SE DEBEN ELIMINAR
            List<Menu> MenuesInRoleToDelete = role.Menu.Where(rm => !menuIds.Contains(rm.IDMenu)).Select(ru => ru).ToList();

            MenuesInRoleToDelete.ForEach(m => role.Menu.Remove(m));

            //MENUS QUE SE DEBEN AGREGAR
            var idsToAdd = menuIds.Where(m => !role.Menu.Any(rm => rm.IDMenu == m)).ToList();

            foreach (int id in idsToAdd)
            {
                Menu menuToAdd = _repositoryMenu.GetByID(id);
                role.Menu.Add(menuToAdd);
            }

            _repositoryRoles.Update(role);

            Save();
        }

        public PagedDataResult<DTORoleForList> GetRolesByPageAndName(PagedDataParameters pagedParameters, string roleName)
        {
            PagedDataResult<Roles> pagedData = _repositoryRoles.GetRolesByNameAndPage(pagedParameters, roleName);

            return new PagedDataResult<DTORoleForList>(AdapterRoleForList.ToDTOsRoleForList(pagedData.Results), pagedData.TotalCount);
        }

        public void Update(DTORoleForList dtoRole)
        {
            Roles role = AdapterRoleForList.ToEntityRoleForList(dtoRole);
            _repositoryRoles.Update(role);
            Save();
        }

        public void Delete(int id)
        {
            Roles role = _repositoryRoles.GetByID(id);
            if (role.Menu.Count > 0)
                throw new Exception("No se puede eliminar el rol ya que tiene elementos asociados. Quite los menús asignados y vuelva a intentarlo.");
            if (role.Users.Count > 0)
                throw new Exception("No se puede eliminar el rol ya que tiene elementos asociados. Quite los usuarios asignados y vuelva a intentarlo.");

            _repositoryRoles.Delete(id);
            Save();
        }

        public void Add(DTORoleForList dtoRole)
        {
            insert(dtoRole);
            Save();
        }

        private void insert(DTORoleForList dtoRole)
        {
            Roles role = AdapterRoleForList.ToEntityRoleForList(dtoRole);
            _repositoryRoles.Insert(role);
        }

        private void Save()
        {
            _repositoryRoles.UnitOfWork.SaveChanges();
        }

        public List<DTORoleForAuthorization> GetDTORolesForAuthorizationByString(string[] roles)
        {
            return AdapterRoleForAuthorization.ToDTOsMenuForAuthorization(_repositoryRoles.GetRolesByStringList(roles));
        }

        /*public Domain.Resources.Define.RoleAssignationState HasAssignedMenues(Roles entityRole)
        { 
            Domain.Resources.Define.RoleAssignationState state = new Domain.Resources.Define.RoleAssignationState();

            if (entityRole.Menu.Count > 0)
                state = Domain.Resources.Define.RoleAssignationState.Assigned;
            else
                state = Domain.Resources.Define.RoleAssignationState.NotAssigned;

            return state;
        }*/
    }
}