using EcoCheck.Domain.Interfaces;
using EcoCheck.Infrastructure.Data.Seeders;
using EcoCheck.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace EcoCheck.Infrastructure
{
    public static class DependencyInjection//Clase estática que nos permite inyectar las dependencias en el program.cs
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services) { 
        
           services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
           services.AddScoped<IAuthRepository, AuthRepository>();
           services.AddScoped<IUserRepository, UserRepository>();
           services.AddScoped<IRolesRepository, RolesRepository>();
           services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            services.AddTransient<MarcaSeeder>();
            services.AddTransient<CertificacionSeeder>();
            services.AddTransient<EmpresaCertificacionSeeder>();
            services.AddTransient<RolesSeeder>();

            return services;

        }
    }
}
