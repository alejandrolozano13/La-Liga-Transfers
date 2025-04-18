//using Domain.Utils;

//namespace LaLigaTransfers.Extensions
//{
//    public static class CorsExentension
//    {
//        public static IServiceCollection AddCustomCors(this IServiceCollection services)
//        {
//            var allowedOrigins = EnviromentsVariables.Cors_Origins.Split(',');

//            services.AddCors(options =>
//            {
//                options.AddPolicy("DefaultCorsPolicy", policy =>
//                {
//                    policy
//                        .WithOrigins(allowedOrigins!)
//                        .AllowAnyHeader()
//                        .AllowAnyMethod();
//                });
//            });

//            return services;
//        }

//        public static IApplicationBuilder UseCustomCors(this IApplicationBuilder app)
//        {
//            app.UseCors("DefaultCorsPolicy");
//            return app;
//        }
//    }
//}