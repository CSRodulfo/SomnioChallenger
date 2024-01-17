using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Presentation.MVC.Common;
using Application.MainModule.Administration.RolesManagement.DTO;
using Application.MainModule.Administration.CompanyManagement.DTO;
using Presentation.MVC.Models;

namespace EFMVC.Web.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<DTOUserForEdit, EditModel>();
            Mapper.CreateMap<DTOCompany, CompanyModel>();
            Mapper.CreateMap<DTOMenuesForEdit, MenuEditModels>();
        }
    }
}