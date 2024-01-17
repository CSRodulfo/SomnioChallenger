using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Application.MainModule.Services;

namespace Presentation.MVC.Areas.Administration.Models
{
    public class AsignacionMenuesDataTree
    {
        public int key { get; set; }
        public string title { get; set; }
        public string menuDescription { get; set; }
        public bool selected { get; set; }
        public bool isFolder { get; set; }
        public List<AsignacionMenuesDataTree> children { get; set; }
    }
}