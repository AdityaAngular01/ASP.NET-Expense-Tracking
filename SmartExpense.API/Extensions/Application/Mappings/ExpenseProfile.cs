using AutoMapper;
using SmartExpense.API.DTOs.ExpenseDTOs;
using SmartExpense.API.Models;

namespace SmartExpense.API.Application.Mappings
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            // Entity → DTO
            CreateMap<Expense, ExpenseDTO>();

            // DTO → Entity (for update)
            CreateMap<ExpenseUpdateDTO, Expense>();

            // Clone (IMPORTANT)
            CreateMap<Expense, Expense>();
        }
    }
}
