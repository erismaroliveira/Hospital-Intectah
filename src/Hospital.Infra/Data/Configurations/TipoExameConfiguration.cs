using Hospital.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infra.Data.Configurations
{
    public class TipoExameConfiguration : IEntityTypeConfiguration<TipoExame>
    {
        public void Configure(EntityTypeBuilder<TipoExame> builder)
        {
            builder.ToTable("TipoExame");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(t => t.Descricao).HasColumnType("VARCHAR(256)").IsRequired();
            builder.HasData(new TipoExame[]
            {
                new TipoExame {Id = 1, Nome = "Hemograma", Descricao = "Exame de sangue, Jejum 12 horas."},
                new TipoExame {Id = 2, Nome = "Raio X", Descricao = "Exame de imagem."}
            });
        }
    }
}