using System;
using System.Collections.Generic;

namespace Registros_Sanitarios_API.Models.Entities;

public partial class Hospitale
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
