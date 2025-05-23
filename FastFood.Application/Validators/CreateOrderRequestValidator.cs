using FastFood.Application.DTOs;
using FluentValidation;

namespace FastFood.Application.Validators
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(order => order.Products)
               .NotNull().WithMessage("O Id dos Produtos é obrigatório");
        }
    }
}
