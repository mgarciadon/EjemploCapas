using Contract.Medico.Request;
using Contract.MedicosModel.Response;
using Domain.Entities;
using Domain.Enum;

namespace Application.Interfaces
{
    public interface IMedicoService
    {
        void CreateMedico(CreateMedicoRequest medico);
        List<MedicoResponse> GetAllMedico();
        List<MedicoResponse> GetMedicosByEspecialidad(Especialidad especialidad);
    }
}
