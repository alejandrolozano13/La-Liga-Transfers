using Domain.Enums;
using Domain.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LaLigaTransfers.Extensions
{
    public static class AuthExtension
    {
        public static void AddJwtAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = EnviromentsVariables.Jwt_Issuer,
                        ValidAudience = EnviromentsVariables.Jwt_Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(EnviromentsVariables.Jwt_Key))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine($"Falha na autenticação: {context.Exception.Message}");
                            Console.WriteLine($"Stack Trace: {context.Exception.StackTrace}");
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorizationBuilder()
                .AddPolicy("OnlyAdmins", policy => 
                    policy.RequireRole(UserRole.Admin.ToString()
                ))
                .AddPolicy("CanManageTransfers", policy =>
                    policy.RequireRole(UserRole.Admin.ToString(), UserRole.ClubeStaff.ToString()
                ))
                .AddPolicy("CanSuggestTransfer", policy =>
                    policy.RequireRole(UserRole.Agent.ToString()
                ));
        }
    }
}