using System;

namespace Hospital.Domain.Entidades
{
    public class ConsultaMedica
    {
        public ConsultaMedica()
        {

        }

        public ConsultaMedica(int id, Paciente paciente, Exame exame, DateTime dataHoraExame, int protocolo)
        {
            Id = id;
            Paciente = paciente;
            Exame = exame;
            DataHoraExame = dataHoraExame;
            Protocolo = protocolo;
        }
        public int Id { get; set; }

        public Paciente Paciente { get; set; }
        public Exame Exame { get; set; }
        public DateTime DataHoraExame { get; set; }
        public int Protocolo { get; set; }
    }
}