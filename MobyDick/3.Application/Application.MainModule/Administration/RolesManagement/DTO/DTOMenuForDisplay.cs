using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement
{
    [DataContract()]
    public partial class DTOMenuForDisplay
    {
        [DataMember()]
        public Int32 Id { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public string Controller { get; set; }

        [DataMember()]
        public string Action { get; set; }

        [DataMember()]
        public virtual ICollection<DTORolesForDisplay> Roles { get; set; }

        [DataMember()]
        public virtual List<DTOMenuForDisplay> subMenues { get; set; }

        [DataMember()]
        public string Area { get; set; }

        [DataMember()]
        public Int32 Axis_X { get; set; }

        [DataMember()]
        public Int32 Axis_Y { get; set; }
    }
}