using AutoMapper;
using MODELS.DB;
using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Services
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Constructor with all mappings
        /// </summary>
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects

            //==================================
            CreateMap<BlockedUser, BlockedUserViewModel>()
                .ForMember(bview => bview.Id, bmod => bmod.MapFrom(src => src.Id))
                .ForMember(bview => bview.Email, bmod => bmod.MapFrom(src => src.Email))
                .ReverseMap();

            CreateMap<Car, CarViewModel>().ReverseMap();
            CreateMap<CarType, CarTypeViewModel>().ReverseMap();
            CreateMap<City, CityViewModel>().ReverseMap();
            CreateMap<Color, ColorViewModel>().ReverseMap();
            CreateMap<Location, LocationViewModel>().ReverseMap();
            CreateMap<LocationCar, LocationCarViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<PhotoCar, PhotoCarViewModel>().ReverseMap();
            CreateMap<PhotoUser, PhotoUserViewModel>().ReverseMap();
            CreateMap<RequiredInformation, RequiredInformationViewModel>().ReverseMap();
            CreateMap<Transmission, TransmissionViewModel>().ReverseMap();

        }

        
    }
}
