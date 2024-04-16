using FluentValidation;
using Trips.DAL.DTOs;

namespace Trips.DAL.Validators
{
	public class CityValidator : AbstractValidator<CityDto>
	{
		public CityValidator()
		{
			RuleFor(x => x.Name).NotEmpty().MaximumLength(25);
			RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
			RuleFor(x => x.CountryId).NotEmpty();
		}

	}
}
