using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.MVC.Mappers
{
    public class AutoMapperFilter : Profile
    {
        public override string ProfileName
        {
            get { return "AutoMapperFilter"; }
        }

        protected override void Configure()
        {

        }
    }

    public class FromJsonTypeConverter<TDestination> : ITypeConverter<string, TDestination>
    {
        public TDestination Convert(ResolutionContext context)
        {
            var source = (string)context.SourceValue;

            return JsonConvert.DeserializeObject<TDestination>(source);
        }
    }


    public class ToJsonTypeConverter : ITypeConverter<object, string>
    {
        public string Convert(ResolutionContext context)
        {
            return JsonConvert.SerializeObject(context.SourceValue);
        }
    }
}