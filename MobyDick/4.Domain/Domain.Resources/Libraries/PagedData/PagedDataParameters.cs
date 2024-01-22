using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Resources.Libraries.PagedData
{
    /// <summary>
    /// El propósito de esta clase, es del envío de los parámetros necesarios para una búsqueda con paginado.    
    /// </summary>
    public class PagedDataParameters : PagedData
    {
        private string _orderField;
        private Define.OrderBy _orderDirection;
        private int _page;
        private int _rows;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orderfield">Campo de Orden </param>
        /// <param name="orderdirection">Tipo de Orden</param>
        /// <param name="page">Cantidad de Paginas</param>
        /// <param name="rows">Cantidad de Filas por Pagina</param>
        [Obsolete("No usar este constructor")]
        public PagedDataParameters(string orderfield, Define.OrderBy orderdirection, int page, int rows)
        {
            _rows = rows;
            _page = page;
            _orderDirection = orderdirection;
            _orderField = orderfield;
        }

        /// </summary>
        /// <param name="orderfield">Campo de Orden </param>
        /// <param name="orderdirection">Tipo de Orden</param>
        /// <param name="page">Cantidad de Paginas</param>
        /// <param name="rows">Cantidad de Filas por Pagina</param>
        public PagedDataParameters(string orderfield, string sord, int page, int rows)
        {
            _rows = rows;
            _page = page;
            _orderDirection = sord == "asc" ? Define.OrderBy.Ascendant : Define.OrderBy.Descendent;
            _orderField = orderfield;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orderfield">Campo de Orden </param>
        /// <param name="orderdirection">Tipo de Orden</param>
        public PagedDataParameters(string orderfield, Define.OrderBy orderdirection)
        {
            _orderDirection = orderdirection;
            _orderField = orderfield;
        }

        /// <summary>
        /// Campo por el cual se realizara el orden
        /// </summary>
        public string OrderField
        {
            get { return _orderField; }
            set { _orderField = value; }
        }

        public Define.OrderBy OrderDirection
        {
            get { return _orderDirection; }
            set { _orderDirection = value; }
        }

        /// <summary>
        /// Cantidad de Paginas
        /// </summary>
        public int Page
        {
            get
            { return _page; }
        }

        /// <summary>
        /// Cantidad de Filas por Pagina
        /// </summary>
        public int Rows
        {
            get
            { return _rows; }
        }

        public override StrategyPagedData Get()
        {
            switch (this.OrderDirection)
            {
                case Domain.Resources.Define.OrderBy.Ascendant:
                    return new FullPagedDataAsc(this);

                case Domain.Resources.Define.OrderBy.Descendent:
                    return new FullPagedDataDesc(this);

                default:
                    return null;
            }
        }
    }
}
