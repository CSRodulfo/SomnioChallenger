using Application.MainModule;
using Application.MainModule.Administration.Authentication;
using Application.MainModule.Administration.Authorization;
using Application.MainModule.Administration.RolesManagement.Interfaces;
using Domain.MainModule.Administration;
using Domain.MainModule.Administration.Security.Authentication;
using Infrastructure.Cross.IoC.Unity;
using Infrastructure.Cross.Security.Autetification;
using Infrastructure.Data;
using Infrastructure.Data.Core;
using Microsoft.Practices.Unity;

namespace Infrastructure.Cross.IoC.Module.CoreModule
{
    public class CoreModule : IUnityConfigurationModule
    {
        public void Configure(IUnityContainer container)
        {
            container.RegisterType<IQueriableUnitOfWork, MobyDickEntities>(new Microsoft.Practices.Unity.PerResolveLifetimeManager());
            container.RegisterType<IManagerMenu, ManagerMenu>();
            container.RegisterType<IServiceSomnio, ServiceSomnio>();
            container.RegisterType<ISecurityRoles, SecurityRoles>();
            container.RegisterType<ISecurityMembership, SecurityMembership>("FORM", new InjectionConstructor(new ResolvedParameter<MembershipServiceForm>()));
            container.RegisterType<ISecurityMembership, SecurityMembership>("MVC", new InjectionConstructor(new ResolvedParameter<MembershipServiceMVC>()));
            container.RegisterType<IRolesValidation, RolesValidation>();

        }
    }
}
