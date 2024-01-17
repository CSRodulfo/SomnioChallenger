using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.MVC.Common.Extensions
{
    public class MobyDickStringLengthAttribute : StringLengthAttribute, IClientValidatable
    {
        /// <summary>
        /// Constructor that accepts the maximum length of the string.
        /// </summary>
        /// <param name="maximumLength">The maximum length, inclusive.  It may not be negative.</param>
        public MobyDickStringLengthAttribute(int maximumLength, int minimumLength = 0)
            : base(maximumLength)
        {
            base.MinimumLength = minimumLength;
        }

        public override string FormatErrorMessage(string name)
        {
            var msg = base.MinimumLength == 0 ? Default.Resources.StringLengthErrorMessage
                : Default.Resources.StringLengthMinimumErrorMessage;
            return string.Format(msg, name, base.MaximumLength, base.MinimumLength);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            StringLengthAttributeAdapter adapt = new StringLengthAttributeAdapter(metadata, context, this);
            return adapt.GetClientValidationRules();
        }
    }
}