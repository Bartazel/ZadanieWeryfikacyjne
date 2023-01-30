using FluentValidation;

namespace ZadanieWeryfikacyjne.Commands.Validators
{
    public class AddCategoryValidator : AbstractValidator<AddCategory>
    {
        public AddCategoryValidator() 
        {
            RuleFor(model => model.Name).NotNull().Length(3, 100);
        }
    }
}
