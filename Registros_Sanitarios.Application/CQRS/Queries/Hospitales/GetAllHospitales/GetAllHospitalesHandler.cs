using MediatR;
using RegistrosSanitarios.Domain.Entities;
using RegistrosSanitarios.Domain.Repositories;

namespace RegistrosSanitarios.Application.CQRS.Queries.Hospitales
{
    public class GetAllHospitalesHandler : IRequestHandler<GetAllHospitalesQuery, IEnumerable<Hospital>>
    {
        private readonly IHospitalRepository _repo;

        public GetAllHospitalesHandler(IHospitalRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Hospital>> Handle(GetAllHospitalesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetHospitalesAsync();
        }
    }
}
