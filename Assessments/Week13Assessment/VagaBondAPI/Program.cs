using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VagaBondAPI.Data;
using VagaBondAPI.Reposiotries;
using VagaBondAPI.Service;

namespace VagaBondAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<VagaBondAPIContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("VagaBondAPIContext") ?? throw new InvalidOperationException("Connection string 'VagaBondAPIContext' not found.")));

            // Add services to the container.
            builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();
            builder.Services.AddScoped<IDestinationService, DestinationService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
}
