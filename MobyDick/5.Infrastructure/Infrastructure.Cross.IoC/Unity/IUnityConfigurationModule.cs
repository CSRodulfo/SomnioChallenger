using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Cross.IoC.Unity
{
    public partial interface IUnityConfigurationModule
    {
        void Configure(IUnityContainer contatiner);
    }
}
