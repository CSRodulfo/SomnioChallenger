using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Presentation.MVC.Areas.Administration.Models
{
    public class RolesViewModel
    {
    }

    public class ManageRolesViewModel
    {
        [Display(Name = "Roles")]
        [Required]
        public SelectList Roles { get; set; }
    }

    public class RoleViewModel
    {

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "RoleName is required.")]
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}