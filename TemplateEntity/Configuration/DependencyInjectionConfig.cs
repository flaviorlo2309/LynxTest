using Infraestructure.Interfaces;
using Infraestructure.Response;
using Service.Interface;
using Service;

namespace FutebolAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ILivroRepository, LivroRepository>();

          

            return services;
        }


    }
}
