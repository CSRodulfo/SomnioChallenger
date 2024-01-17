using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.MVC.Models
{
    public class MenuesDataTree
    {
        public int key { get; set; }
        public string title { get; set; }
        public string menuDescription { get; set; }
        public List<string> assignedRoles { get; set; }
        //public bool select { get; set; }
        public bool isFolder { get; set; }
        public List<MenuesDataTree> children { get; set; }
    }
}