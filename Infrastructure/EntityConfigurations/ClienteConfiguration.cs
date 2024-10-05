using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    //EXEMPLO
    //public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    //{
    //    public void Configure(EntityTypeBuilder<Cliente> builder)
    //    {
    //        builder.HasOne(c => c.Telefone)
    //            .WithOne(t => t.Cliente).HasPrincipalKey<Telefone>(t => t.ID);

    //        builder.HasOne(c => c.Endereco)
    //            .WithOne(e => e.Cliente).HasPrincipalKey<Endereco>(e => e.ID);

    //        builder.HasMany(c => c.LivrosAlugados)
    //            .WithMany(l => l.ClientesAlugando);
    //    }
    //}
}
