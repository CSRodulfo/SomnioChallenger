using Domain.Administration;
using Domain.Entities;
using Infrastructure.Data.Core;
using System.Linq;

namespace Infrastructure.Data.Administration
{
    public partial class RepositoryCompany : Repository<Company>, IRepositoryCompany
    {
        public Company GetCompany()
        {
            return _unitOfWork.CreateSet<Company>().FirstOrDefault();
        }
    }
}