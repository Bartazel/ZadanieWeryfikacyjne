using FluentValidation;

namespace ZadanieWeryfikacyjne.Commands.Validators
{
    public class AddItemValidator : AbstractValidator<AddItem>
    {
        public AddItemValidator()
        {
            RuleFor(model => model.Name).NotNull().Length(3, 100);
            RuleFor(model => model.Price).NotNull().GreaterThan(0);
        }
    }
}
