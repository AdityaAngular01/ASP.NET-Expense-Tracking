using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartExpense.API.DTOs.Responses;
using SmartExpense.API.DTOs.AuthDTOs;
using SmartExpense.API.Services;
using SmartExpense.API.Services.Auth;

namespace SmartExpense.API.Controllers.Auth
{
    public sealed class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Register([FromBody] AuthRegisterDTO dto)
        {

            var userId = await _authService.Register(dto);
            return Ok(SuccessResponseHelper.Success(
                                        data: new { Id = userId }, 
                                        message: "User created successfully", 
                                        statusCode: StatusCodes.Status201Created
                                    ));
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Login([FromBody] AuthLoginDTO dto)
        {
            var loggedUser = await _authService.Login(dto);
            if (loggedUser == null)
                return BadRequest(new ErrorResponse { Message = "Invalid email or password", StatusCode = StatusCodes.Status400BadRequest });
            
            return Ok(SuccessResponseHelper.Success(
                                        data: loggedUser, 
                                        message: "User authenticated successfully", 
                                        statusCode: StatusCodes.Status200OK
                                    ));
        }
    }
}