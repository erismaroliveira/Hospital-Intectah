using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Servicos;
using System.Collections.Generic;
using Hospital.Domain.Interfaces.Repositorios;

namespace Hospital.Business.Servicos
{
    public class ExameServico : IExameServico
    {
        private readonly IExameRepositorio _repositorio;

        public ExameServico(IExameRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public int Alterar(Exame entity) =>
            _repositorio.Alterar(entity);

        public Exame ConsultarPorId(int id) =>
            _repositorio.ConsultarPorId(id);

        public ICollection<Exame> ConsultarTodos() =>
            _repositorio.ConsultarTodos();

        public int Excluir(int id) =>
            _repositorio.Excluir(id);

        public int Inserir(Exame entity) =>
            _repositorio.Inserir(entity);
    }
}