/// <summary>
/// Se utiliza esta clase para la implementación de los distintos tipos de orden a aplicar en una grilla.
/// La idea original es utilizar la clase PagedDataParameters para reconocer que tipo de estrategia aplicar.
/// Luego cada estrategia hereda el método "ApplyStrategy", con el cual se confecciona la query necesaria.
/// </summary>
using Domain.Resources.Libraries.PagedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Domain.Resources.Libraries.PagedData
{
    public abstract class StrategyPagedData
    {
        public virtual IQueryable<T> ApplyStrategy<T>(IQueryable<T> source)
        {
            return source;
        }

        /// <summary>
        /// Devuelve la instancia de la estrategia a partir de los parámetros enviados.
        /// En este caso hacemos depender la estrategia del orden impuesto por la Grilla.
        /// </summary>                
        public static StrategyPagedData GetStrategy(PagedData parameters)
        {

            return parameters.Get();
           

        }

        /// <summary>
        /// Devuelve la instancia de la estrategia a partir de los parámetros enviados.
        /// En este caso hacemos depender la estrategia del orden impuesto por la Grilla.
        /// </summary>                
        public static StrategyPagedData GetStrategy(PagedDataParametersExcel parameters)
        {
            switch (parameters.OrderDirection)
            {
                case Domain.Resources.Define.OrderBy.Ascendant:
                    return new FullDataAsc(parameters);

                case Domain.Resources.Define.OrderBy.Descendent:
                    return new FullDataAsc(parameters);

                default:
                    return null;
            }
        }

    }
}
