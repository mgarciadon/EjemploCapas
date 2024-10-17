using Domain.Entities;
using Domain.Enum;

namespace Domain.Interfaces;

public interface IMedicoRepository
{
    List<Medico> GetMedicos();
    Medico? GetMedicoById(int id);
    List<Medico> GetMedicosByEspecialidad(Especialidad especialidad);
    void AddMedico(Medico entity);
    void UpdateMedico(Medico entity);
    void DeleteMedico(Medico entity);
}
