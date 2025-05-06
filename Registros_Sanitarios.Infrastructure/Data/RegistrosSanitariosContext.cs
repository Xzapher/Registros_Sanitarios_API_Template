using Microsoft.EntityFrameworkCore;
using RegistrosSanitarios.Domain.Entities;

namespace RegistrosSanitarios.Infrastructure.Data;

public partial class RegistrosSanitariosContext : DbContext
{
    public RegistrosSanitariosContext(DbContextOptions<RegistrosSanitariosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hospital> Hospitales { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hospital__3214EC075C53FD00");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paciente__3214EC075CC2D4A5");

            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.RazonConsulta).HasMaxLength(50);

            entity.HasOne(d => d.Hospital).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.HospitalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pacientes__Hospi__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
