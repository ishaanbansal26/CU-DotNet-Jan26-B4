using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LoanManagementAPI_with_DTO.Data;
using LoanManagementAPI_with_DTO.Mappings;

namespace LoanManagementAPI_with_DTO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<LoanManagementAPI_with_DTOContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("LoanManagementAPI_with_DTOContext") ?? throw new InvalidOperationException("Connection string 'LoanManagementAPI_with_DTOContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(MappingProfile));

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
