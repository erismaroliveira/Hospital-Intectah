using Hospital.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infra.Data.Configurations
{
    public class ConsultaMedicaConfiguration : IEntityTypeConfiguration<ConsultaMedica>
    {
        public void Configure(EntityTypeBuilder<ConsultaMedica> builder)
        {
            builder.ToTable("ConsultaMedica");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.DataHoraExame).HasColumnType("DATETIME");
            builder.Property(c => c.Protocolo);
        }
    }
}