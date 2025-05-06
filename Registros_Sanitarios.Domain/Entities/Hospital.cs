namespace RegistrosSanitarios.Domain.Entities;

public partial class Hospital
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
