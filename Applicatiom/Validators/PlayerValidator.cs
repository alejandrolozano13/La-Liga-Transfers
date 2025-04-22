using Domain.Entities;
using FluentValidation;

namespace Applicatiom.Validators
{
    public class PlayerValidator : AbstractValidator<Player>
    {
        public PlayerValidator()
        {
            RuleFor(player => player.Name)
                .NotEmpty()
                .WithMessage("O nome é obrigatório.")
                .Length(2, 150)
                .WithMessage("O nome deve possuir entre 2 e 150 caracteres");

            RuleFor(player => player.BirthdayDate)
                .NotEmpty()
                .WithMessage("A data de nascimento é obrigatória")
                .Must(BeValidAge)
                .WithMessage("O jogador deve ter entre 16 e 50 anos");

            RuleFor(player => player.ClubId)
                .NotEmpty()
                .WithMessage("O clube de jogador é obrigatório");

            RuleFor(player => player.Position)
                .IsInEnum()
                .WithMessage("A posição do jogador é inválida.");
        }

        private bool BeValidAge(DateTime date)
        {
            var age = DateTime.Today.Year - date.Year;
            if (date.Date > DateTime.Today.AddYears(-age)) age--;
            return age >= 16 && age <= 50;
        }
    }
}