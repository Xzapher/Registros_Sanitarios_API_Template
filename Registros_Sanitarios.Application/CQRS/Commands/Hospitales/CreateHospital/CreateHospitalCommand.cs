﻿using MediatR;

namespace RegistrosSanitarios.Application.CQRS.Commands.Hospitales
{
    public record CreateHospitalCommand(string Nombre) : IRequest<int>;
}
