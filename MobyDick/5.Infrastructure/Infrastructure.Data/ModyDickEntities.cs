using System;
using System.Linq;
using Infrastructure.Data.Core;
using System.Linq.Expressions;
using Domain.Entities.Libraries;
using System.Data.Entity;
using Domain.Resources.Libraries.PagedData;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using Infrastructure.Cross.Security.Autetification;
using Domain.Entities;

namespace Infrastructure.Data
{
    public partial class MobyDickEntities : DbContext, IQueriableUnitOfWork
    {
        public new void SaveChanges()
        {
            ObjectContext context = ((IObjectContextAdapter)this).ObjectContext;

            foreach (ObjectStateEntry entry in
                  context.ObjectStateManager
                    .GetObjectStateEntries(EntityState.Added | EntityState.Modified))
            {
                // Only work with entities that have our user/timestamp records in them.
                if (!entry.IsRelationship)
                {
                    CurrentValueRecord entryValues = entry.CurrentValues;
                    if (entryValues.GetOrdinal("stamp") > 0)
                    {
                        // HttpContext currContext = HttpContext.Current;
                        MembershipServiceMVC a = new MembershipServiceMVC();
                        int userId = a.CurrentUserId;
                        DateTime now = DateTime.Now;

                        entryValues.SetInt32(entryValues.GetOrdinal("op"), userId);
                        entryValues.SetDateTime(entryValues.GetOrdinal("stamp"), now);

                        //Se comenta ya que las lineas de arriba asignan siempre op y stamp
                        //if (entry.State == EntityState.Added)
                        //{
                            //entryValues.SetInt32(entryValues.GetOrdinal("op"), userId);
                            //entryValues.SetDateTime(entryValues.GetOrdinal("stamp"), now);
                        //}
                    }
                }
            }
            base.SaveChanges();
        }

        public void RegisterChanges<TEntidad>(TEntidad entidad) where TEntidad : class
        {
            this.Entry(entidad).State = System.Data.Entity.EntityState.Modified;
        }

        /// <summary>
        /// Permite la busqueda por Linq y su ejecucion es al momento de solicitar los datos (no carga en memoria)
        /// </summary>
        /// <typeparam name="TEntidad"></typeparam>
        /// <returns></returns>
        public DbSet<TEntidad> SetEntity<TEntidad>() where TEntidad : class
        {
            return base.Set<TEntidad>() as DbSet<TEntidad>;
        }

        /// <summary>
        /// Permite la busqueda por Linq y su ejecucion es al momento de solicitar los datos (no carga en memoria)
        /// </summary>
        /// <typeparam name="TEntidad"></typeparam>
        /// <returns></returns>
        public IQueryable<TEntidad> CreateSet<TEntidad>() where TEntidad : class
        {
            IQueryable<TEntidad> query = base.Set<TEntidad>();

            if (typeof(IAuditable).IsAssignableFrom(typeof(TEntidad)))
                query = query.StrategyDeleted();

            return query;
        }

        /// <summary>
        /// Lazy Load OFF
        /// Permite la carga de relaciones con expresiones lambda, sin especificar el include 
        /// ej: this.CreateSet(o => o.Id == id, o => o.OrderLines, o => o.ShipAddress, o => o.Customer)
        /// </summary>
        /// <typeparam name="TEntidad"></typeparam>
        /// <param name="includes"></param>
        /// <returns></returns>
        /// http://www.yagoperez.com/Post/GetPostByCode/como_cargar_las_entidades_relacionadas_en_una_arquitectura_multicapa_desde_un_repositorio_generico
        public IQueryable<TEntidad> CreateSet<TEntidad>(params Expression<Func<TEntidad, object>>[] includes) where TEntidad : class
        {
            return this.CreateSet<TEntidad>().IncludeMultiple(includes) as IQueryable<TEntidad>;
        }
    }
}
