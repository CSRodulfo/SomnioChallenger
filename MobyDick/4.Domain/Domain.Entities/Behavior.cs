//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Behavior
    {
        public Behavior()
        {
            this.RoleInBehavior = new HashSet<RoleInBehavior>();
            this.Menu = new HashSet<Menu>();
        }
    
        public int IDBehavior { get; set; }
        public string BehaviorName { get; set; }
        public int op { get; set; }
        public System.DateTime stamp { get; set; }
    
        public virtual ICollection<RoleInBehavior> RoleInBehavior { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
    }
}
