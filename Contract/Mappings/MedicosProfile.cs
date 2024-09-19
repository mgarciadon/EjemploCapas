using Contract.Medico.Request;
using Contract.MedicosModel.Response;

namespace Contract.Mappings;

public static class MedicosProfile
{
    public static Domain.Entities.Medico ToMedicoEntity(CreateMedicoRequest request)
    {
        return new Domain.Entities.Medico()
        {
            Nombre = request.Nombre,
            Apellido = request.Apellido,
            Direccion = request.Direccion,
            FechaNacimiento = request.FechaNacimiento,
            Telefono = request.Telefono,
            Especialidad = Domain.Enum.Especialidad.Pediatra
        };
    }

    public static MedicoResponse ToMedicoResponse(Domain.Entities.Medico medico)
    {
        return new MedicoResponse()
        {
            Nombre = medico.Nombre,
            Apellido = medico.Apellido,
            FechaNacimiento = medico.FechaNacimiento
        };
    }
}
