using MediatR;

namespace RegistrosSanitarios.Application.CQRS.Commands.Hospitales
{
    public record DeleteHospitalCommand(int Id) : IRequest<bool>;
}
