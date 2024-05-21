using AutoMapper;
using Trips.DAL.DTOs;
using Trips.DAL.Interfaces;
using Trips.DAL.Models;

namespace Trips.DAL.Services
{
	public class TripService : ITripService
	{
		private readonly IRepository<Trip, int> _tripRepository;
		private readonly IMapper _mapper;

		public TripService(IRepository<Trip, int> tripRepository, IMapper mapper)
		{
			_tripRepository = tripRepository;
			_mapper = mapper;
		}

		public IEnumerable<TripDto> GetAll()
		{
			var trips = _tripRepository.GetAll();
			var result = _mapper.Map<IEnumerable<TripDto>>(trips);
			return result;
		}

		public TripDto GetById(int id)
		{
			var trip = _tripRepository.GetById(id);
			var result = _mapper.Map<TripDto>(trip);
			return result;
		}

		public bool Exists(int id)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public void Insert(TripDto tripDto)
		{
			throw new NotImplementedException();
		}

		public void Update(TripDto tripDto)
		{
			throw new NotImplementedException();
		}
	}
}
