using log4net;
using Microsoft.EntityFrameworkCore;
using RegistrosSanitarios.API.Log4Net;
using RegistrosSanitarios.Application.CQRS.Commands.Hospitales;
using RegistrosSanitarios.Domain.Repositories;
using RegistrosSanitarios.Infrastructure.Data;
using RegistrosSanitarios.Infrastructure.Repositories;

internal class Program
{
    private static readonly ILog log = LogManager.GetLogger(typeof(Program));

    private static void Main(string[] args)
    {

        //var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
        //XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

        Log4NetConfig.InitializeConfig();

        log.Info("INICIANDO APLICACIÓN");

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        try
        {
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // esto tengo que cambiar como se registran los servicios CQRS
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateHospitalHandler).Assembly);
            });

            //builder.Services.AddMediatR(cfg =>
            //{
            //    cfg.RegisterServicesFromAssembly(typeof(CreateHospitalHandler).Assembly);
            //    cfg.RegisterServicesFromAssembly(typeof(DeleteHospitalHandler).Assembly);
            //    cfg.RegisterServicesFromAssembly(typeof(UpdateHospitalHandler).Assembly);

            //    cfg.RegisterServicesFromAssembly(typeof(GetAllHospitalesHandler).Assembly);
            //    cfg.RegisterServicesFromAssembly(typeof(GetHospitalByIdHandler).Assembly);
            //});

            // Add Entity Framework Core and SQL Server
            builder.Services.AddDbContext<RegistrosSanitariosContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add Dependency Injection for Repositories and Services
            builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
            builder.Services.AddScoped<IHospitalRepository, HospitalRepository>();

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
        catch (Exception ex)
        {
            log.Error("Error al iniciar la aplicación", ex);
        }
    }

}