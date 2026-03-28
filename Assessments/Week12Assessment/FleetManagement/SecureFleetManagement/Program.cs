using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrackingService.Data;
using TrackingService.Repositories;
using TrackingService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SecureFleetManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<TrackingServiceContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TrackingServiceContext")));


            //builder.Services.AddDbContext<TrackingServiceContext>(options =>
            //options.UseSqlite(builder.Configuration.GetConnectionString("TrackingServiceContext") ?? throw new InvalidOperationException("Connection string 'TrackingServiceContext' not found.")));

            // Add services to the container.

            //Jwt Service
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ITrackService, TrackService>();
            builder.Services.AddScoped<ITrackRepository, TrackRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
