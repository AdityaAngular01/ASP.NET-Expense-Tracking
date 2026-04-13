using SmartExpense.API.DTOs.CategoryDTOs;

namespace SmartExpense.API.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllAsync();

        Task<CategoryDTO?> GetByIdAsync(int id);

        Task<CategoryDTO> CreateAsync(CreateCategoryDTO dto);

        Task<CategoryDTO?> UpdateAsync(int id, UpdateCategoryDTO dto);

        Task<bool> DeleteAsync(int id);
    }
}