using Application.Interfaces;
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
            var oMedico = new Medico();

            oMedico.Id = medico.Id;
            oMedico.Nombre = medico.Nombre;
            oMedico.Apellido = medico.Apellido;
            oMedico.FechaNacimiento = medico.FechaNacimiento;
            oMedico.Direccion = medico.Direccion;
            oMedico.Telefono = medico.Telefono;
            oMedico.Especialidad = Especialidad.Traumatologo;

            _medicoRepository.AddMedico(oMedico);
        }

        public List<MedicoResponse> GetAllMedico()
        {
            var medicos = _medicoRepository.GetMedicos();
            var mediosResponse = new List<MedicoResponse>();

            foreach (var medico in medicos)
            {
                var medicoResp = new MedicoResponse();
                medicoResp.Nombre = medico.Nombre;
                medicoResp.Apellido = medico.Apellido;
                medicoResp.FechaNacimiento = medico.FechaNacimiento;

                mediosResponse.Add(medicoResp);
            }


            return mediosResponse;
        }
    }
}
