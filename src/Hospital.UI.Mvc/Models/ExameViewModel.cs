using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.UI.MVC.Models
{
    public class ExameViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }
        public int TipoExameId { get; set; }
        public int ExameId { get; set; }
    }
}