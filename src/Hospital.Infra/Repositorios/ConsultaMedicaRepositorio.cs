using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Hospital.Infra.Repositorios
{
    public class ConsultaMedicaRepositorio : IConsultaMedicaRepositorio
    {
        private readonly ApplicationContext _db;

        public ConsultaMedicaRepositorio(ApplicationContext db)
        {
            _db = db;
        }

        public int Alterar(ConsultaMedica entity)
        {
            var consulta = _db.ConsultaMedicas.Find(entity.Id);

            consulta.Paciente = entity.Paciente;
            consulta.Exame = entity.Exame;
            consulta.DataHoraExame = entity.DataHoraExame;
            consulta.Protocolo = entity.Protocolo;

            return _db.SaveChanges();
        }

        public ICollection<ConsultaMedica> ConsultarPorDataHoraExame(DateTime dataInicial, DateTime dataFinal) =>
            (from p in _db.ConsultaMedicas.AsNoTracking()
                where p.DataHoraExame >= dataInicial && p.DataHoraExame <= dataFinal
                select p).ToList();

        public ConsultaMedica ConsultarPorId(int id) =>
            _db.ConsultaMedicas.AsNoTracking()
                .Include(e => e.Paciente)
                .Include(e => e.Exame)
                .FirstOrDefault(p => p.Id.Equals(id));

        public ICollection<ConsultaMedica> ConsultarTodos() =>
            (from p in _db.ConsultaMedicas
                    .AsNoTracking()
                    .Include(e => e.Paciente)
                    .Include(e => e.Exame)
                select p).ToList();

        public int Excluir(int id)
        {
            var consulta = _db.ConsultaMedicas.Find(id);

            _db.ConsultaMedicas.Remove(consulta);

            return _db.SaveChanges();
        }

        public int Inserir(ConsultaMedica entity)
        {
            entity.Paciente = _db.Pacientes.Find(entity.Paciente.Id);
            entity.Exame = _db.Exames.Find(entity.Exame.Id);
            _db.ConsultaMedicas.Add(entity);
            return _db.SaveChanges();
        }
    }
}