using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Paciente : Usuario
    {
        public List<Cita> Citas { get; set; }
    }
}
