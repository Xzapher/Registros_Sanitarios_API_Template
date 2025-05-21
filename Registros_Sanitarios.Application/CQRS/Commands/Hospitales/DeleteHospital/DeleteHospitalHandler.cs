using MediatR;
using RegistrosSanitarios.Domain.Repositories;

namespace RegistrosSanitarios.Application.CQRS.Commands.Hospitales
{
    public class DeleteHospitalHandler : IRequestHandler<DeleteHospitalCommand, bool>
    {
        private readonly IHospitalRepository _repo;

        public DeleteHospitalHandler(IHospitalRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(DeleteHospitalCommand request, CancellationToken cancellationToken)
        {
            var hospital = await _repo.GetByIdWithPacientesAsync(request.Id, cancellationToken);
            if (hospital == null || hospital.Pacientes.Any())
                return false;

            await _repo.DeleteHospitalAsync(hospital, cancellationToken); // pasa la entidad directamente
            return true;
        }

    }
}
