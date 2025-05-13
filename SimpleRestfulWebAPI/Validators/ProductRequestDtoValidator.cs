using FluentValidation;
using SimpleRestfulWebAPI.Domain.Models;

namespace SimpleRestfulWebAPI.Validators
{
    public class ProductRequestDtoValidator : AbstractValidator<ProductAddRequestDto>
    {
        public ProductRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Product Name is required.")
                .MaximumLength(150)
                .WithMessage("Product Name cannot exceed for more than 150 characters!");

            RuleFor(x => x.Data)
              .NotEmpty()
              .WithMessage("Product Data is required.");
        }
    }
}
