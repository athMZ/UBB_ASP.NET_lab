using FluentValidation.TestHelper;
using Trips.DAL.DTOs;
using Trips.DAL.Validators;

namespace TripsTests
{
	public class CountryValidatorTests
	{
		private readonly CountryValidator _validator = new();

		[Fact]
		public void Should_Have_Error_When_Name_Is_Null()
		{
			var model = new CountryDto { Name = null };
			var result = _validator.TestValidate(model);
			result.ShouldHaveValidationErrorFor(x => x.Name);
		}

		[Fact]
		public void Should_Have_Error_When_Name_Is_Empty()
		{
			var model = new CountryDto { Name = string.Empty };
			var result = _validator.TestValidate(model);
			result.ShouldHaveValidationErrorFor(x => x.Name);
		}

		[Fact]
		public void Should_Have_Error_When_Name_Is_Longer_Than_25_Characters()
		{
			var model = new CountryDto { Name = new string('a', 26) };
			var result = _validator.TestValidate(model);
			result.ShouldHaveValidationErrorFor(x => x.Name);
		}

		[Fact]
		public void Should_Not_Have_Error_When_Name_Is_Valid()
		{
			var model = new CountryDto { Name = "Valid Name" };
			var result = _validator.TestValidate(model);
			result.ShouldNotHaveValidationErrorFor(x => x.Name);
		}
	}
}
