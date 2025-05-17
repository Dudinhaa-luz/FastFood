using FastFood.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Application.Validators
{
    public class CreateClientRequestValidator : AbstractValidator<CreateClientRequest>
    {
        public CreateClientRequestValidator()
        {
            RuleFor(client => client.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MinimumLength(3).WithMessage("O nome deve ter pelo menos 3 caracteres.");

            RuleFor(client => client.CPF)
                .Matches(@"^\d{11}$").WithMessage("O CPF deve conter 11 dígitos numéricos.");

            RuleFor(client => client.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("Formato de e-mail inválido.");

            RuleFor(client => client.Phone)
                .Matches(@"^\d{10,11}$").WithMessage("O telefone deve ter 10 ou 11 dígitos numéricos.");
        }
    }
}
