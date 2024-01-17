using Application.MainModule.Administration.RolesManagement;
using Application.MainModule.Administration.RolesManagement.DTO;
using Presentation.MVC.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.MVC.Models
{
    public class MenuInsertModels
    {
        [MobyDickRequired]
        [MobyDickStringLength(50)]
        [MobyDickDisplayName("MenuName", ResourceType = typeof(MBAdministration.Menues.Resources))]
        public string Name { get; set; }

        [MobyDickDisplayName("MenuParentName", ResourceType = typeof(MBAdministration.Menues.Resources))]
        public DTOMenuesForEdit ParentMenu { get; set; }
        [MobyDickDisplayName("MenuParentName", ResourceType = typeof(MBAdministration.Menues.Resources))]
        public int? IDParentMenu { get; set; }

        [MobyDickRequired]
        [MobyDickDisplayName("MenuDescription", ResourceType = typeof(MBAdministration.Menues.Resources))]
        public string Description { get; set; }

        //Datos de la vista
        [MobyDickDisplayName("MenuArea", ResourceType = typeof(MBAdministration.Menues.Resources))]
        public string Area { get; set; }

        [MobyDickRequired]
        [MobyDickDisplayName("MenuController", ResourceType = typeof(MBAdministration.Menues.Resources))]
        public string Controller { get; set; }

        [MobyDickRequired]
        [MobyDickDisplayName("MenuAction", ResourceType = typeof(MBAdministration.Menues.Resources))]
        public string Action { get; set; }

        public List<DTOMenu> AllMenues { get; set; }
    }
}