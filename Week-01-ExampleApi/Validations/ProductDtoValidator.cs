using ExampleApi.Dtos;
using FluentValidation;

namespace ExampleApi.Validations
{
    /// <summary>
    /// Fluent validation ürünler implementasyonu
    /// </summary>
    public class ProductDtoValidator: AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş bırakılamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş bırakılamaz");
           
        }


    }
}
