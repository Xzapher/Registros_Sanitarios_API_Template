using MediatR;

namespace RegistrosSanitarios.Application.CQRS.Commands.Hospitales
{
    public record UpdateHospitalCommand(int Id, string Nombre) : IRequest<bool>;
}
