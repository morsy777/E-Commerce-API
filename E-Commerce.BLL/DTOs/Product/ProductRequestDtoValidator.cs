using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.DTOs.Product;
public class ProductRequestDtoValidator : AbstractValidator<ProductRequestDto>
{
    public ProductRequestDtoValidator()
    {

        RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty();


        RuleFor(x => x.Price)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.Description)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Image)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.StockQuantity)
            .NotEmpty()
            .NotNull();
    }
}
