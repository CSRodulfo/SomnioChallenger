using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainModule.Somnio
{
    public class DTOSomnioTable
    {
        public virtual int Id { get; set; }
        public virtual int Quantity { get; set; }
        public virtual int TotalCost { get; set; }
        public virtual DateTime Date { get; set; }
    }
}
