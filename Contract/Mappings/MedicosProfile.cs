using Contract.Medico.Request;
using Contract.MedicosModel.Response;
using Domain.Enum;

namespace Contract.Mappings;

public static class MedicosProfile
{
    public static Domain.Entities.Medico ToMedicoEntity(CreateMedicoRequest request)
    {
        return new Domain.Entities.Medico
        {
            Nombre = request.Nombre,
            Apellido = request.Apellido,
            Direccion = request.Direccion,
            FechaNacimiento = request.FechaNacimiento,
            Telefono = request.Telefono,
            Especialidad = Especialidad.Traumatologo
        };
    }

    public static MedicoResponse ToMedicoResponse(Domain.Entities.Medico entity)
    {
        return new MedicoResponse
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Apellido = entity.Apellido,
            FechaNacimiento = entity.FechaNacimiento
        };
    }
}
