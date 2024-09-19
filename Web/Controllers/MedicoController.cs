using Application.Interfaces;
using Contract.Medico.Request;
using Contract.MedicosModel.Response;
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
    public ActionResult<List<MedicoResponse>> GetAllMedico()
    {
        var response = new List<MedicoResponse>();

        try
        {
            response = _medicoService.GetAll();

            if (response.Count is 0)
            {
                return NotFound("No existen registros de medicos");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<MedicoResponse> GetMedicoById([FromRoute] int id)
    {
        var response = new MedicoResponse();

        try
        {
            response = _medicoService.GetById(id);

            if (response is null)
            {
                return NotFound($"No existe el medico con id {id}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Ok(response);
    }

    [HttpPost]
    public IActionResult CreateMedico([FromBody] CreateMedicoRequest medico)
    {
        var response = new MedicoResponse();
        string locationUrl = string.Empty;

        try
        {
            response = _medicoService.Create(medico);

            string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            string apiAndEndpointUrl = $"api/medicos/{response.Id}";
            locationUrl = $"{baseUrl}/{apiAndEndpointUrl}";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Created(locationUrl, response);
    }
}