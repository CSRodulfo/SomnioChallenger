using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Administration;
using Application.MainModule.Administration.RolesManagement;

namespace Application.MainModule.Administration.Authorization
{
    public class ManagerMenu : IManagerMenu
    {
        private readonly IRepositoryRoles _repository;
        private readonly IRepositoryMenu _repositoryMenu;

        public ManagerMenu(IRepositoryRoles repository,IRepositoryMenu repositoryMenu)
        {
            _repository = repository;
            _repositoryMenu = repositoryMenu;
        }

        public List<DTOMenuForDisplay> GetParentMenuesForDisplay()
        {
            return AdapterMenuForDisplay.ToDTOs(_repositoryMenu.GetParentMenuItems());
        }

        public DTOMenuForTitle GetMenuForTitle(string controller, string action)
        {
            return AdapterMenuForTitle.ToDTOForTitle(_repositoryMenu.GetMenuForTitle(controller,action));
        }
    }
}
