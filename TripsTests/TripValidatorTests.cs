using FluentValidation.TestHelper;
using Trips.DAL.DTOs;
using Trips.DAL.Validators;

namespace TripsTests
{
    public class TripValidatorTests
    {
        private readonly TripValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_Name_Is_Null()
        {
            var model = new TripDto { Name = null };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var model = new TripDto { Name = string.Empty };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Longer_Than_50_Characters()
        {
            var model = new TripDto { Name = new string('a', 51) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Have_Error_When_Description_Is_Longer_Than_200_Characters()
        {
            var model = new TripDto
            {
	            Description = new string('a',
		            201),
	            Name = null!
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void Should_Have_Error_When_StartDate_Is_Later_Than_EndDate()
        {
            var model = new TripDto
            {
	            StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
	            EndDate = DateOnly.FromDateTime(DateTime.Now.Date),
	            Name = null!
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.StartDate);
        }

        [Fact]
        public void Should_Have_Error_When_EndDate_Is_Earlier_Than_StartDate()
        {
            var model = new TripDto
            {
	            StartDate = DateOnly.FromDateTime(DateTime.Now.Date),
	            EndDate = DateOnly.FromDateTime(DateTime.Now.Date.AddDays(-1)),
	            Name = null!
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.EndDate);
        }

        [Fact]
        public void Should_Have_Error_When_Price_Is_Negative()
        {
            var model = new TripDto
            {
	            Price = -1,
	            Name = null!
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Price);
        }

        [Fact]
        public void Should_Have_Error_When_Seats_Is_Zero()
        {
            var model = new TripDto
            {
	            Seats = 0,
	            Name = null!
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Seats);
        }

        [Fact]
        public void Should_Not_Have_Error_When_All_Fields_Are_Valid()
        {
            var model = new TripDto 
            { 
                Name = "Valid Name", 
                Description = "Valid Description", 
                StartDate = DateOnly.FromDateTime(DateTime.Now.Date), 
                EndDate = DateOnly.FromDateTime(DateTime.Now.Date.AddDays(1)), 
                Price = 100, 
                Seats = 1 
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
