using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();

        void RegisterChanges<TEntidad>(TEntidad entidad) where TEntidad : class;
    }
}
