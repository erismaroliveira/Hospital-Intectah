using System.Collections.Generic;

namespace Hospital.Domain.Interfaces.Servicos.Base
{
    public interface IServico<TEntity> where TEntity : class
    {
        int Inserir(TEntity entity);
        int Alterar(TEntity entity);
        int Excluir(int id);
        TEntity ConsultarPorId(int id);
        ICollection<TEntity> ConsultarTodos();
    }
}