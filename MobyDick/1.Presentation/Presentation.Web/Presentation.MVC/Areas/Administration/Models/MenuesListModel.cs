using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.MVC.Models
{
    public class MenuesListModel
    {
        public List<MenuesDataTree> DataTree { get; set; }
        public bool IsUserDeveloper { get; set; }
    }
}