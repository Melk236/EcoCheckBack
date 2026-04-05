using EcoCheck.Application.Interfaces;
using EcoCheck.Application.Services;
using Microsoft.Extensions.DependencyInjection;


namespace EcoCheck.Application
{
    public static class DependencyInjection //Clase estática que nos permite inyectar las dependencias en el program.cs
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IPuntuacionService, PuntuacionService>();
            services.AddScoped<ICertificacionService, CertificacionService>();
            services.AddScoped<IEmpresaCertificacionService, EmpresaCertificacionService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();

            return services;
        }
    }
}
