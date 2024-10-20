﻿using Domain.Enum;

namespace Contract.MedicosModel.Response;

public class MedicoResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public DateTime FechaNacimiento { get; set; }
    public Especialidad Especialidad { get; set; }
    public string Email { get; set; } = string.Empty;
}
