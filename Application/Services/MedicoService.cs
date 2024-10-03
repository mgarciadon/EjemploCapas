using Application.Interfaces;
using Contract.Mappings;
using Contract.Medico.Request;
using Contract.MedicosModel.Response;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;

namespace Application.Services;

public class MedicoService : IMedicoService
{
    private readonly IMedicoRepository _medicoRepository;

    public MedicoService(IMedicoRepository medicoRepository)
    {
        _medicoRepository = medicoRepository;
    }

    public List<MedicoResponse> GetAllMedico()
    {
        try
        {
            var medicos = _medicoRepository.GetMedicos();
            var nombre = medicos[2].Nombre;

            return MedicosProfile.ToMedicoResponse(medicos);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error en la clase {nameof(MedicoService)} - STACKTRACE: {e.StackTrace} - MESSAGE {e.Message}");
            throw e;
        }
    }

    public MedicoResponse? GetMedicoById(int id)
    {
        var medico = _medicoRepository.GetMedicoById(id);

        if (medico != null)
        {
            return MedicosProfile.ToMedicoResponse(medico);
        }

        return null;
    }

    public List<MedicoResponse> GetMedicosByEspecialidad(Especialidad especialidad)
    {
        var medicos = _medicoRepository.GetMedicosByEspecialidad(especialidad);

        return MedicosProfile.ToMedicoResponse(medicos);
    }

    public void CreateMedico(MedicoRequest medico)
    {
        var medicoEntity = MedicosProfile.ToMedicoEntity(medico);

        _medicoRepository.AddMedico(medicoEntity);
    }

    public void CreateCita(MedicoRequest medico)
    {
        var medicoEntity = MedicosProfile.ToMedicoEntity(medico);

        _medicoRepository.AddMedico(medicoEntity);
    }


    public bool UpdateMedico(int id, MedicoRequest medico)
    {
        var medicoEntity = _medicoRepository.GetMedicoById(id);

        if (medicoEntity != null)
        {
            MedicosProfile.ToMedicoEntityUpdate(medicoEntity, medico);

            _medicoRepository.UpdateMedico(medicoEntity);

            return true;
        }

        return false;
    }

    public bool DeleteMedico(int id)
    {
        var medico = _medicoRepository.GetMedicoById(id);

        if (medico != null)
        {
            _medicoRepository.DeleteMedico(medico);

            return true;
        }

        return false;
    }
}
