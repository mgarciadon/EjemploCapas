using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMedicoRepository
    {
        void AddMedico(Medico entity);
        List<Medico> GetMedicos();
        List<Medico> GetMedicosByEspecialidad(Especialidad especialidad);
    }
}
