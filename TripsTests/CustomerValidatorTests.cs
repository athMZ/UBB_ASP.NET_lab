using FluentValidation.TestHelper;
using Trips.DAL.DTOs;
using Trips.DAL.Validators;

namespace TripsTests
{
	public class CustomerValidatorTests
	{
		private readonly CustomerValidator _validator = new();

		[Fact]
		public void Should_Have_Error_When_FirstName_Is_Null()
		{
			var model = new CustomerDto
			{
				FirstName = null!,
				LastName = null!,
				Email = null!
			};
			var result = _validator.TestValidate(model);
			result.ShouldHaveValidationErrorFor(x => x.FirstName);
		}

		[Fact]
		public void Should_Have_Error_When_FirstName_Is_Empty()
		{
			var model = new CustomerDto
			{
				FirstName = string.Empty,
				LastName = null!,
				Email = null!
			};
			var result = _validator.TestValidate(model);
			result.ShouldHaveValidationErrorFor(x => x.FirstName);
		}

		[Fact]
		public void Should_Have_Error_When_FirstName_Is_Longer_Than_25_Characters()
		{
			var model = new CustomerDto
			{
				FirstName = new string('a', 26),
				LastName = null!,
				Email = null!
			};
			var result = _validator.TestValidate(model);
			result.ShouldHaveValidationErrorFor(x => x.FirstName);
		}

		[Fact]
		public void Should_Have_Error_When_LastName_Is_Null()
		{
			var model = new CustomerDto
			{
				LastName = null!,
				FirstName = null!,
				Email = null!
			};
			var result = _validator.TestValidate(model);
			result.ShouldHaveValidationErrorFor(x => x.LastName);
		}

		[Fact]
		public void Should_Have_Error_When_LastName_Is_Empty()
		{
			var model = new CustomerDto
			{
				LastName = string.Empty,
				FirstName = null!,
				Email = null!
			};
			var result = _validator.TestValidate(model);
			result.ShouldHaveValidationErrorFor(x => x.LastName);
		}

		[Fact]
		public void Should_Have_Error_When_LastName_Is_Longer_Than_25_Characters()
		{
			var model = new CustomerDto
			{
				LastName = new string('a', 26),
				FirstName = null!,
				Email = null!
			};
			var result = _validator.TestValidate(model);
			result.ShouldHaveValidationErrorFor(x => x.LastName);
		}

		[Fact]
		public void Should_Have_Error_When_Email_Is_Null()
		{
			var model = new CustomerDto
			{
				Email = null!,
				FirstName = null!,
				LastName = null!
			};
			var result = _validator.TestValidate(model);
			result.ShouldHaveValidationErrorFor(x => x.Email);
		}

		[Fact]
		public void Should_Have_Error_When_Email_Is_Empty()
		{
			var model = new CustomerDto
			{
				Email = string.Empty,
				FirstName = null!,
				LastName = null!
			};
			var result = _validator.TestValidate(model);
			result.ShouldHaveValidationErrorFor(x => x.Email);
		}

		[Fact]
		public void Should_Have_Error_When_Email_Is_Invalid()
		{
			var model = new CustomerDto
			{
				Email = "invalidEmail",
				FirstName = null!,
				LastName = null!
			};
			var result = _validator.TestValidate(model);
			result.ShouldHaveValidationErrorFor(x => x.Email);
		}

		[Fact]
		public void Should_Not_Have_Error_When_All_Fields_Are_Valid()
		{
			var model = new CustomerDto { FirstName = "ValidFirstName", LastName = "ValidLastName", Email = "valid@example.com" };
			var result = _validator.TestValidate(model);
			result.ShouldNotHaveAnyValidationErrors();
		}
	}
}
