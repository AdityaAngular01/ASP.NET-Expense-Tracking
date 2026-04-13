using FluentValidation;
using SmartExpense.API.DTOs.GroupDTOs;

namespace SmartExpense.API.Validators
{
    public class CreateGroupDTOValidator : AbstractValidator<CreateGroupDTO>
    {
        public CreateGroupDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Group name is required")
                .MinimumLength(3).WithMessage("Group name must be at least 3 characters")
                .MaximumLength(100).WithMessage("Group name must not exceed 100 characters");

            RuleFor(x => x.MemberUserIds)
                .NotNull().WithMessage("Members list cannot be null");

            RuleFor(x => x.MemberUserIds)
                .Must(list => list == null || list.Distinct().Count() == list.Count)
                .WithMessage("Duplicate users are not allowed");

            RuleForEach(x => x.MemberUserIds)
                .GreaterThan(0).WithMessage("Invalid user ID");
        }
    }


    public class UpdateGroupDTOValidator : AbstractValidator<UpdateGroupDTO>
    {
        public UpdateGroupDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Group name cannot be empty")
                .MinimumLength(3).WithMessage("Group name must be at least 3 characters")
                .MaximumLength(100).WithMessage("Group name must not exceed 100 characters")
                .When(x => x.Name != null); // ✅ only validate if provided
        }
    }
}