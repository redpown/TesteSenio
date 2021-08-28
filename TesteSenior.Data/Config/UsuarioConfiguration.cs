using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using testesenior.Domain.Entity;

namespace TesteSenior.Data.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TABELA_USUARIOS");

            builder.HasKey(tabelaUsuario => tabelaUsuario.id)
                .HasName("USUARIO_ID");

            builder.Property(tabelaUsuario => tabelaUsuario.nome)
                .HasMaxLength(50)
                .HasColumnName("USUARIO_NOME");

            builder.Property(tabelaUsuario => tabelaUsuario.email)
                .HasMaxLength(50)
                .HasColumnName("USUARIO_EMAIL");

            builder.Property(tabelaUsuario => tabelaUsuario.Senha)
                .HasMaxLength(256)
                .HasColumnName("USUARIO_SENHA");

            builder.HasData(

                new { id = 1, nome = "andre", email = "teste@teste.com", senha = "1234" },
                new { id = 2, nome = "youko", email = "teste@teste.com", senha = "1234" }
                
               );

        }
    }
}
