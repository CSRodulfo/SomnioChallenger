using Presentation.ServiceDistribution.ServiceSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presentation.ServiceDistribution
{

    public class LocalizadorProxy
    {
        public static IServiceMembershipProvider GetServiceMembershipProvider()
        {
            IServiceMembershipProvider servicioDistribuido = new ServiceMembershipProviderClient("BasicHttpBinding_IServiceMembershipProvider");
            return servicioDistribuido;
        }
    }

}
