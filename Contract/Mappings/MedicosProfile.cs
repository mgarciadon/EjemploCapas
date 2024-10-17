using Contract.Medico.Request;
using Contract.MedicosModel.Response;
using Domain.Enum;
using DomainEntity = Domain.Entities;
namespace Contract.Mappings;

public static class MedicosProfile
{
    public static DomainEntity.Medico ToMedicoEntity(MedicoRequest request)
    {
        return new DomainEntity.Medico()
        {
            Nombre = request.Nombre,
            Apellido = request.Apellido,
            Direccion = request.Direccion,
            FechaNacimiento = request.FechaNacimiento,
            Telefono = request.Telefono,
            Especialidad = (Especialidad)request.Especialidad,
            Email = request.Email,
            Contrasenia = request.Contrasenia
        };
    }

    public static void ToMedicoEntityUpdate(DomainEntity.Medico medico, MedicoRequest request)
    {
        medico.Nombre = request.Nombre;
        medico.Apellido = request.Apellido;
        medico.Direccion = request.Direccion;
        medico.FechaNacimiento = request.FechaNacimiento;
        medico.Telefono = request.Telefono;
        medico.Especialidad = (Especialidad)request.Especialidad;
    }

    public static MedicoResponse ToMedicoResponse(DomainEntity.Medico medico)
    {
        return new MedicoResponse()
        {
            Id = medico.Id,
            Nombre = medico.Nombre,
            Apellido = medico.Apellido,
            FechaNacimiento = medico.FechaNacimiento,
            Especialidad = medico.Especialidad,
            Email = medico.Email
        };
    }

    public static List<MedicoResponse> ToMedicoResponse(List<DomainEntity.Medico> medico)
    {
        return medico.Select(m => new MedicoResponse
        {
            Id = m.Id,
            Nombre = m.Nombre,
            Apellido = m.Apellido,
            FechaNacimiento = m.FechaNacimiento,
            Especialidad = m.Especialidad,
            Email = m.Email
        }).ToList();
    }
}
