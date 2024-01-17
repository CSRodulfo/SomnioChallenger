using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.MVC.Common.Extensions
{
    public class MobyDickRequiredAttribute : RequiredAttribute, IClientValidatable
    {
        public override string FormatErrorMessage(string name)
        {
            var msg = Default.Resources.Required;
            return string.Format(msg, name);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                // format the error message to include the property's display name.
                ErrorMessage = FormatErrorMessage(metadata.DisplayName),

                // uses the required validation type.
                ValidationType = "required"
            };
        }

    }
}