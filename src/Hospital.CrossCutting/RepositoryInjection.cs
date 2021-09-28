using Hospital.Domain.Interfaces.Repositorios;
using Hospital.Infra.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.CrossCutting
{
    public static class RepositoryInjection
    {
        public static void InjecaoRepositorios(this IServiceCollection services)
        {
            services.AddScoped<IConsultaMedicaRepositorio, ConsultaMedicaRepositorio>();
            services.AddScoped<IExameRepositorio, ExameRepositorio>();
            services.AddScoped<IPacienteRepositorio, PacienteRepositorio>();
            services.AddScoped<ITipoExameRepositorio, TipoExameRepositorio>();
        }
    }
}