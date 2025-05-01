namespace RegistrosSanitarios.Domain.Entities;
public partial class Paciente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Edad { get; set; }

    public int HospitalId { get; set; }

    public string RazonConsulta { get; set; } = null!;

    public virtual Hospitale Hospital { get; set; } = null!;
}
