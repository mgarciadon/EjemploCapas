using Application.Interfaces;
using Contract.Mappings;
using Contract.Medico.Request;
using Contract.MedicosModel.Response;
using Domain.Interfaces;

namespace Application.Services;

public class MedicoService : IMedicoService
{
    private readonly IMedicoRepository _medicoRepository;

    public MedicoService(IMedicoRepository medicoRepository)
    {
        _medicoRepository = medicoRepository;
    }

    public MedicoResponse Create(CreateMedicoRequest medico)
    {
        var oMedico = MedicosProfile.ToMedicoEntity(medico);

        _medicoRepository.Create(oMedico);

        return MedicosProfile.ToMedicoResponse(oMedico);
    }

    public List<MedicoResponse> GetAll()
    {
        var medicos = _medicoRepository.GetAll();
        var mediosResponse = new List<MedicoResponse>();

        foreach (var medico in medicos)
        {
            var medicoResp = MedicosProfile.ToMedicoResponse(medico);

            mediosResponse.Add(medicoResp);
        }

        return mediosResponse;
    }

    public MedicoResponse? GetById(int id)
    {
        var medico = _medicoRepository.GetById(id);

        if (medico is null)
        {
            return null;
        }

        return MedicosProfile.ToMedicoResponse(medico);
    }
}
