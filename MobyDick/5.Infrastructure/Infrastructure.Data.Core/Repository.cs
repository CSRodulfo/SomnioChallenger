using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Domain.Core;
using System.Linq.Expressions;
using System.Data.Entity.Migrations;

namespace Infrastructure.Data.Core
{
    public class Repository<TEntidad> : IRepository<TEntidad> where TEntidad : class
    {
        protected readonly IQueriableUnitOfWork _unitOfWork;

        public IUnitOfWork UnitOfWork { get { return this._unitOfWork; } }

        public Repository(IQueriableUnitOfWork iUnitOfWork)
        {
            if (iUnitOfWork == null)
                throw new ArgumentNullException("UnidadDeTrabajo", "La unidad de trabajo no puede ser null.");

            this._unitOfWork = iUnitOfWork;
        }

        public void Insert(TEntidad entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entidad", "La entidad no puede ser null.");

            this._unitOfWork.SetEntity<TEntidad>().Add(entity);
        }

        public void Update(TEntidad entity)
        {
            this._unitOfWork.RegisterChanges(entity);
        }

        public void AddOrUpdate(TEntidad[] entities)
        {
            this._unitOfWork.SetEntity<TEntidad>().AddOrUpdate(entities);
        }

        public void Delete<T>(T id)
        {
            this._unitOfWork.SetEntity<TEntidad>().Remove(this.GetByID(id));
        }

        public TEntidad GetByID<T>(T id)
        {
            return this._unitOfWork.SetEntity<TEntidad>().Find(id);
        }

        public List<TEntidad> GetAll()
        {
            return this._unitOfWork.CreateSet<TEntidad>().ToList();
        }

        public TEntidad Get(Expression<Func<TEntidad,int,bool>> predicate)
        {
            return this._unitOfWork.CreateSet<TEntidad>().Where(predicate).FirstOrDefault();
        }

        public List<TEntidad> GetMany(Expression<Func<TEntidad, int, bool>> predicate)
        {
            return this._unitOfWork.CreateSet<TEntidad>().Where(predicate).ToList();
        }

        public List<TEntidad> GetAsNoTracking(Expression<Func<TEntidad, bool>> exp)
        {
            return this._unitOfWork.CreateSet<TEntidad>().AsNoTracking().AsQueryable().Where(exp).ToList();
        }
    }
}
