using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovimentosManuais.ApplicationCore.Entity;
using System;

namespace MovimentosManuais.InfraStruture.EntityConfig
{
    public class Produto_CosifMap : IEntityTypeConfiguration<Produto_Cosif>
    {
        public void Configure(EntityTypeBuilder<Produto_Cosif> builder)
        {
            builder.HasKey(c => new { c.COD_PRODUTO, c.COD_COSIF });

            builder.Property(e => e.COD_PRODUTO)
                   .HasColumnType("CHAR(4)");

            builder.Property(e => e.COD_COSIF)
                   .HasColumnType("CHAR(11)");

            builder.Property(e => e.COD_CLASSIFICACAO)
                   .HasColumnType("CHAR(6)")
                   .IsRequired();

            builder.Property(e => e.STA_STATUS)
                   .HasColumnType("CHAR(1)")
                   .IsRequired();

            //builder.HasOne(s => s.PRODUTO)
            //.WithMany(g => g.PRODUTO_COSIFS)
            //.HasForeignKey(s => s.COD_PRODUTO);
        }
    }
}
