using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Domain.Core;
using System.Linq.Expressions;

namespace Infrastructure.Data.Core
{
    public interface IQueriableUnitOfWork : IUnitOfWork
    {
        DbSet<TEntidad> SetEntity<TEntidad>() where TEntidad : class;

        IQueryable<TEntidad> CreateSet<TEntidad>() where TEntidad : class;

        IQueryable<TEntidad> CreateSet<TEntidad>(params Expression<Func<TEntidad, object>>[] includes) where TEntidad : class;
    }
}
