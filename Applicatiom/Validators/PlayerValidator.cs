using Domain.Entities;
using FluentValidation;

namespace Applicatiom.Validators
{
    public class PlayerValidator : AbstractValidator<Player>
    {
        public PlayerValidator()
        {
            // por default deixamos as regras de validacao aqui no construtor.
            
            RuleFor(player => player.Name)
                .NotEmpty()
                .WithMessage("O nome é obrigatório.")
                .Length(2, 150)
                .WithMessage("O nome deve possuir entre 2 e 150 caracteres");


        }
    }
}