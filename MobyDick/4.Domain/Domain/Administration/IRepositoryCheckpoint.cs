using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Core;
using Domain.Entities;
using Domain.Resources.Libraries.PagedData;

namespace Domain.Administration
{
    public partial interface IRepositoryCheckpoint : IRepository<Checkpoint>
    {
        PagedDataResult<Checkpoint> GetCheckpointsByPage(PagedDataParameters PagedParameters, string Code);
        void DeleteLogic(int id);
    }
}
