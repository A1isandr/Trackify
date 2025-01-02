using FluentValidation;
using Trackify.Models;

namespace Trackify.Validation;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(category => category.Name)
            .NotEmpty();
        
        RuleFor(category => category.Board)
            .NotNull();
        
        RuleForEach(category => category.Cards)
            .SetValidator(new CardValidator());
    }
}