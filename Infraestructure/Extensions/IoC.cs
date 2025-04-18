using Applicatiom.Interfaces.IRepositories;
using Domain.Utils;
using Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Infraestructure.Extensions
{
    public static class IoC
    {
        public static void AddMongoDBConfigs(this IServiceCollection services)
            {
            services.AddSingleton<IMongoClient>(sp => new MongoClient(EnviromentsVariables.Connection_String));
            services.AddScoped(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(EnviromentsVariables.Mongo_DataBase);
            });
        }

        public static void AddInfraInjectDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IClubRepository, ClubRepository>();
            services.AddScoped<ITransferRepository, TransferRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        } 
    }
}