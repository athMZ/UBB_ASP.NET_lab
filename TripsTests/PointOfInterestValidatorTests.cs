using FluentValidation.TestHelper;
using Trips.DAL.DTOs;
using Trips.DAL.Validators;

namespace TripsTests
{
    public class PointOfInterestValidatorTests
    {
        private readonly PointOfInterestValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_Name_Is_Null()
        {
            var model = new PointOfIntrestDto { Name = null };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var model = new PointOfIntrestDto { Name = string.Empty };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Have_Error_When_Description_Is_Null()
        {
            var model = new PointOfIntrestDto
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
            var model = new PointOfIntrestDto
            {
	            Description = string.Empty,
	            Name = null!
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void Should_Have_Error_When_CityId_Is_Null()
        {
	        var model = new PointOfIntrestDto
	        {
		        Name = null!
	        };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.CityId);
        }

        [Fact]
        public void Should_Not_Have_Error_When_All_Fields_Are_Valid()
        {
            var model = new PointOfIntrestDto { Name = "Valid Name", Description = "Valid Description", CityId = 1 };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
