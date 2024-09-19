using Domain.Entities;

namespace Domain.Interfaces;

public interface IMedicoRepository
{
    void Create(Medico entity);
    List<Medico> GetAll();
    Medico? GetById(int id);
}
