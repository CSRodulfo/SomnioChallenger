using Application.MainModule.Administration.CompanyManagement;
using Application.MainModule.Administration.Culture;
using Application.MainModule.Administration.Culture.Interfaces;
using Application.MainModule.Administration.Resource;
using Application.MainModule.Administration.RolesManagement;
using Infrastructure.Cross.IoC.Unity;
using Infrastructure.Cross.Security.Autetification;
using Infrastructure.Cross.Security.Roles;
using Microsoft.Practices.Unity;

namespace Infrastructure.Cross.IoC.Module.ServiceModule
{
    public class ServiceModule : IUnityConfigurationModule
    {
        public void Configure(IUnityContainer container)
        {
            #region Security
            container.RegisterType<IServiceRolesManagement, ServiceRolesManagement>();
            container.RegisterType<IServiceUsers, ServiceUsers>();
            container.RegisterType<IServiceCompany, ServiceCompany>();
            container.RegisterType<IServiceCulture, ServiceCulture>();
            container.RegisterType<IRolesService, RolesService>();
            container.RegisterType<IServiceMenues, ServiceMenues>();
            //container.RegisterType<IServiceMembershipProvider, ServiceMembershipProvider>();
            container.RegisterType<IMembershipService, MembershipServiceForm>();
            container.RegisterType<IMembershipService, MembershipServiceMVC>();
            container.RegisterType<IServiceResource, ServiceResource>();
            #endregion
        }
    }
}
