using System;
using System.Collections.Generic;
using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Servicos.Base;

namespace Hospital.Domain.Interfaces.Servicos
{
    public interface IConsultaMedicaServico : IServico<ConsultaMedica>
    {
        ICollection<ConsultaMedica> ConsultarPorDataHoraExame(DateTime dataInicial, DateTime dataFinal);
        bool ValidarSeExisteConsultaData(DateTime dataHoraExame);
        bool ValidarSeExisteNaDataHora(int pacienteId, int tipoExameId, DateTime dataHoraExame);
    }
}