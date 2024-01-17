using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement
{
    [DataContract()]
    public partial class DTOMenuesForRole
    {
        [DataMember()]
        public Int32 IDMenu { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public List<DTOMenuesForRole> SubMenues { get; set; }

        [DataMember()]
        public String Description { get; set; }

        public DTOMenuesForRole()
        {
        }
    }
}