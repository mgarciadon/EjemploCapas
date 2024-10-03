using Contract.Medico.Request;
using Contract.MedicosModel.Response;
using Domain.Enum;

namespace Application.Interfaces;

public interface IMedicoService
{
    List<MedicoResponse> GetAllMedico();
    MedicoResponse? GetMedicoById(int id);
    List<MedicoResponse> GetMedicosByEspecialidad(Especialidad especialidad);
    void CreateMedico(MedicoRequest medico);
    bool UpdateMedico(int id, MedicoRequest medico);
    bool DeleteMedico(int id);
}
