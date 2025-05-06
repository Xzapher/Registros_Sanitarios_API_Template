using MediatR;
using Registros_Sanitarios.Application.CQRS.Commands.Hospitales;
using RegistrosSanitarios.Domain.Entities;
using RegistrosSanitarios.Domain.Repositories;

public class CreateHospitalHandler : IRequestHandler<CreateHospitalCommand, int>
{
    private readonly IHospitalRepository _repo;

    public CreateHospitalHandler(IHospitalRepository repo)
    {
        _repo = repo;
    }

    public async Task<int> Handle(CreateHospitalCommand request, CancellationToken cancellationToken)
    {
        var hospital = new Hospital { Nombre = request.Nombre };
        await _repo.AddAsync(hospital);
        return hospital.Id;
    }
}
