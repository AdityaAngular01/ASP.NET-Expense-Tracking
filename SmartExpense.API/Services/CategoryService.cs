using AutoMapper;
using SmartExpense.API.DTOs;
using SmartExpense.API.DTOs.CategoryDTOs;
using SmartExpense.API.Models;
using SmartExpense.API.Repositories;

namespace SmartExpense.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO?> GetByIdAsync(int id)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null) return null;

            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> CreateAsync(CreateCategoryDTO dto)
        {
            var category = _mapper.Map<Category>(dto);

            await _repo.AddAsync(category);

            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO?> UpdateAsync(int id, UpdateCategoryDTO dto)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null) return null;

            _mapper.Map(dto, category);

            await _repo.UpdateAsync(category);

            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null) return false;

            await _repo.DeleteAsync(category);

            return true;
        }
    }
}