using ECommerce.lib.DTos.Identity;
using FluentValidation;

namespace ECommerce.Validations.Identity
{
    public class CreateUserValidator:AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Fullname is required.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.").MinimumLength(8).WithMessage("at least 8 characters").Matches(@"[A-Z]")
                .WithMessage("Password must contain at least one uppercase letter.").
                Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.").
                Matches(@"[0-9]").WithMessage("Password must contain at least one number.").
                Matches(@"[\W]").WithMessage("Password must contain at least one special character.");
                RuleFor(x => x.confirmPassword).NotEmpty().WithMessage("Confirm Password is required.").Equal(x => x.Password).WithMessage("Passwords do not match.");
        }

    }
}
