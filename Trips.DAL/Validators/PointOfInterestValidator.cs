using FluentValidation;
using Trips.DAL.DTOs;

namespace Trips.DAL.Validators
{
	public class PointOfInterestValidator : AbstractValidator<PointOfIntrestDto>
	{
		public PointOfInterestValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("Name is required.");

			RuleFor(x => x.Description)
				.NotEmpty()
				.WithMessage("Description is required.");

			RuleFor(x => x.CityId)
				.NotEmpty()
				.WithMessage("City is required");

		}
	}
}
