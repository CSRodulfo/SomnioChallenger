using Domain.Resources.Libraries.PagedData;
using System.Collections.Generic;

namespace Application.MainModule
{
    public interface IServiceSomnio
    {

        List<DTOSomnioTable> GetAll();
        PagedDataResult<DTOSomnioTable> GetSomnioBy(PagedDataParameters pagedParameters, string filterStrategy);
    }
}
