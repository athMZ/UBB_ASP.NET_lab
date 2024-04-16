using FluentValidation;
using Trips.DAL.DTOs;

namespace Trips.DAL.Validators
{
	public class CountryValidator : AbstractValidator<CountryDto>
	{
		public CountryValidator()
		{
			RuleFor(x => x.Name).NotEmpty().MaximumLength(25);
		}
	}
}
