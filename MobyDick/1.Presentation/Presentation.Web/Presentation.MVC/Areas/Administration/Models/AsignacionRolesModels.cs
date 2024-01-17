using Application.MainModule.Administration.RolesManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.MVC.Areas.Administration.Models
{
    public class AsignacionRolesModels
    {
        public DTOUserForRoles user { get; set; }
        public List<AsignacionRolesDataTree> dataTree { get; set; }
        public string selectedKeys { get; set; }
    }
}