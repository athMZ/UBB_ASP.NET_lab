using AutoMapper;
using Trips.DAL.DTOs;
using Trips.DAL.Models;

namespace Trips.DAL.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<City, CityDto>()
                .ForMember(
                    dest => dest.CountryId,
                    opt => opt.MapFrom(src => src.Country.Id)
                )
                .ForMember(
                    dest => dest.CountryName,
                    opt => opt.MapFrom(src => src.Country.Name)
                );

            CreateMap<CityDto, City>()
                .ForMember(dest => dest.Country,
                    opt => opt.MapFrom(src => new Country { Id = src.CountryId, Name = "" }));

            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            CreateMap<Photo, PhotoDto>();
            CreateMap<PhotoDto, Photo>();

            CreateMap<PointOfIntrest, PointOfIntrestDto>().ForMember(
                dest => dest.CityName,
                opt => opt.MapFrom(src => src.City.Name)
            ); ;
            CreateMap<PointOfIntrestDto, PointOfIntrest>();

            CreateMap<Reservation, ReservationDto>();
            CreateMap<ReservationDto, Reservation>();

            CreateMap<Trip, TripDto>()
                .ForMember(
                    dest => dest.ReservationsIds,
                    opt => opt.MapFrom(src => src.Reservations.Select(r => r.Id))
                )
                .ForMember(
	                dest => dest.PointsOfIntrestIds,
	                opt => opt.MapFrom(src => src.PointsOfIntrest.Select(r => r.Id))
                );

            CreateMap<TripDto, Trip>()
                .ForMember(
                    dest => dest.Reservations,
                    opt => opt
                        .MapFrom(src => (src.ReservationsIds).Select(r => new Reservation
                            {
                                Id = r,
                                Confirmed = null,
                                Trip = null,
                                Customer = null,
                                TripId = 0,
                                CustomerId = ""
                            })
                        )
                    );
        }
    }
}
