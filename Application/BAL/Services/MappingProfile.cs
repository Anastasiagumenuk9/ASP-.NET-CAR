using AutoMapper;
using MODELS.DB;
using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BAL.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           

            CreateMap<Car, CarViewModel>().ReverseMap();

            CreateMap<BlockedUser, BlockedUserViewModel>().ReverseMap();

            CreateMap<CarType, CarTypeViewModel>()
                .ForMember(bview => bview.Id, bmod => bmod.MapFrom(src => src.Id))
                .ForMember(bview => bview.Name, bmod => bmod.MapFrom(src => src.Name));

            CreateMap<CarTypeViewModel, CarType>();

             CreateMap<City, CityViewModel>()
                .ForMember(bview => bview.Id, bmod => bmod.MapFrom(src => src.Id))
                .ForMember(bview => bview.Name, bmod => bmod.MapFrom(src => src.Name));

            CreateMap<CityViewModel, City>();


            CreateMap<Color, ColorViewModel>()
               .ForMember(bview => bview.Id, bmod => bmod.MapFrom(src => src.Id))
               .ForMember(bview => bview.Name, bmod => bmod.MapFrom(src => src.Name));

            CreateMap<ColorViewModel, Color>();

            CreateMap<Location, LocationViewModel>()
             .ForMember(bview => bview.Id, bmod => bmod.MapFrom(src => src.Id))
             .ForMember(bview => bview.Name, bmod => bmod.MapFrom(src => src.Name));

            CreateMap<LocationViewModel, Location>();

            CreateMap<Order, OrderViewModel>()
           .ForMember(bview => bview.Id, bmod => bmod.MapFrom(src => src.Id))
           .ForMember(bview => bview.IsConfirmed
           , bmod => bmod.MapFrom(src => src.IsConfirmed));

            CreateMap<OrderViewModel, Order>();

            CreateMap<Transmission, TransmissionViewModel>()
         .ForMember(bview => bview.Id, bmod => bmod.MapFrom(src => src.Id))
         .ForMember(bview => bview.Name
         , bmod => bmod.MapFrom(src => src.Name));

            CreateMap<OrderViewModel, Order>();



            CreateMap<RequiredInformation, RequiredInformationViewModel>().ReverseMap();

        }

    }
}
