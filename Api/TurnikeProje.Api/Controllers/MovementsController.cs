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
        private readonly IInOutTimeService _inOutTimeService;

        public MovementsController(IInOutTimeService inOutTimeService)
        {
            _inOutTimeService = inOutTimeService;
        }

        [HttpPost]
        public IActionResult Enter(CreateMovementsDto dto)
        {
            _inOutTimeService.TCreateMovements(dto);
            return Ok(dto);
        }
        [HttpGet("Exitadd/{id}")]
        public IActionResult Exit(int id)
        {
            _inOutTimeService.TAddExitTime(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult Movements(int id)
        {
            var move = _inOutTimeService.TGetById(id);
            return Ok(move);
        }
    }
}
