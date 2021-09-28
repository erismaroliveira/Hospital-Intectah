namespace Hospital.Domain.Entidades
{
    public class TipoExame
    {
        public TipoExame()
        {

        }

        public TipoExame(int id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}