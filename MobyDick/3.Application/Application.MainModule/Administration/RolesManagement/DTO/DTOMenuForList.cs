using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement.DTO
{
    public class DTOMenuForList
    {
        public int IDMenu { get; set; }
        public string Description { get; set; }
        public List<string> AssignedRoles { get; set; }
        public string Name { get; set; }
        public List<DTOMenuForList> SubMenues { get; set; }
    }
}
