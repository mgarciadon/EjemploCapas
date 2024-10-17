using Domain.Enum;

namespace Domain.Entities;

public class Medico : Usuario
{
    public Especialidad Especialidad { get; set; }
    public List<Cita>? Citas { get; set; }
}
