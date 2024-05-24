using FluentValidation.TestHelper;
using Trips.DAL.DTOs;
using Trips.DAL.Validators;

namespace TripsTests
{
    public class ReservationValidatorTests
    {
        private readonly ReservationValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_CustomerId_Is_Null()
        {
	        var model = new ReservationDto
	        {
		        TripId = 0,
		        CustomerId = "",
		        Confirmed = null
	        };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.CustomerId);
        }

        [Fact]
        public void Should_Have_Error_When_TripId_Is_Null()
        {
	        var model = new ReservationDto
	        {
		        TripId = 0,
		        CustomerId = "",
		        Confirmed = null
	        };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.TripId);
        }

        [Fact]
        public void Should_Have_Error_When_Confirmed_Is_Null()
        {
            var model = new ReservationDto
            {
	            Confirmed = null,
	            TripId = 0,
	            CustomerId = ""
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Confirmed);
        }

        [Fact]
        public void Should_Not_Have_Error_When_All_Fields_Are_Valid()
        {
            var model = new ReservationDto { CustomerId = "1", TripId = 1, Confirmed = true };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
