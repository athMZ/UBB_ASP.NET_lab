using AutoMapper;
using Trips.DAL.DTOs;
using Trips.DAL.Models;

namespace Homework_Trips.Infrastructure
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
					dest=>dest.CountryName,
					opt => opt.MapFrom(src=>src.Country.Name)
				);
			
			CreateMap<CityDto, City>()
				.ForMember(dest => dest.Country,
					opt => opt.MapFrom( src=>new Country{Id = src.CountryId, Name = ""}));

			CreateMap<Country, CountryDto>();
			CreateMap<CountryDto, Country>();

			CreateMap<Customer, CustomerDto>();
			CreateMap<CustomerDto, Customer>();
		}
	}
}
