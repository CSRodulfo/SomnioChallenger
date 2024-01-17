using Domain.Entities;
using Infrastructure.Data.Core;
using System.Linq;

namespace Infrastructure.Data.Administration
{
    public partial class RepositoryMembership : Repository<Membership>, Domain.Administration.IRepositoryMembership
    {

        public Membership GetMembershipUserById(int userId)
        {
            return _unitOfWork.CreateSet<Membership>().SingleOrDefault(u => u.UserId == userId);
        }
    }
}
