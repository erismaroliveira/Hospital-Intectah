using System.Collections.Generic;

namespace Hospital.Domain.Interfaces.Repositorios.Base
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        int Inserir(TEntity entity);
        int Alterar(TEntity entity);
        int Excluir(int id);
        TEntity ConsultarPorId(int id);
        ICollection<TEntity> ConsultarTodos();
    }
}