﻿using Application.Interfaces;
using Domain.Entities;
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
        public IActionResult CreateMedico([FromBody]Medico medico)
        {
            _medicoService.CreateMedico(medico);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllMedico()
        {
            return Ok(_medicoService.GetAllMedico());
        }

    }
}
