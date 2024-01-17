using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement.Interfaces
{
    public interface IRolesValidation
    {
        List<Roles> GetRolesForParentMenu(Menu parentMenu);
    }
}
