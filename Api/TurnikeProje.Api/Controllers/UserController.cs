using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurnikeProje.BussinesLayer.Abstract;

namespace TurnikeProje.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GeAllUser")]
        public IActionResult GetAllUser()
        {
            var users = _userService.TGetListAll();
            return Ok(users);
        }
    }
}
