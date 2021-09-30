using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Domain.Entidades;

namespace Hospital.UI.MVC.Models
{
    public class ConsultaMedicaViewModel
    {
        public int Id { get; set; }
        public DateTime DataHoraExame { get; set; }
        public int Protocolo { get; set; }

        [DisplayName("Paciente")]
        public int PacienteId { get; set; }

        [DisplayName("Exame")]
        public int ExameId { get; set; }

        [DisplayName("Tipo de Exame")]
        public int TipoExameId { get; set; }
    }
}