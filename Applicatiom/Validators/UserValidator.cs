using Domain.Entities;
using FluentValidation;

namespace Applicatiom.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("Deve informar o email.")
                .EmailAddress()
                .WithMessage("O email não é válido.");

            // Ver se devemos verificar aqui se o usuario não existe no banco...
            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("Deve informar a senha");

            RuleFor(user => user.Role)
                .NotNull()
                .WithMessage("Deve informar o tipo do usuario.");
        }
    }
}