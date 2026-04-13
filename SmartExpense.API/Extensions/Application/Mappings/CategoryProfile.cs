using AutoMapper;
using SmartExpense.API.Models;
using SmartExpense.API.DTOs.CategoryDTOs;

namespace SmartExpense.API.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            // Entity → DTO
            CreateMap<Category, CategoryDTO>();

            // Create DTO → Entity
            CreateMap<CreateCategoryDTO, Category>();

            // Update DTO → Entity (VERY IMPORTANT 🔥)
            CreateMap<UpdateCategoryDTO, Category>()
                .ForAllMembers(opts => opts.Condition(
                    (src, dest, srcMember) => srcMember != null
                ));
        }
    }
}