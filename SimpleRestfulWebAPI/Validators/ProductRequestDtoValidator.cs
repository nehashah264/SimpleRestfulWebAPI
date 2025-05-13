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
                .WithMessage("Product Name is required.");

            RuleFor(x => x.Data)
              .NotEmpty()
              .WithMessage("Product Data is required.");
        }
    }
}
