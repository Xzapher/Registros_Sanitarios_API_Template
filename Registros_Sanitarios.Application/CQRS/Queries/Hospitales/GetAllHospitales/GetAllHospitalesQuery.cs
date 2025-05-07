using MediatR;
using RegistrosSanitarios.Domain.Entities;

namespace RegistrosSanitarios.Application.CQRS.Queries.Hospitales
{
    public record GetAllHospitalesQuery : IRequest<IEnumerable<Hospital>>;
}
