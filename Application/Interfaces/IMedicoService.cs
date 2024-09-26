using Contract.Medico.Request;
using Contract.MedicosModel.Response;

namespace Application.Interfaces;

public interface IMedicoService
{
    MedicoResponse Create(CreateMedicoRequest medico);
    List<MedicoResponse> GetAll();
    MedicoResponse? GetById(int id);
}