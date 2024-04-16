using FluentValidation;
using Trips.DAL.DTOs;

namespace Trips.DAL.Validators
{
	public class PhotoValidator : AbstractValidator<PhotoDto>
	{
		public PhotoValidator()
		{
			RuleFor(photo => photo.Title).NotEmpty();
			RuleFor(photo => photo.AltText).NotEmpty();
			RuleFor(photo => photo.FileName)
				.NotEmpty()
				.NotNull().Must(BeAValidImage).WithMessage("FileName must be a valid image file name with .jpg, .jpeg, .png, .gif, or .bmp extension.");
		}

		private bool BeAValidImage(string? fileName)
		{
			if (fileName is null) return false;

			var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
			var extension = Path.GetExtension(fileName).ToLower();
			return allowedExtensions.Contains(extension);
		}
	}
}
