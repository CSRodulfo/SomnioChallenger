using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement.DTO
{
    public class DTORoleForAuthorization
    {
        public int IDRole { get; set; }
        public string RoleName { get; set; }
        public List<DTOMenuForAuthorization> Menues { get; set; }
    }
}