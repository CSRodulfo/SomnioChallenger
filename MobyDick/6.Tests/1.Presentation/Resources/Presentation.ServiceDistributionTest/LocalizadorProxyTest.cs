using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ServiceDistribution.ServiceSecurity;
using Presentation.ServiceDistribution;

namespace Presentation.ServiceDistributionTest
{
    [TestClass]
    public class LocalizadorProxyTest
    {
        [TestMethod]
        public void PruebaLogin()
        {
            IServiceMembershipProvider p = LocalizadorProxy.GetServiceMembershipProvider();
            var a = p.Login("Admin", "123456", false);

            Assert.IsTrue(a);
        }
    }
}
