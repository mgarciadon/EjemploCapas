namespace Domain.Entities;

public class Paciente : Usuario
{
    public List<Cita>? Citas { get; set; }
}
