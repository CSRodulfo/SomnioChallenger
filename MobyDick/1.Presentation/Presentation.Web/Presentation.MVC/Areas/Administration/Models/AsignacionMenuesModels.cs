using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Application.MainModule.Administration.RolesManagement;

namespace Presentation.MVC.Areas.Administration.Models
{
    public class AsignacionMenuesModels
    {
        public DTORoleForMenues rol { get; set; }
        public List<DTOMenuesForRole> menues { get; set; }
        public List<AsignacionMenuesDataTree> dataTree { get; set; }
        public string selectedKeys { get; set; }
    }
}