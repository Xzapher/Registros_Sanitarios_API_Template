using MediatR;
using RegistrosSanitarios.Domain.Repositories;

namespace RegistrosSanitarios.Application.CQRS.Commands.Hospitales
{
    public class UpdateHospitalHandler : IRequestHandler<UpdateHospitalCommand, bool>
    {
        private readonly IHospitalRepository _repo;

        public UpdateHospitalHandler(IHospitalRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateHospitalCommand request, CancellationToken cancellationToken)
        {
            var hospital = await _repo.GetHospitalByIdAsync(request.Id);
            if (hospital == null)
                return false;

            hospital.Nombre = request.Nombre;

            await _repo.EditHospitalAsync(hospital);
            return true;
        }
    }
}
