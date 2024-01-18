using Domain.Administration;
using Domain.Repository;
using Domain.Somnio;
using Infrastructure.Cross.IoC.Unity;
using Infrastructure.Data.Administration;
using Microsoft.Practices.Unity;

namespace Infrastructure.Cross.IoC.Module.RepositoryModule
{
    public class RepositoryModule : IUnityConfigurationModule
    {
        public void Configure(IUnityContainer container)
        {
            #region Security
            container.RegisterType<IRepositoryRoles, RepositoryRoles>();
            container.RegisterType<IRepositoryMenu, RepositoryMenu>();
            container.RegisterType<IRepositoryUsers, RepositoryUsers>();
            container.RegisterType<IRepositoryCompany, RepositoryCompany>();
            container.RegisterType<IRepositoryCulture, RepositoryCulture>();
            container.RegisterType<IRepositoryMembership, RepositoryMembership>();
            container.RegisterType<IRepositoryFile, RepositoryFile>();
            container.RegisterType<IRepositoryResources, RepositoryResources>();
            container.RegisterType<IRepositoryCheckpoint, RepositoryCheckpoint>();
            container.RegisterType<IRepositorySomnio, RepositorySomnio>();
            #endregion
        }
    }
}
