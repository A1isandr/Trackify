using FluentValidation;
using Trackify.Models;

namespace Trackify.Validation;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Username)
            .NotEmpty();
        
        RuleFor(user => user.HashedPassword)
            .NotEmpty();

        RuleForEach(user => user.Boards)
            .SetValidator(new BoardValidator());
    }
}