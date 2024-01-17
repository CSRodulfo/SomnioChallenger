using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.MVC.Common.Extensions
{
    public class MobyDickDisplayNameAttribute : DisplayNameAttribute
    {
        public MobyDickDisplayNameAttribute(string displayNameKey)
            : base(displayNameKey)
        {
        }

        public Type ResourceType { get; set; }

        public override string DisplayName
        {
            get
            {
                try
                {
                    var resources = Activator.CreateInstance(ResourceType);
                    var property = ResourceType.GetProperty(base.DisplayNameValue);
                    var s = property.GetValue(resources);

                    if (s == null)
                        return "[" + base.DisplayNameValue + "]";
                    else
                        return s.ToString();
                }
                catch
                {
                    return "[" + base.DisplayNameValue + "]";
                }
            }
        }
    }
}