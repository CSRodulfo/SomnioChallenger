using Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MySql
{
    public class SomnioMap : ClassMap<Somnio>
    {
        public SomnioMap()
        {
            //LazyLoad();
            Id(x => x.Id);
            Map(x => x.Quantity).Not.Nullable();
            Map(x => x.TotalCost).Not.Nullable();
            Map(x => x.Date).Not.Nullable();

            //References(c => c.Address);
            //References<Address>(x => x.CustomerAddresstID).Column("CustomerAddresstID").ForeignKey("AddressID");
            Table("tbl_Somnio");
        }
    }
}
