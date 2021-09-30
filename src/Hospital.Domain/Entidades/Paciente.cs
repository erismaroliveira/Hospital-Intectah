using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Domain.Entidades
{
    public class Paciente
    {
        public Paciente()
        {

        }

        public Paciente(int id, string nome, string cpf, DateTime? dataNascimento, char? sexo, string telefone, string email, ConsultaMedica consultaMedica)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Telefone = telefone;
            Email = email;
            Consultas = (ICollection<ConsultaMedica>)consultaMedica;
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 14)]
        [RegularExpression("^\\d{3}\\x2E\\d{3}\\x2E\\d{3}\\x2D\\d{2}$", ErrorMessage = "CPF não é válido")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public char? Sexo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(12, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 12)]
        [RegularExpression("^[0-9]{2}-[0-9]{4}-[0-9]{4}$", ErrorMessage = "Telefone não é válido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("E-Mail")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail não é válido")]
        public string Email { get; set; }
        public ICollection<ConsultaMedica> Consultas { get; set; }
    }
}