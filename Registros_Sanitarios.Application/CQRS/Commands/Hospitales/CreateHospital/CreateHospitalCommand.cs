using MediatR;

namespace Registros_Sanitarios.Application.CQRS.Commands.Hospitales;

public record CreateHospitalCommand(string Nombre) : IRequest<int>;
