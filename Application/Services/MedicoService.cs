using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;
        public MedicoService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public void CreateMedico(Medico medico)
        {
            _medicoRepository.AddMedico(medico);
        }

        public List<Medico> GetAllMedico()
        {
            return _medicoRepository.GetMedicos();
        }
    }
}
