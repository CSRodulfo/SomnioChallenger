using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public interface IAuditable
    {
        bool deleted { get; set; }
        int op { get; set; }
        System.DateTime stamp { get; set; }

    }
}