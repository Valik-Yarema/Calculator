using AutoMapper;
using Model.DB;
using Model.ViewModels.ComputingViewModels;
using Model.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<ApplicationUser, RegisterViewModel>().ReverseMap();
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();

            CreateMap<Computing, ComputingViewModel>().ReverseMap();
            CreateMap<Computing, ComputingCreateViewModel>().ReverseMap();
              
            

        }
    }
}
