using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CapstoneMiniProject.Data;
using CapstoneMiniProject.WebAPIServices;
using CapstoneMiniProject.Repositories;

namespace CapstoneMiniProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CapstoneMiniProjectContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CapstoneMiniProjectContext") ?? throw new InvalidOperationException("Connection string 'CapstoneMiniProjectContext' not found.")));

            // Add services to the container.
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IAccountRepository, DBAccountRepository>();
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
