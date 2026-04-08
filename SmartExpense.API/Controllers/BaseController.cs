using Microsoft.AspNetCore.Mvc;

namespace SmartExpense.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
    }
}