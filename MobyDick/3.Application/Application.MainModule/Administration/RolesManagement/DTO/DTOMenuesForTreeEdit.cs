using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement.DTO
{
    public class DTOMenuesForTreeEdit
    {
        public int IDMenu { get; set; }
        public string Name { get; set; }
        public int? IDParent { get; set; }
        public int Orden { get; set; }
        public List<DTOMenuesForTreeEdit> SubMenues { get; set; }
    }
}
