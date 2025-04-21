using Applicatiom.Interfaces.IServices;
using Applicatiom.Services;
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
        }
    }
}