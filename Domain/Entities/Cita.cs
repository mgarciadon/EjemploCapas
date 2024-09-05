﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cita
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Description { get; set; } = string.Empty;
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
    }
}
