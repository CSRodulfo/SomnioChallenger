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
using System.Reflection;

namespace Infrastructure.Data
{
    public static class ExtensionDbContext
    {
        /// <summary>
        /// A partir de un IQueryable aplicado a una entidad definida, se aplica la estrategia de Paginado
        /// y se devuelve la misma query con el agregado del paginado.
        /// </summary>        
        public static IQueryable<T> PagedData<T>(this IQueryable<T> query, StrategyPagedData strategy) where T : class
        {
            return strategy.ApplyStrategy(query);
        }

        /// <summary>
        /// Permite la carga de relaciones con expresiones lambda, sin especificar el include 
        /// ej: this.CreateSet(o => o.Id == id, o => o.OrderLines, o => o.ShipAddress, o => o.Customer)
        /// http://www.yagoperez.com/Post/GetPostByCode/como_cargar_las_entidades_relacionadas_en_una_arquitectura_multicapa_desde_un_repositorio_generico
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }

        /// <summary>
        /// A partir de un IQueryable aplicado a una entidad definida, se aplica la estrategia de Paginado
        /// y se devuelve la misma query con el agregado del paginado.
        /// </summary>          
        public static IQueryable<T> StrategyDeleted<T>(this IQueryable<T> query)
        {
            var parameter = Expression.Parameter(typeof(T), typeof(T).Name);
            var propertyName = "deleted";

            PropertyInfo property;
            Expression propertyAccess;

            property = typeof(T).GetProperty(propertyName);
            propertyAccess = Expression.MakeMemberAccess(parameter, property);

            LambdaExpression expresion = Expression.Lambda(propertyAccess, parameter);

            var equalExpression = Expression.Equal(propertyAccess, Expression.Constant(false));

            /// Creación de la expresión a agregar a la query, ya con la obtención
            /// de las propiedades en una Expresión Lambda.
            MethodCallExpression resultExp = Expression.Call(
                                                typeof(Queryable), "Where",
                                                new[] { typeof(T) }, 
                                                query.Expression,
                                                Expression.Lambda<Func<T, bool>>(equalExpression, 
                                                new[] { parameter })
                                                );

            return query.Provider.CreateQuery<T>(resultExp) as IQueryable<T>;
        }
    }
}
