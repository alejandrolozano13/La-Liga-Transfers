using Applicatiom.Interfaces.IRepositories;
using Applicatiom.Interfaces.IServices;
using Applicatiom.Services;
using Infraestructure.Repositories;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.Text;
using System.Text.Json.Serialization;
using System.Security.Cryptography;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var jwtKey = GenerateJwtKey();

Environment.SetEnvironmentVariable("JWT_KEY", "sua-chave-super-secreta-123"); // <- Aqui você controla a chave
var jwt = Environment.GetEnvironmentVariable("JWT_KEY");

if (string.IsNullOrWhiteSpace(jwt))
    throw new Exception("JWT_KEY não está definida como variável de ambiente.");


ConfigureServices(builder, configuration, jwtKey);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(WebApplicationBuilder builder, IConfiguration configuration, string jwtKey)
{
    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Por favor, insira o token JWT",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }});
        });

    // Configuração do MongoDB
    builder.Services.AddSingleton<IMongoClient>(sp =>
        new MongoClient(configuration.GetConnectionString("MongoDb"))
    );

    builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

    builder.Services.AddScoped(sp =>
    {
        var client = sp.GetRequiredService<IMongoClient>();
        var dbName = configuration["MongoDatabase"];
        return client.GetDatabase(dbName);
    });

    // Registro dos Repositórios e Serviços
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IAuthService, AuthService>();

    builder.Services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer("Bearer", options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey))
            };
        });

    // Políticas de Autorização
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
        options.AddPolicy("ClubeStaffOnly", policy => policy.RequireRole("ClubeStaff"));
    });
}

// Método para gerar a chave JWT de forma segura
string GenerateJwtKey()
{
    using (var randomNumberGenerator = new RNGCryptoServiceProvider())
    {
        byte[] randomBytes = new byte[32]; // 256 bits
        randomNumberGenerator.GetBytes(randomBytes);
        return Convert.ToBase64String(randomBytes);
    }
}
