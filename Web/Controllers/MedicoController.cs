using Application.Interfaces;
using Contract.Medico.Request;
using Domain.Entities;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;

        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        [HttpPost]
        public IActionResult CreateMedico([FromBody] CreateMedicoRequest medico)
        {
            _medicoService.CreateMedico(medico);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllMedico()
        {
            return Ok(_medicoService.GetAllMedico());
        }

        [HttpGet("ByEspecialidad")]
        public IActionResult GetMedicoByEspecialidad(Especialidad especialidad)
        {
            return Ok(_medicoService.GetMedicosByEspecialidad(especialidad));
        }
    }
}
