using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Resources.Libraries.PagedData
{
    /// <summary>
    /// El propósito de esta clase, es del envío de los parámetros necesarios para una búsqueda con paginado.    
    /// </summary>
    public class PagedDataParametersExcel : PagedData
    {
        private string _orderField;
        private Define.OrderBy _orderDirection;

        public PagedDataParametersExcel(string orderField, string orderDirection)
            : this(orderField, orderDirection == "asc" ? Define.OrderBy.Ascendant : Define.OrderBy.Descendant)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orderfield">Campo de Orden </param>
        /// <param name="orderdirection">Tipo de Orden</param>
        public PagedDataParametersExcel(string orderfield, Define.OrderBy orderdirection)
        {
            _orderDirection = orderdirection;
            _orderField = orderfield;
        }

        /// <summary>
        /// Campo por el cual se realizara el orden
        /// </summary>
        public string OrderField
        {
            get
            { return _orderField; }
        }

        public Define.OrderBy OrderDirection
        {
            get
            { return _orderDirection; }
        }

        public override StrategyPagedData Get()
        {
            switch (this.OrderDirection)
            {
                case Domain.Resources.Define.OrderBy.Ascendant:
                    return new FullDataAsc(this);

                case Domain.Resources.Define.OrderBy.Descendant:
                    return new FullDataAsc(this);

                default:
                    return null;
            }
        }
    }
}
