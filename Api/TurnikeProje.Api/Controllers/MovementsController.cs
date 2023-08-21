using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurnikeProje.BussinesLayer.Abstract;
using TurnikeProje.EntityLayer.Dtos;
using TurnikeProje.EntityLayer.Entities;

namespace TurnikeProje.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementsController : ControllerBase
    {
        private readonly IMovementsService _movementsService;

        public MovementsController(IMovementsService movementsService)
        {
            _movementsService = movementsService;
        }

        [Authorize]
        [HttpPost("Enter")]
        public IActionResult Enter(CreateMovementsDto dto)
        {
            _movementsService.TCreateMovements(dto);
            return Ok(dto);
        }
        [HttpPost("Exit/{userId}")]
        public IActionResult Exit(int userId)
        {
            _movementsService.TCreateExitTime(userId);
            return Ok();
        }
        [HttpGet("GetAMovement/{movementId}")]
        public IActionResult Movements(int movementId)
        {
            var move = _movementsService.TGetById(movementId);
            return Ok(move);
        }
        [HttpGet("MovementsAll")]
        public IActionResult Movements()
        {
            var movements = _movementsService.TGetListAll();
            return Ok(movements);
        }
        [HttpGet("GetUserOneDayMovements/{userId}")]
        public IActionResult GetUserOneDayMovements(int userId)
        {
            var movements = _movementsService.TGetUserOneDayMovements(userId);
            return Ok(movements);
        }
    }
}
