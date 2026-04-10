using AutoMapper;
using SmartExpense.API.DTOs;
using SmartExpense.API.DTOs.ExpenseDTOs;
using SmartExpense.API.DTOs.Responses;
using SmartExpense.API.Models;
using SmartExpense.API.Repositories;

namespace SmartExpense.API.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repo;

        private readonly IMapper _mapper;

        private readonly ICurrentUserService _currentUser;

        public ExpenseService(IExpenseRepository repo, IMapper mapper, ICurrentUserService currentUser)
        {
            _repo = repo;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<IEnumerable<object>> GetAllExpenses()
        {
            var data = await _repo.GetAllAsync();
            return data.Select(e => new
            {
                e.Id,
                e.Title,
                e.Amount
            });
        }

        public async Task<PaginationDataDTO<Expense>> GetAllExpenses(QueryParams queryParams)
        {
            return await _repo.GetAllAsync(queryParams);
        }

        public async Task<int> AddExpense(ExpenseDTO dto)
        {
            var expense = new Expense
            {
                Title = dto.Title,
                Amount = dto.Amount,
                UserId = _currentUser.UserId,
            };

            await _repo.AddAsync(expense);

            return expense.Id;
        }

        public async Task<Expense?> GetExpenseById(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<bool> DeleteExpense(int id)
        {
            return await _repo.DeleteByIdAsync(id);
        }

        public async Task<(Expense?, Expense?)> UpdateExpense(int id, ExpenseUpdateDTO dto)
        {
            var expense = await _repo.GetByIdAsync(id);
            
            var oldExpense = _mapper.Map<Expense>(expense);

            if (expense == null)
                return (null, null);

            if (!string.IsNullOrWhiteSpace(dto.Title))
                expense.Title = dto.Title;

            if (dto.Amount.HasValue)
                expense.Amount = dto.Amount.Value;

            if (dto.CategoryId.HasValue)
                expense.CategoryId = dto.CategoryId;

            if (dto.GroupId.HasValue)
                expense.GroupId = dto.GroupId;

            return (oldExpense, await _repo.UpdateAsync(expense));
        }
    }
}