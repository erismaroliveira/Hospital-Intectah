namespace Hospital.Domain.Entidades
{
    public class Exame
    {
        public Exame()
        {

        }

        public Exame(int id, string nome, string observacao, TipoExame tipoExame)
        {
            Id = id;
            Nome = nome;
            Observacao = observacao;
            TipoExame = tipoExame;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }
        public TipoExame TipoExame { get; set; }
    }
}