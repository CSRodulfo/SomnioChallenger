﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.MVC.Common
{
    public class JsonView
    {
        public bool Success { get; set; }
        public string ActionName { get; set; }
        public object Model { get; set; }
    }
}