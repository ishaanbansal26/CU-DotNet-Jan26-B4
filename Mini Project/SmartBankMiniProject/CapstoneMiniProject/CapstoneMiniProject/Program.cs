using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CapstoneMiniProject.Data;
using CapstoneMiniProject.WebAPIServices;
using CapstoneMiniProject.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            builder.Services.AddScoped<IAccountService, AccountServices>();
            builder.Services.AddScoped<IAccountRepository, DBAccountRepository>();

            // JWT Service
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "SmartBank",
                    ValidAudience = "SmartBankUsers",
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("THIS_IS_SUPER_SECRET_KEY_12345_Heeeeeeeeeeeeeellllllllllllllooooooooooooooooooooo"))
                };
            });

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
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
