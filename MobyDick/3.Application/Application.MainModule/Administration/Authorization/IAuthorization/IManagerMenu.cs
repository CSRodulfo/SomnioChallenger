using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.MainModule.Administration.RolesManagement;

namespace Application.MainModule.Administration.Authorization
{
    public interface IManagerMenu
    {
        List<DTOMenuForDisplay> GetParentMenuesForDisplay();

        DTOMenuForTitle GetMenuForTitle(string controller, string action);
    }
}
