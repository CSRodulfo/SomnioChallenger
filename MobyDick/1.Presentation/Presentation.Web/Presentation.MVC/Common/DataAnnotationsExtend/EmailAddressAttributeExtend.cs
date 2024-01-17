using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Resources;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Presentation.MVC.Common.Extensions
{
    public class MobyDickEmailAddress : RegularExpressionAttribute
    {
        static MobyDickEmailAddress()
        {
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(MobyDickEmailAddress), typeof(RegularExpressionAttributeAdapter));
        }

        public MobyDickEmailAddress()
            : base(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                + "@"
                + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$") { }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(Default.Resources.EmailAddressErrorMessage);
        }
    }
}