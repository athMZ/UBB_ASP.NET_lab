using FluentValidation.TestHelper;
using Trips.DAL.DTOs;
using Trips.DAL.Validators;
using Xunit;

namespace TripsTests
{
    public class CityValidatorTests
    {
        private readonly CityValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_Name_Is_Null()
        {
            var model = new CityDto { Name = null };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var model = new CityDto { Name = string.Empty };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Longer_Than_25_Characters()
        {
            var model = new CityDto { Name = new string('a', 26) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Have_Error_When_Description_Is_Null()
        {
            var model = new CityDto
            {
	            Description = null,
	            Name = null!
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void Should_Have_Error_When_Description_Is_Empty()
        {
            var model = new CityDto
            {
	            Description = string.Empty,
	            Name = null!
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void Should_Have_Error_When_Description_Is_Longer_Than_200_Characters()
        {
            var model = new CityDto
            {
	            Description = new string('a', 201),
	            Name = null!
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void Should_Have_Error_When_CountryId_Is_Null()
        {
	        var model = new CityDto
	        {
		        Name = null
	        };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.CountryId);
        }

        [Fact]
        public void Should_Not_Have_Error_When_All_Fields_Are_Valid()
        {
            var model = new CityDto { Name = "Valid Name", Description = "Valid Description", CountryId = 1 };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
