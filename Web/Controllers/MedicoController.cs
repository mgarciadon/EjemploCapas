using Application.Interfaces;
using Contract.Medico.Request;
using Contract.MedicosModel.Response;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/medicos")]
[ApiController]
public class MedicoController : ControllerBase
{
    private readonly IMedicoService _medicoService;

    public MedicoController(IMedicoService medicoService)
    {
        _medicoService = medicoService;
    }

    [HttpGet]
    public IActionResult GetAllMedico()
    {
        var response = _medicoService.GetAllMedico();

        if (response.Count is 0)
        {
            return NotFound("No se encontraron medicos");
        }

        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<MedicoResponse?> GetMedicoById([FromRoute] int id)
    {
        var response = _medicoService.GetMedicoById(id);

        if (response is null)
        {
            return NotFound("No se encontro el medico");
        }

        return Ok(response);
    }

    [HttpGet("especialidad")]
    public IActionResult GetMedicoByEspecialidad(Especialidad especialidad)
    {
        return Ok(_medicoService.GetMedicosByEspecialidad(especialidad));
    }

    [HttpPost]
    public IActionResult CreateMedico([FromBody] MedicoRequest medico)
    {
        _medicoService.CreateMedico(medico);
        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult<bool> UpdateMedico([FromRoute] int id, [FromBody] MedicoRequest medico)
    {
        return Ok(_medicoService.UpdateMedico(id, medico));
    }

    [HttpDelete("{id}")]
    public ActionResult<bool> DeleteMedico([FromRoute] int id)
    {
        return Ok(_medicoService.DeleteMedico(id));
    }
}