namespace Contract.Medico.Request;

public class CreateMedicoRequest
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public DateTime FechaNacimiento { get; set; }
    public string Direccion { get; set; } = string.Empty;
    public long Telefono { get; set; }
}
