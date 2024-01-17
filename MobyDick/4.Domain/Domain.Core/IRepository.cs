using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Core
{
    public interface IRepository<TEntidad> where TEntidad : class
    {
        IUnitOfWork UnitOfWork { get; }

        void Insert(TEntidad entity);

        void Update(TEntidad entity);

        void AddOrUpdate(TEntidad[] entities);

        void Delete<T>(T id);

        TEntidad GetByID<T>(T id);

        List<TEntidad> GetAll();

        List<TEntidad> GetAsNoTracking(Expression<Func<TEntidad, bool>> exp);

        TEntidad Get(Expression<Func<TEntidad, int, bool>> predicate);
        
        List<TEntidad> GetMany(Expression<Func<TEntidad, int, bool>> predicate);
    }
}
