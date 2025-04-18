using Applicatiom.Interfaces.IServices;
using Applicatiom.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Applicatiom.Extensions
{
    public static class IoC
    {
        public static void AddApplicationInjectDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IClubService, ClubService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<ITransferService, TransferService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}