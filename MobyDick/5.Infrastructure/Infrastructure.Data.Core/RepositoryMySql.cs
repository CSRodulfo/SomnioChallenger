using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Domain.Core;
using System.Linq.Expressions;
using System.Data.Entity.Migrations;
using NHibernate;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Collections;
using NHibernate.Mapping;

namespace Infrastructure.Data.Core
{
    public class RepositoryMySql<TEntidad> : IRepository<TEntidad> where TEntidad : class
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        ISessionFactory factory = new NHibernate.Cfg.Configuration().Configure().BuildSessionFactory();

        public RepositoryMySql()
        {
        }

        public void Insert(TEntidad entity)
        {
            using (ISession session = factory.OpenSession())
            {
                //var s = session.Load(typeof(entity), 1);

                session.Save(entity);
                session.Flush();
                session.Close();
            }
            factory.Close();
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
            using (ISession session = factory.OpenSession())
            {
                ICriteria sc = session.CreateCriteria(typeof(Site));
                rtn = sc.List();
                session.Close();
            }
            factory.Close();
            return (TEntidad)rtn[0];
        }

        public List<TEntidad> GetAll()
        {
            throw new NotImplementedException();
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
