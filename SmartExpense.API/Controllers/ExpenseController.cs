using Microsoft.AspNetCore.Mvc;
using SmartExpense.API.DTOs;
using SmartExpense.API.Services;
using Microsoft.AspNetCore.Http;

namespace SmartExpense.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _service;

        public ExpenseController(IExpenseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetAllExpenses();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var expense = await _service.GetExpenseById(id);

            if (expense == null)
                return NotFound();

            return Ok(expense);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ExpenseDto dto)
        {
            var expenseId = await _service.AddExpense(dto);

            return CreatedAtAction(nameof(GetById), new { id = expenseId }, new
            CreateExpenseResponse{
                Message = "Expense created successfully",
                Id = expenseId
            });
        }
    }
}