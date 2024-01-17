//using Infrastructure.Data.Repository;
using Microsoft.Practices.Unity;
using Infrastructure.Cross.IoC.Module.CoreModule;
using Infrastructure.Cross.IoC.Module.ServiceModule;
using Infrastructure.Cross.IoC.Module.RepositoryModule;
using Infrastructure.Cross.IoC.Unity;

namespace Infrastructure.Cross.IoC
{
    public class FactoryIoC
    {
        private static readonly FactoryIoC _container = new FactoryIoC();
        private readonly IUnityContainer _unityContainer;

        public static FactoryIoC Container { get { return _container; } }

        private FactoryIoC()
        {
            _unityContainer = new UnityContainer();
            _unityContainer.RegisterModule<CoreModule>();
            _unityContainer.RegisterModule<ServiceModule>();
            _unityContainer.RegisterModule<RepositoryModule>();
        }

        public TService Resolve<TService>() where TService : class
        {
            return _unityContainer.Resolve<TService>();
        }
        public TService Resolve<TService>(string name) where TService : class
        {
            return _unityContainer.Resolve<TService>(name);
        }

        public object Resolve(System.Type type)
        {
            return _unityContainer.Resolve(type);
        }
    }
}
