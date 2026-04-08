using FluentValidation;
using SmartExpense.API.DTOs.ExpenseDTOs;

public class ExpenseUpdateValidator : AbstractValidator<ExpenseUpdateDTO>
{
    public ExpenseUpdateValidator()
    {
        RuleFor(x => x.Title)
            .Length(3, 100)
            .When(x => x.Title != null);

        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .When(x => x.Amount.HasValue);

        RuleFor(x => x.CategoryId)
            .GreaterThan(0)
            .When(x => x.CategoryId.HasValue);

        RuleFor(x => x.GroupId)
            .GreaterThan(0)
            .When(x => x.GroupId.HasValue);
    }
}