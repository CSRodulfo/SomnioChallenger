using Domain.Resources.Libraries.PagedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Services
{
    public interface IServiceUser
    {
        PagedDataResult<DTOUser> GetUsers(PagedDataParameters pagedParameters);

        void Add(DTOUser user);

        void Edit(DTOUser user);

        void Delete(int id);
    }
}
