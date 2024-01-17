using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Abstract;
using Application.MainModule.Administration;
using Application.MainModule.Administration.Resource;

namespace Resources.Concrete
{
    public class DbResourceProvider : BaseResourceProvider
    {
        public DbResourceProvider()
        {
        }

        protected override IList<DTOResource> ReadResources()
        {
            IServiceResource userService = ManagerService.GetService<IServiceResource>();
            return userService.ReadResources();
        }

        protected override DTOResource ReadResource(string name, string culture, int IdMenu)
        {
            IServiceResource userService = ManagerService.GetService<IServiceResource>();
            return userService.ReadResource(name, culture, IdMenu);
        }
    }
}