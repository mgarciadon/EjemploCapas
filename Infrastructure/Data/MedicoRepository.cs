using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class MedicoRepository : IMedicoRepository
    {
        public static List<Medico> Medicos = new List<Medico>();

        public void AddMedico(Medico entity)
        {
            Medicos.Add(entity);
        }

        public List<Medico> GetMedicos()
        {
            return Medicos;
        }
    }
}
