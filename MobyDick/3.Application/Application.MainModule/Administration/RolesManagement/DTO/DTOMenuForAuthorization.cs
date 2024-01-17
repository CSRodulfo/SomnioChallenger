using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement.DTO
{
    public class DTOMenuForAuthorization
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Area { get; set; }
    }
}
