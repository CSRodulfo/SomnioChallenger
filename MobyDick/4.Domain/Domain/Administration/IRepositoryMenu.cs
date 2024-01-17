using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Core;
using Domain.Entities;

namespace Domain.Administration
{
    public partial interface IRepositoryMenu : IRepository<Menu>
    {
        List<Menu> GetParentMenuItems();

        Menu GetMenuForTitle(string controller, string action);

        int GetMaxOrder();

        bool RequiresAuthorization(string controller, string area);
    }
}
