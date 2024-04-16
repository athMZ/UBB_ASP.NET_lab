using FluentValidation;
using Trips.DAL.DTOs;

namespace Trips.DAL.Validators
{
	public class TripValidator : AbstractValidator<TripDto>
	{
		public TripValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Name is required.")
				.MaximumLength(50).WithMessage("Name cannot be longer than 50 characters.");

			RuleFor(x => x.Description)
				.MaximumLength(200).WithMessage("Description cannot be longer than 200 characters.");

			RuleFor(x => x.StartDate)
				.NotEmpty().WithMessage("Start Date is required.")
				.LessThanOrEqualTo(x => x.EndDate).WithMessage("Start Date cannot be later than End Date.");

			RuleFor(x => x.EndDate)
				.NotEmpty().WithMessage("End Date is required.")
				.GreaterThanOrEqualTo(x=>x.StartDate).WithMessage("End Date cannot be earlier than Start Date");

			RuleFor(x => x.Price)
				.GreaterThanOrEqualTo(0).WithMessage("Price cannot be negative.");

			RuleFor(x => x.Seats)
				.GreaterThan(0).WithMessage("Seats must be greater than 0.");

		}
	}
}
