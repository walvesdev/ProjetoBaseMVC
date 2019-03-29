using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoBaseMVC.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseMVC.Dados.AcessoDados.TypeConfiguration
{
    class EmpresaTypeConfiguration : IEntityTypeConfiguration<Empresa>
    {    
        
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(e => e.Id);
            builder
                .Property(e => e.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(50)
                .IsRequired(true);
            builder
                .Property(e => e.DataFundacao)
                .HasColumnName("DataFundacao")
                .HasColumnType("DateTime")
                .IsRequired(true);
        }
    }
}
