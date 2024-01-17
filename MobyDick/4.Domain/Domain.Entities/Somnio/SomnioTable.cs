using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SomnioTable
    {
        private int id;
        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public SomnioTable()
        {
        }
    }
}
