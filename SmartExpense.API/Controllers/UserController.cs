using Microsoft.AspNetCore.Mvc;
using SmartExpense.API.DTOs;
using SmartExpense.API.DTOs.Responses;
using SmartExpense.API.DTOs.UserDTOs;
using SmartExpense.API.Services;

namespace SmartExpense.API.Controllers
{
    public sealed class UserController : BaseController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllUsers();
            return Ok(SuccessResponseHelper.Success(
                                        data: data, 
                                        message: "Users retrieved successfully", 
                                        statusCode: StatusCodes.Status200OK
                                    ));
        }

        [HttpGet("paginated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaginated([FromQuery] QueryParams queryParams)
        {
            var (Data, Metadata) = await _service.GetAllUsers(queryParams);
            return Ok(PaginationResponseHelper.Success(data: Data, metadata: Metadata));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _service.GetUserById(id);
            if (user == null)
                return NotFound(new ErrorResponse
                {
                    Message = $"User not found",
                    StatusCode = StatusCodes.Status404NotFound,
                    Details = $"No user with id {id} exists"
                });
            
            return Ok(SuccessResponseHelper.Success(
                                        data: user, 
                                        message: "User retrieved successfully", 
                                        statusCode: StatusCodes.Status200OK
                                    ));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Create(UserDTO dto)
        {
            var userId = await _service.AddUser(dto);
            return CreatedAtAction(nameof(Get), new { id = userId }, SuccessResponseHelper.Success(
                                        data: new { Id = userId }, 
                                        message: "User created successfully", 
                                        statusCode: StatusCodes.Status201Created
                                    ));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Update(int id, UserUpdateDTO dto)
        {
            var (oldUserData, updatedUser) = await _service.UpdateUser(id, dto);

            if (updatedUser == null)
                return NotFound(new ErrorResponse
                {
                    Message = "User not found",
                    StatusCode = StatusCodes.Status404NotFound,
                    Details = $"No user with id {id} exists"
                });

            return Ok(new UserUpdateResponseDTO
            {
                OldUserData = oldUserData,
                UpdatedTo = updatedUser,
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteUser(id);

            if (!deleted)
                return NotFound(new ErrorResponse
                {
                    Message = "User not found",
                    StatusCode = StatusCodes.Status404NotFound,
                    Details = $"No user with id {id} exists"
                });

            return NoContent();
        }

    }
}