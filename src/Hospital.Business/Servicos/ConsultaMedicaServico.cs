using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.Domain.Interfaces.Repositorios;

namespace Hospital.Business.Servicos
{
    public class ConsultaMedicaServico : IConsultaMedicaServico
    {
        private readonly IConsultaMedicaRepositorio _repositorio;

        public ConsultaMedicaServico(IConsultaMedicaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public int Alterar(ConsultaMedica entity) =>
            _repositorio.Alterar(entity);
        

        public ICollection<ConsultaMedica> ConsultarPorDataHoraExame(DateTime dataInicial, DateTime dataFinal)
        {
            dataInicial = new DateTime(dataInicial.Year, dataInicial.Month, dataInicial.Day, dataInicial.Hour, dataInicial.Minute, 0);
            dataFinal = new DateTime(dataFinal.Year, dataFinal.Month, dataFinal.Day, dataFinal.Hour, dataFinal.Minute, 0);

            return _repositorio.ConsultarPorDataHoraExame(dataInicial, dataFinal);
        }

        public ConsultaMedica ConsultarPorId(int id) =>
            _repositorio.ConsultarPorId(id);

        public ICollection<ConsultaMedica> ConsultarTodos() =>
            _repositorio.ConsultarTodos();

        public int Excluir(int id) =>
            _repositorio.Excluir(id);

        public int Inserir(ConsultaMedica entity) =>
            _repositorio.Inserir(entity);

        public bool ValidarSeExisteNaDataHora(int pacienteId, int tipoExameId, DateTime dataHoraExame)
        {
            var dataInicial = new DateTime(dataHoraExame.Year, dataHoraExame.Month, dataHoraExame.Day, 0, 0, 0);
            var examesDoDia = _repositorio.ConsultarPorDataHoraExame(dataInicial, dataInicial.AddDays(1));

            if (examesDoDia?.Count > 0)
                return examesDoDia.Any(e => e.Paciente.Id.Equals(pacienteId) &&
                                            e.Exame.Id.Equals(tipoExameId) &&
                                            e.DataHoraExame.Equals(dataHoraExame));
            else
                return false;
        }

        public bool ValidarSeExisteConsultaData(DateTime dataHoraExame)
        {
            var consultas = _repositorio.ConsultarPorDataHoraExame(dataHoraExame, dataHoraExame);

            if (consultas?.Count > 0)
                return true;
            else
                return false;
        }
    }
}