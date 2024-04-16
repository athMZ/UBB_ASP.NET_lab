using FluentValidation.TestHelper;
using Trips.DAL.DTOs;
using Trips.DAL.Validators;

namespace TripsTests
{
    public class PhotoValidatorTests
    {
        private readonly PhotoValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_Title_Is_Null()
        {
            var model = new PhotoDto
            {
	            Title = null!,
	            FileName = "a.jpg",
	            AltText = null!
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Title);
        }

        [Fact]
        public void Should_Have_Error_When_Title_Is_Empty()
        {
            var model = new PhotoDto
            {
	            Title = string.Empty,
	            FileName = "a.jpg",
	            AltText = null!
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Title);
        }

        [Fact]
        public void Should_Have_Error_When_AltText_Is_Null()
        {
            var model = new PhotoDto
            {
	            AltText = null!,
	            Title = null!,
	            FileName = "a.jpg"
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.AltText);
        }

        [Fact]
        public void Should_Have_Error_When_AltText_Is_Empty()
        {
            var model = new PhotoDto
            {
	            AltText = string.Empty,
	            Title = null!,
	            FileName = "a.jpg"
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.AltText);
        }

        [Fact]
        public void Should_Have_Error_When_FileName_Is_Null()
        {
            var model = new PhotoDto
            {
	            FileName = null!,
	            Title = null!,
	            AltText = null!
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.FileName);
        }

        [Fact]
        public void Should_Have_Error_When_FileName_Is_Empty()
        {
            var model = new PhotoDto
            {
	            FileName = string.Empty,
	            Title = null!,
	            AltText = null!
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.FileName);
        }

        [Fact]
        public void Should_Have_Error_When_FileName_Is_Not_A_Valid_Image()
        {
            var model = new PhotoDto
            {
	            FileName = "invalid.txt",
	            Title = null!,
	            AltText = null!
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.FileName);
        }

        [Fact]
        public void Should_Not_Have_Error_When_All_Fields_Are_Valid()
        {
            var model = new PhotoDto { Title = "Valid Title", AltText = "Valid AltText", FileName = "valid.jpg" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
