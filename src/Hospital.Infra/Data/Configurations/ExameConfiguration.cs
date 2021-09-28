using Hospital.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infra.Data.Configurations
{
    public class ExameConfiguration : IEntityTypeConfiguration<Exame>
    {
        public void Configure(EntityTypeBuilder<Exame> builder)
        {
            builder.ToTable("Exame");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(e => e.Observacao).HasColumnType("VARCHAR(1000)").IsRequired();
        }
    }
}