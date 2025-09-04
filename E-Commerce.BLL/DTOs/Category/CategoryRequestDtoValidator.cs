using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.DTOs.Category;
public class CategoryRequestDtoValidator: AbstractValidator<CategoryRequestDto>
{
    public CategoryRequestDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Prefix)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.ImageData)
            .NotEmpty()
            .NotNull();
    }
}
