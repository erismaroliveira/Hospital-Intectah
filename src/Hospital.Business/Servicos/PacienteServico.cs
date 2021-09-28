using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Servicos;
using System.Collections.Generic;
using Hospital.Domain.Interfaces.Repositorios;

namespace Hospital.Business.Servicos
{
    public class PacienteServico : IPacienteServico
    {
        private readonly IPacienteRepositorio _repositorio;

        public PacienteServico(IPacienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public int Alterar(Paciente entity) =>
            _repositorio.Alterar(entity);

        public Paciente ConsultarPorCpf(string cpf) =>
            _repositorio.ConsultarPorCpf(cpf);

        public Paciente ConsultarPorId(int id) =>
            _repositorio.ConsultarPorId(id);

        public ICollection<Paciente> ConsultarTodos() =>
            _repositorio.ConsultarTodos();

        public int Excluir(int id) =>
            _repositorio.Excluir(id);

        public int Inserir(Paciente entity) =>
            _repositorio.Inserir(entity);
    }
}