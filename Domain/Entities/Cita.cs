namespace Domain.Entities;

public class Cita
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Description { get; set; } = string.Empty;
    public Paciente Paciente { get; set; } = new();
    public Medico Medico { get; set; } = new();
}
