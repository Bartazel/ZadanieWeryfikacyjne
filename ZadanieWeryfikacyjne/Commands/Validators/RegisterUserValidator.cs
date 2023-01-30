using FluentValidation;

namespace ZadanieWeryfikacyjne.Commands.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUser>
    {
        public RegisterUserValidator()
        {
            RuleFor(model => model.Password)
                .NotEmpty()
                .NotNull();
        }
    }
}
