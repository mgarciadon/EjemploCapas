using Contract.Medico.Request;
using Contract.MedicosModel.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMedicoService
    {
        void CreateMedico(CreateMedicoRequest medico);
        List<MedicoResponse> GetAllMedico();
    }
}
