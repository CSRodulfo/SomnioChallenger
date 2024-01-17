using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Resources.Libraries.PagedData
{
    public abstract class PagedData
    {

        public virtual StrategyPagedData Get()
        {
            throw new NotImplementedException();
        }
    }
}
