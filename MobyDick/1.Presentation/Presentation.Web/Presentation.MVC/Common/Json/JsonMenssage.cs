using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.MVC.Common
{
    public class JsonMenssage
    {
        public bool Success
        {
            get { return true; }            
        }
        
        public string Menssage { get; set; }
    }
}