using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Medico : Usuario
    {
        public Especialidad Especialidad { get; set; }
        public List<Cita> Citas { get; set; }
    }
}
