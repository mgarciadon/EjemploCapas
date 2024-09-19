using Application.Interfaces;
using Contract.Mappings;
using Contract.Medico.Request;
using Contract.MedicosModel.Response;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;

namespace Application.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public void CreateMedico(CreateMedicoRequest medico)
        {
            var medicoEntity = MedicosProfile.ToMedicoEntity(medico);

            _medicoRepository.AddMedico(medicoEntity);
        }

        public List<MedicoResponse> GetAllMedico()
        {
            var medicos = _medicoRepository.GetMedicos();
            var mediosResponse = new List<MedicoResponse>();

            foreach (var medico in medicos)
            {
                var medicoResp = MedicosProfile.ToMedicoResponse(medico);

                mediosResponse.Add(medicoResp);
            }


            return mediosResponse;
        }
    }
}
