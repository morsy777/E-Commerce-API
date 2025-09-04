using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.DTOs.Orders;
public class OrderRequestDtoValidator : AbstractValidator<OrderRequestDto>
{
    public OrderRequestDtoValidator()
    {
        RuleFor(x => x.OrderDate)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.TotalAmount)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.Status)
            .NotEmpty()
            .NotNull();
    }
}
