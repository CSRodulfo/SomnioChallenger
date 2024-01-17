using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.MVC.Common.Extensions
{
    public class MobyDickCompareAttribute : System.ComponentModel.DataAnnotations.CompareAttribute, IClientValidatable
    {
        /// <summary>
        /// Compare Attribute con internalizacion
        /// </summary>
        /// <param name="otherProperty">La propiedad por la que se desea comparar</param>
        /// <param name="ErrorMessage">Opcional que permite sobreescribir el mensaje de error en caso de ser necesario</param>
        public MobyDickCompareAttribute(string otherProperty, string ErrorMessage = "")
            : base(otherProperty)
        {
            _otherProperty = otherProperty;
            _errorMessage = ErrorMessage;
        }

        string _otherProperty;
        string _errorMessage;

        public override string FormatErrorMessage(string name)
        {
            if (string.IsNullOrEmpty(_errorMessage))
            {
                var msg = Default.Resources.CompareErrorMessage;
                return string.Format(msg, name);
            }
            else
                return _errorMessage;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule() { ValidationType = "equalto", ErrorMessage = FormatErrorMessage(metadata.DisplayName) };
            rule.ValidationParameters.Add("other", _otherProperty);
            
            yield return rule ;
        }
    }
}