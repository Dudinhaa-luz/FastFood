using FastFood.Application.DTOs;
using FluentValidation;

namespace FastFood.Application.Validators
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("O código do produto é obrigatório.")
                .MinimumLength(3).WithMessage("O código deve ter pelo menos 3 caracteres.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                .MinimumLength(3).WithMessage("O nome deve ter pelo menos 3 caracteres.");

            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0.01m).WithMessage("O preço do produto deve ser no mínimo R$ 0,01.");

            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("A descrição deve ter no máximo 500 caracteres.");

            RuleFor(p => p.Category)
                .IsInEnum().WithMessage("Categoria inválida.");
        }
    }
}
