using FluentValidation;
using SmartExpense.API.DTOs.AuthDTOs;

namespace SmartExpense.API.Validators
{
    public class AuthValidations
    {
        public const string EmailRegex =
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        public const string PasswordRegex =
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
    }

    public class RegisterValidator : AbstractValidator<AuthRegisterDTO>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .Matches(AuthValidations.EmailRegex).WithMessage("Invalid email format");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .Matches(AuthValidations.PasswordRegex).WithMessage(
                    "Password must be at least 8 characters long and include uppercase, lowercase, number, and special character");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm Password is required")
                .Equal(x => x.Password).WithMessage("Passwords do not match");
        }
    }

    public class LoginValidator : AbstractValidator<AuthLoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .Matches(AuthValidations.EmailRegex).WithMessage("Invalid email format");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required");
        }
    }
}