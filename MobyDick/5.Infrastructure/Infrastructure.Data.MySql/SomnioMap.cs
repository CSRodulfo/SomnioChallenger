using Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MySql
{
    internal class SomnioMap : ClassMap<SomnioTable>
    {
        public SomnioMap()
        {
            //LazyLoad();
            Id(x => x.Id);
            Map(x => x.Name);
            
            //Map(x => x.Email).Not.Nullable().Length(50);
            
            //References(c => c.Address);
            //References<Address>(x => x.CustomerAddresstID).Column("CustomerAddresstID").ForeignKey("AddressID");
            Table("Somnio");
        }
    }
}
