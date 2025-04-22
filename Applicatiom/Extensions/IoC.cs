using Applicatiom.Interfaces.IServices;
using Applicatiom.Services;
using Applicatiom.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Applicatiom.Extensions
{
    public static class IoC
    {
        public static void AddApplicationInjectDependencies(this IServiceCollection services)
        {
            #region services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IClubService, ClubService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<ITransferService, TransferService>();
            services.AddScoped<IUserService, UserService>();
            #endregion

            #region automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #endregion

            #region fluentValidations services
            services.AddFluentValidationAutoValidation();

            // na teoria isso aqui irá servir para todos os validators (assim nao temos que chamar um por um)
            services.AddValidatorsFromAssembly(typeof(UserValidator).Assembly);
            #endregion
        }
    }
}