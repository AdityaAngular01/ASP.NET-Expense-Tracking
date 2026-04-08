using Microsoft.AspNetCore.Mvc;
using SmartExpense.API.DTOs;
using SmartExpense.API.DTOs.Responses;
using SmartExpense.API.Models;
using SmartExpense.API.Services;

namespace SmartExpense.API.Controllers
{
    public class ExpenseController : BaseController
    {
        private readonly IExpenseService _service;

        public ExpenseController(IExpenseService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllExpenses();
            return Ok(SuccessResponseHelper.Success(
                                        data: data, 
                                        message: "Expenses retrieved successfully", 
                                        statusCode: StatusCodes.Status200OK
                                    ));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Get(int id)
        {
            var expense = await _service.GetExpenseById(id);

            if (expense == null)
                return NotFound(new ErrorResponse
                {
                    Message = $"Expense not found",
                    StatusCode = StatusCodes.Status404NotFound,
                    Details = $"No expense with id {id} exists"
                });

            return Ok(SuccessResponseHelper.Success<Expense>(
                                                    data: expense, 
                                                    message: "Expense retrieved successfully", 
                                                    statusCode: StatusCodes.Status200OK
                                                ));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ExpenseDto dto)
        {
            var expenseId = await _service.AddExpense(dto);

            return CreatedAtAction(
                                nameof(Get), 
                                new { id = expenseId }, 
                                SuccessResponseHelper.Success(
                                    data: new { Id = expenseId }, 
                                    message: "Expense created successfully", 
                                    statusCode: StatusCodes.Status201Created
                                ));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType((StatusCodes.Status404NotFound))]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteExpense(id);

            if (!deleted)
                return NotFound(new ErrorResponse
                {
                    Message = $"Expense not found",
                    StatusCode = StatusCodes.Status404NotFound,
                    Details = $"No expense with id {id} exists"
                });

            return NoContent();
        }
    }
}