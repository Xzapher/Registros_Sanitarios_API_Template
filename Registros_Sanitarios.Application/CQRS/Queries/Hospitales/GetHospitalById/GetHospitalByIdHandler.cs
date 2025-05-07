using MediatR;
using RegistrosSanitarios.Domain.Entities;
using RegistrosSanitarios.Domain.Repositories;

namespace RegistrosSanitarios.Application.CQRS.Queries.Hospitales
{
    public class GetHospitalByIdHandler : IRequestHandler<GetHospitalByIdQuery, Hospital?>
    {
        private readonly IHospitalRepository _repo;

        public GetHospitalByIdHandler(IHospitalRepository repo)
        {
            _repo = repo;
        }

        public async Task<Hospital?> Handle(GetHospitalByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetHospitalByIdAsync(request.Id);
        }
    }
}
