using Domain.Core;
using Domain.Entities;
using NHibernate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;

namespace Infrastructure.Data.MySql
{
    public class RepositoryMySql<TEntidad> : IRepository<TEntidad> where TEntidad : class
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        ISessionFactory _factory;

        public RepositoryMySql() //ISessionFactory factory)
        {
            _factory = MySqlContext.InitializeSessionFactory();
        }

        public void Insert(TEntidad entity)
        {
            using (ISession session = _factory.OpenSession())
            {
                session.Save(entity);
                session.Flush();
                session.Close();
            }
            _factory.Close();
        }

        public void Update(TEntidad entity)
        {
        }

        public void AddOrUpdate(TEntidad[] entities)
        {
        }

        public void Delete<T>(T id)
        {
        }

        public TEntidad GetByID<T>(T id)
        {
            IList rtn;
            using (ISession session = _factory.OpenSession())
            {
                var sc = session.CreateCriteria(typeof(TEntidad));
                rtn = sc.List();
                session.Close();
            }
            _factory.Close();
            return (TEntidad)rtn[0];
        }

        public List<TEntidad> GetAll()
        {
            IList<TEntidad> rtn;
            using (ISession session = _factory.OpenSession())
            {
                var sc = session.CreateCriteria(typeof(TEntidad));
                rtn = sc.List<TEntidad>();
                session.Close();
            }
            _factory.Close();
            return (List<TEntidad>)rtn;
        }

        public List<TEntidad> GetAsNoTracking(Expression<Func<TEntidad, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public TEntidad Get(Expression<Func<TEntidad, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<TEntidad> GetMany(Expression<Func<TEntidad, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
