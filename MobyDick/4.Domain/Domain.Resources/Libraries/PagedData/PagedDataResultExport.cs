using EPPlusEnumerable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Resources.Libraries.PagedData
{
    /// <summary>
    /// Esta propósito de esta clase es el envío del resultado de una búsqueda por paginado.
    /// </summary>    
    public class PagedDataResultExport
    {
        private List<object> _results;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="list">Lista de Resultados</param>
        /// <param name="count">Total de filas en la consulta</param>
        public PagedDataResultExport(List<object> list)
        {
            this._results = list;
        }

        /// <summary>
        /// Total de filas contenidas en la consulta, más allá del paginado impuesto
        /// </summary>
        public byte[] GetFileExcel()
        {
            if (_results.Count > 0)
                return Spreadsheet.Create(_results);
            else
                return new byte[0];
        }

        /// <summary>
        /// Genera un archivo CSV a partir de los resultados
        /// </summary>
        public byte[] GetFileCsv()
        {
            if (_results.Count > 0)
                return CreateCSVTextFile(_results.ToList());
            else
                return new byte[0];
        }

        /// <summary>
        /// Genera un archivo CSV a partir de los resultados
        /// </summary>
        public byte[] GetFileCsv(string separator)
        {
            if (_results.Count > 0)
                return CreateCSVTextFile(_results.ToList(),separator);
            else
                return new byte[0];
        }

        private byte[] CreateCSVTextFile<T>(List<T> data, string separator = ",")
        {
            if (data.Count > 0)
            {
                var properties = data[0].GetType().GetProperties();
                var result = new StringBuilder();

                foreach (var row in data)
                {
                    var values = properties.Select(p => p.GetValue(row, null));
                    var line = string.Join(separator, values);
                    result.AppendLine(line);
                }

                byte[] bytes = new byte[result.Length * sizeof(char)];
                System.Buffer.BlockCopy(result.ToString().ToCharArray(), 0, bytes, 0, bytes.Length);
                return bytes;
            }
            else
                return new byte[0];
        }
    }
}
