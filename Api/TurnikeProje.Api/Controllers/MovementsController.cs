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
        private readonly MovementsService _movementsService;

        public MovementsController(MovementsService movementsService)
        {
            _movementsService = movementsService;
        }

        [HttpPost("Enter")]
        public IActionResult Enter(CreateMovementsDto dto)
        {
            _movementsService.TCreateMovements(dto);
            return Ok(dto);
        }
        [HttpGet("Exit/{userId}")]
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
    }
}
