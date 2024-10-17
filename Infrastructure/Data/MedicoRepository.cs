using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Data;

public class MedicoRepository : IMedicoRepository
{
    private readonly ExampleDbContext _context;

    public MedicoRepository(ExampleDbContext context)
    {
        _context = context;
    }

    public List<Medico> GetMedicos()
    {
        return _context.Medicos.ToList();
    }

    public Medico? GetMedicoById(int id)
    {
        return _context.Medicos.FirstOrDefault(x => x.Id.Equals(id));
    }

    public List<Medico> GetMedicosByEspecialidad(Especialidad especialidad)
    {
        return _context.Medicos.Where(medico => medico.Especialidad == especialidad).ToList();
    }

    public void AddMedico(Medico entity)
    {
        _context.Medicos.Add(entity);
        _context.SaveChanges();
    }

    public void UpdateMedico(Medico entity)
    {
        _context.Medicos.Update(entity);
        _context.SaveChanges();
    }

    public void DeleteMedico(Medico medico)
    {
        _context.Medicos.Remove(medico);
        _context.SaveChanges();
    }
}
