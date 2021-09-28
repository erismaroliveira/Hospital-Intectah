using Hospital.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infra.Data.Configurations
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Paciente");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Cpf).HasColumnType("VARCHAR(14)").IsRequired();
            builder.Property(p => p.DataNascimento).HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.Sexo).HasColumnType("CHAR(1)").IsRequired();
            builder.Property(p => p.Telefone).HasColumnType("CHAR(14)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("VARCHAR(400)").IsRequired();

            builder.HasIndex(i => i.Cpf).HasName("IX_PACIENTE_CPF");

            builder.HasMany(p => p.Consultas)
                .WithOne(p => p.Paciente);
        }
    }
}