using MediatR;
using RegistrosSanitarios.Domain.Entities;

namespace RegistrosSanitarios.Application.CQRS.Queries.Hospitales
{
    public record GetHospitalByIdQuery(int Id) : IRequest<Hospital?>;
}
