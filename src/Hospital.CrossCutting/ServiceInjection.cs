using Hospital.Business.Servicos;
using Hospital.Domain.Interfaces.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.CrossCutting
{
    public static class ServiceInjection
    {
        public static void InjecaoServicos(this IServiceCollection services)
        {
            services.AddScoped<IConsultaMedicaServico, ConsultaMedicaServico>();
            services.AddScoped<IExameServico, ExameServico>();
            services.AddScoped<IPacienteServico, PacienteServico>();
            services.AddScoped<ITipoExameServico, TipoExameServico>();
        }
    }
}