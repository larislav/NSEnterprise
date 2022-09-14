using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSE.Core.DomainObjects;

namespace NSE.Cliente.API.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<NSE.Cliente.API.Models.Cliente>
    {
        public void Configure(EntityTypeBuilder<Models.Cliente> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.OwnsOne(c => c.Cpf, tf =>
            {
                tf.Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(Cpf.CpfMaxLength)
                .HasColumnType("varchar(11)")
                .HasColumnName("Cpf");

            });

            builder.OwnsOne(c => c.Email, tf =>
            {
                tf.Property(c => c.Endereco)
                .IsRequired()
                .HasColumnType($"varchar({Email.EnderecoMaxLength})")
                .HasColumnName("Email");

            });

            // 1 : 1
            builder.HasOne(c => c.Endereco)
                .WithOne(c => c.Cliente);

            builder.ToTable("Clientes");
        }
    }
}
