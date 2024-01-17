using Presentation.MVC.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.MVC.Models
{
    public class CompanyModel
    {
        public Int32 IdCompany { get; set; }

        [MobyDickRequired]
        [MobyDickStringLength(50)]
        [MobyDickDisplayName("CompanyName", ResourceType = typeof(MBAdministration.Company.Resources))]
        public String Name { get; set; }

        [MobyDickRequired]
        [MobyDickStringLength(50)]
        [MobyDickDisplayName("CUIT", ResourceType = typeof(MBAdministration.Company.Resources))]
        public String CUIT { get; set; }

        [MobyDickRequired]
        [MobyDickStringLength(50)]
        [MobyDickDisplayName("Address", ResourceType = typeof(MBAdministration.Company.Resources))]
        public String Address { get; set; }

        [MobyDickRequired]
        [MobyDickStringLength(50)]
        [MobyDickDisplayName("Number", ResourceType = typeof(MBAdministration.Company.Resources))]
        public string Number { get; set; }

        [MobyDickRequired]
        [MobyDickStringLength(50)]
        [MobyDickDisplayName("State", ResourceType = typeof(MBAdministration.Company.Resources))]
        public String State { get; set; }

        [MobyDickRequired]
        [MobyDickStringLength(50)]
        [MobyDickDisplayName("Country", ResourceType = typeof(MBAdministration.Company.Resources))]
        public string Country { get; set; }

        public Int32 IdFile { get; set; }
    }
}