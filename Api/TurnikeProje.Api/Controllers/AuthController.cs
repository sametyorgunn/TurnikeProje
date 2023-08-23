using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurnikeProje.Api.Jwt;

namespace TurnikeProje.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Login()
        {
            return Created("", new BuildToken().CreateToken());
        }
       
    }
}
