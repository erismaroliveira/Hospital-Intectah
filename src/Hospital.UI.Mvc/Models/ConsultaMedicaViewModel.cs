using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Domain.Entidades;

namespace Hospital.UI.MVC.Models
{
    public class ConsultaMedicaViewModel
    {
        public int Id { get; set; }
        //public Paciente Paciente { get; set; }
        //public Exame Exame { get; set; }
        //public TipoExame TipoExame { get; set; }
        public DateTime DataHoraExame { get; set; }
        public int Protocolo { get; set; }
        public int PacienteId { get; set; }
        public int ExameId { get; set; }
        //public int TipoExameId { get; set; }
    }
}