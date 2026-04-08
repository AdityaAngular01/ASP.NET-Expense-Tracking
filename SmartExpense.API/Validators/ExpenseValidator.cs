using FluentValidation;
using SmartExpense.API.DTOs.ExpenseDTOs;

namespace SmartExpense.API.Validators
{
    public class ExpenseValidator : AbstractValidator<ExpenseDTO>
    {
        public ExpenseValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .Length(3, 100).WithMessage("Title must be between 3 and 100 characters");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0)
                .When(x => x.CategoryId.HasValue)
                .WithMessage("Invalid Category");

            RuleFor(x => x.GroupId)
                .GreaterThan(0)
                .When(x => x.GroupId.HasValue)
                .WithMessage("Invalid Group");
        }
    }
}