using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Data;

public class MedicoRepository : IMedicoRepository
{
    private readonly ExampleDbContext _dbContext;

    public MedicoRepository(ExampleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(Medico entity)
    {
        _dbContext.Medicos.Add(entity);
        _dbContext.SaveChanges();
    }

    public List<Medico> GetAll()
    {
        return _dbContext.Medicos.ToList();
    }

    public Medico? GetById(int id)
    {
        return _dbContext.Medicos.FirstOrDefault(m => m.Id.Equals(id));
    }
}
