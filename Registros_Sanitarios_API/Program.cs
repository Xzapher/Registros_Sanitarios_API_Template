using Microsoft.EntityFrameworkCore;
using Registros_Sanitarios_API.Data;
using Registros_Sanitarios_API.Repositories;
using Registros_Sanitarios_API.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Add Entity Framework Core and SQL Server
        builder.Services.AddDbContext<RegistrosSanitariosContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Add Dependency Injection for Repositories and Services
        builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
        builder.Services.AddScoped<IPacienteService, PacienteService>();

        builder.Services.AddScoped<IHospitaleRepository, HospitaleRepository>();
        builder.Services.AddScoped<IHospitaleService, HospitaleService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}