using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trips.DAL.Data;
using Trips.DAL.Models;

namespace Trips.DAL.Repositories
{
    public class ReservationRepository : ARepository<Reservation, int>
    {
        public ReservationRepository(TripContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Reservation> GetAll()
        {
            return Context.Reservations
                .AsNoTracking()
                .Include(reservation => reservation.Customer)
                .Include(reservation => reservation.Trip);
        }

        public override Reservation? GetById(int id)
        {
            return Context.Reservations
                .AsNoTracking()
                .Include(reservation => reservation.Customer)
                .Include(reservation => reservation.Trip)
                .FirstOrDefault(reservation => reservation.Id == id);
        }

        public override void Insert(Reservation entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            Context.Reservations.Add(entity);
        }

        public override void Update(Reservation entity)
        {
/*            ArgumentNullException.ThrowIfNull(entity);

            var reservation = GetById(entity.Id);
            if (reservation == null)
                throw new InvalidOperationException("Reservation not found.");

            Context.Reservations.Update(reservation);

            reservation.CustomerId = entity.CustomerId;
            reservation.TripId = entity.TripId;
            reservation.Confirmed = entity.Confirmed;*/
        }

        public override void Delete(int id)
        {
            var reservation = GetById(id);

            if (reservation == null)
                throw new InvalidOperationException("Reservation not found.");

            Context.Reservations.Remove(reservation);
        }

        public override void Delete(Reservation entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            Delete(entity.Id);
        }

        public override bool Exists(int id) => Context.Reservations.Any(c => c.Id == id);


        public override bool Exists(Reservation entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            return Exists(entity.Id);
        }
    }
}
