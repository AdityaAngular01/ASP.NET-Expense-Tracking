using FluentValidation;
using SmartExpense.API.DTOs.CategoryDTOs;

namespace SmartExpense.API.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required")
                .MinimumLength(3).WithMessage("Category name must be at least 3 characters")
                .MaximumLength(50).WithMessage("Category name must not exceed 50 characters");
        }
    }

    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3)
                .When(x => x.Name != null)
                .WithMessage("Category name must be at least 3 characters")
                
                .MaximumLength(50)
                .When(x => x.Name != null)
                .WithMessage("Category name must not exceed 50 characters");
        }
    }
}