using FluentValidation;
using Trips.DAL.DTOs;

namespace Trips.DAL.Validators
{
	public class ReservationValidator : AbstractValidator<ReservationDto>
	{
		public ReservationValidator()
		{
			RuleFor(x=>x.CustomerId)
				.NotNull().WithMessage("Reservation must have a customer.")
				.NotEmpty().WithMessage("Reservation must have a customer.");

			RuleFor(x=>x.TripId)
				.NotNull().WithMessage("Reservation must have a trip.")
				.NotEmpty().WithMessage("Reservation must have a trip.");

			RuleFor(x => x.Confirmed)
				.NotNull()
				.NotEmpty();
		}
	}
}
