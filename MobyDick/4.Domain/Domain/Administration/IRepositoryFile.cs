using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Core;
using Domain.Entities;
using Domain.Resources.Libraries.PagedData;

namespace Domain.Administration
{
    public partial interface IRepositoryFile : IRepository<File>
    {
        File GetFileById(int fileId);
    }
}
