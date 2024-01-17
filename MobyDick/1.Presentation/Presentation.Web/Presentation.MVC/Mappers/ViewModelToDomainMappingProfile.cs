using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Presentation.MVC.Models;
using Application.MainModule.Administration.RolesManagement.DTO;
using Application.MainModule.Administration.CompanyManagement.DTO;

namespace EFMVC.Web.Mappers
{
    class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<EditModel, DTOUserForEdit>();
            Mapper.CreateMap<CompanyModel, DTOCompany>();
            Mapper.CreateMap<MenuEditModels, DTOMenuesForEdit>();
        }
    }
}