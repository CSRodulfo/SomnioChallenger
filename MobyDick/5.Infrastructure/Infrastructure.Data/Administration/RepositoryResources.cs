using Domain.Administration;
using Domain.Entities;
using Infrastructure.Data.Core;
using System.Linq;

namespace Infrastructure.Data.Administration
{
    public partial class RepositoryResources : Repository<Resources>, IRepositoryResources
    {
        public Resources ReadResource(string name, string culture, int IdMenu)
        {
            return _unitOfWork.CreateSet<Resources>().Where(r => r.Name == name && r.Culture.Code == culture && r.IDMenu == IdMenu).FirstOrDefault();
        }
    }
}