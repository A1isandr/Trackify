using FluentValidation;
using Trackify.Models;

namespace Trackify.Validation;

public class CardValidator : AbstractValidator<Card>
{
    public CardValidator()
    {
        RuleFor(card => card.Title)
            .NotEmpty();

        RuleFor(card => card.Description)
            .Length(0, 500);
        
        RuleFor(card => card.Category)
            .NotNull();
    }
}