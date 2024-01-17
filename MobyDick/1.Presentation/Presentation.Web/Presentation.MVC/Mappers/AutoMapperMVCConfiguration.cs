using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Infrastructure.Cross.IoC;
using Presentation.MVC.Mappers;

namespace EFMVC.Web.Mappers
{
    public class AutoMapperMVCConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.ConstructServicesUsing(type => FactoryIoC.Container.Resolve(type));
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
                x.AddProfile<AutoMapperFilter>();
            });
        }
    }
}
