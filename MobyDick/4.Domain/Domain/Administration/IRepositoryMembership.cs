using Domain.Core;
using Domain.Entities;
using Domain.Resources.Libraries.PagedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Administration
{
    public partial interface IRepositoryMembership : IRepository<Membership>
    {
        Membership GetMembershipUserById(int userId);
    }
}