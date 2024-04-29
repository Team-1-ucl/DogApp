
using DogApp.Shared;
using DogApp.Repository;
using DogApp.Services;
using DogApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using DogApp.Data;

namespace DogApp.API;

/// <summary>
/// Indeholder metoder til opsætning og konfiguration af programmet.
/// </summary>
public class Program
{
    /// <summary>
    /// Indgangspunktet for programmet.
    /// </summary>
    /// <param name="args">Kommandolinjeargumenter.</param>
    public static void Main(string[] args)
    {
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        var builder = WebApplication.CreateBuilder(args);
        // Konfigurerer CORS-policy.
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(MyAllowSpecificOrigins,
                policy =>
                {
                    policy.WithOrigins("https://localhost:7243").AllowAnyHeader().AllowAnyMethod();

                }
                );
        });
        // Registrerer services i containeren.
        builder.Services.AddScoped<ITrackRepo, TrackRepo>();
        builder.Services.AddScoped<ITrackService, TrackService>();

        builder.Services.AddScoped<IItemRepo, ItemRepo>();
        builder.Services.AddScoped<IItemService, ItemService>();

        // Konfigurerer DbContext.
        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        }
        );
        builder.Services.AddControllersWithViews();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //builder.Services.AddAutoMapper(typeof(Program));

        var app = builder.Build();

        // Konfigurerer HTTP-request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        app.UseHttpsRedirection();

        app.UseCors(MyAllowSpecificOrigins);

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
