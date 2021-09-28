using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Linq;
using Hospital.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infra.Repositorios
{
    public class ExameRepositorio : IExameRepositorio
    {
        private readonly ApplicationContext _db;

        public ExameRepositorio(ApplicationContext db)
        {
            _db = db;
        }

        public int Alterar(Exame entity)
        {
            var tipoExameId = entity.TipoExame.Id;
            var exame = _db.Exames.Find(entity.Id);

            exame.Nome = entity.Nome;
            exame.Observacao = entity.Observacao;
            exame.TipoExame = _db.TipoExames.Find(tipoExameId);

            return _db.SaveChanges();
        }

        public Exame ConsultarPorId(int id) =>
            _db.Exames.AsNoTracking()
                .Include(e => e.TipoExame)
                .FirstOrDefault(p => p.Id.Equals(id));

        public ICollection<Exame> ConsultarTodos() =>
            (from p in _db.Exames
                    .AsNoTracking()
                    .Include(e => e.TipoExame)
                select p).ToList();

        public int Excluir(int id)
        {
            var exame = _db.Exames.Find(id);

            _db.Exames.Remove(exame);

            return _db.SaveChanges();
        }

        public int Inserir(Exame entity)
        {
            entity.TipoExame = _db.TipoExames.Find(entity.TipoExame.Id);
            _db.Exames.Add(entity);
            return _db.SaveChanges();
        }
    }
}