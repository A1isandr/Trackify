using FluentValidation;
using Trackify.Models;

namespace Trackify.Validation;

public class BoardValidator : AbstractValidator<Board>
{
    public BoardValidator()
    {
        RuleFor(board => board.Name)
            .NotEmpty();
        
        RuleFor(board => board.Owner)
            .NotNull();
        
        RuleForEach(board => board.Categories)
            .SetValidator(new CategoryValidator());
    }
}