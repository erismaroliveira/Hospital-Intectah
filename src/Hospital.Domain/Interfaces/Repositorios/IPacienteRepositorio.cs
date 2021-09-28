using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Repositorios.Base;

namespace Hospital.Domain.Interfaces.Repositorios
{
    public interface IPacienteRepositorio : IRepositorio<Paciente>
    {
        Paciente ConsultarPorCpf(string cpf);
    }
}