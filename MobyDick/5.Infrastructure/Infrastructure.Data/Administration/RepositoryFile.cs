using Domain.Entities;
using Infrastructure.Data.Core;
using System.Linq;

namespace Infrastructure.Data.Administration
{
    public  partial class RepositoryFile : Repository<File>, Domain.Administration.IRepositoryFile
    {
        public File GetFileById(int fileId)
        {
            return _unitOfWork.CreateSet<File>().SingleOrDefault(f => f.IdFile == fileId);
        }
    }
}
