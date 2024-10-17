using Application.Interfaces;
using Application.Services;
using Contract.UsuariosModel.Helpers;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Persistence;
using Infrastructure.ThirdPartyServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddDbContext<ExampleDbContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("ExampleDbConnection")));
        builder.Services.Configure<AutenticacionServiceOptions>(builder.Configuration.GetSection("AutenticacionServiceOptions"));

        builder.Services.AddSwaggerGen(setupAction =>
        {
            setupAction.AddSecurityDefinition("ExampleApiBearerAuth", new OpenApiSecurityScheme()
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                Description = "Paste the token to login."
            });

            setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "ExampleApiBearerAuth"
                        }
                    },
                    new List<string>()
                }
            });
        });

        builder.Services.AddAuthentication("Bearer")
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["AutenticacionServiceOptions:Issuer"],
                    ValidAudience = builder.Configuration["AutenticacionServiceOptions:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["AutenticacionServiceOptions:SecretForKey"]!))
                };
            }
        );

        builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
        builder.Services.AddScoped<IMedicoService, MedicoService>();
        builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

        var app = builder.Build();

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