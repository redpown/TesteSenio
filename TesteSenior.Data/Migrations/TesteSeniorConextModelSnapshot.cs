﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteSenior.Data.Context;

namespace TesteSenior.Data.Migrations
{
    [DbContext(typeof(TesteSeniorConext))]
    partial class TesteSeniorConextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("testesenior.Domain.DTO.SPRankingCondominio", b =>
                {
                    b.Property<int>("andar")
                        .HasColumnType("int")
                        .HasColumnName("ANDAR");

                    b.Property<int>("codigoApartamento")
                        .HasColumnType("int")
                        .HasColumnName("CODIGO_APARTAMENTO");

                    b.Property<int>("codigoEdificio")
                        .HasColumnType("int")
                        .HasColumnName("CODIGO_EDIFICIO");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ESTADO");

                    b.Property<int>("metragem")
                        .HasColumnType("int")
                        .HasColumnName("METRAGEM");

                    b.Property<string>("nomeCidade")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NOME_CIDADE");

                    b.Property<string>("nomeEdificio")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NOME_EDIFICIO");

                    b.Property<int>("numeroQuartos")
                        .HasColumnType("int")
                        .HasColumnName("NUMERO_QUARTOS");

                    b.Property<double>("valorPagamento")
                        .HasColumnType("float")
                        .HasColumnName("VALOR_PAGAMENTO");

                    b.ToTable("spRankingCondominio");
                });

            modelBuilder.Entity("testesenior.Domain.Entity.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Senha")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("USUARIO_SENHA");

                    b.Property<string>("email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("USUARIO_EMAIL");

                    b.Property<string>("nome")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("USUARIO_NOME");

                    b.HasKey("id")
                        .HasName("USUARIO_ID");

                    b.ToTable("TABELA_USUARIOS");

                    b.HasData(
                        new
                        {
                            id = 1,
                            email = "teste@teste.com",
                            nome = "andre"
                        },
                        new
                        {
                            id = 2,
                            email = "teste@teste.com",
                            nome = "youko"
                        });
                });

            modelBuilder.Entity("testesenior.domain.Entity.TabelaApartamento", b =>
                {
                    b.Property<int>("codigoApartamento")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("CODIGO_APARTAMENTO")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("andar")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("ANDAR");

                    b.Property<int>("metragem")
                        .HasMaxLength(400)
                        .HasColumnType("int")
                        .HasColumnName("METRAGEM");

                    b.Property<int>("numeroQuartos")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("NUMERO_QUARTOS");

                    b.Property<int>("tabelaEdificioID")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("CODIGO_EDIFICIO");

                    b.HasKey("codigoApartamento")
                        .HasName("CODIGO_APARTAMENTO_ID");

                    b.HasIndex("tabelaEdificioID");

                    b.ToTable("TABELA_APARTAMENTO");

                    b.HasData(
                        new
                        {
                            codigoApartamento = 1,
                            andar = 1,
                            metragem = 100,
                            numeroQuartos = 2,
                            tabelaEdificioID = 1
                        },
                        new
                        {
                            codigoApartamento = 2,
                            andar = 3,
                            metragem = 98,
                            numeroQuartos = 3,
                            tabelaEdificioID = 1
                        },
                        new
                        {
                            codigoApartamento = 3,
                            andar = 2,
                            metragem = 120,
                            numeroQuartos = 4,
                            tabelaEdificioID = 1
                        },
                        new
                        {
                            codigoApartamento = 4,
                            andar = 4,
                            metragem = 120,
                            numeroQuartos = 4,
                            tabelaEdificioID = 1
                        },
                        new
                        {
                            codigoApartamento = 5,
                            andar = 1,
                            metragem = 100,
                            numeroQuartos = 3,
                            tabelaEdificioID = 1
                        },
                        new
                        {
                            codigoApartamento = 6,
                            andar = 3,
                            metragem = 90,
                            numeroQuartos = 2,
                            tabelaEdificioID = 1
                        },
                        new
                        {
                            codigoApartamento = 7,
                            andar = 5,
                            metragem = 150,
                            numeroQuartos = 4,
                            tabelaEdificioID = 1
                        },
                        new
                        {
                            codigoApartamento = 8,
                            andar = 14,
                            metragem = 200,
                            numeroQuartos = 3,
                            tabelaEdificioID = 1
                        });
                });

            modelBuilder.Entity("testesenior.domain.Entity.TabelaCidade", b =>
                {
                    b.Property<int>("codigoCidade")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("CODIGO_CIDADE")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("ESTADO");

                    b.Property<string>("nomeCidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NOME_CIDADE");

                    b.HasKey("codigoCidade")
                        .HasName("CODIGO_CIDADE_ID");

                    b.ToTable("TABELA_CIDADE");

                    b.HasData(
                        new
                        {
                            codigoCidade = 1,
                            estado = "SP",
                            nomeCidade = "Campinas"
                        },
                        new
                        {
                            codigoCidade = 2,
                            estado = "RJ",
                            nomeCidade = "Rio de Janeiro"
                        },
                        new
                        {
                            codigoCidade = 3,
                            estado = "SP",
                            nomeCidade = "São Paulo"
                        },
                        new
                        {
                            codigoCidade = 4,
                            estado = "SP",
                            nomeCidade = "Sorocaba"
                        },
                        new
                        {
                            codigoCidade = 5,
                            estado = "SP",
                            nomeCidade = "Jundiaí"
                        },
                        new
                        {
                            codigoCidade = 6,
                            estado = "SP",
                            nomeCidade = "Hortolândia"
                        });
                });

            modelBuilder.Entity("testesenior.domain.Entity.TabelaEdificio", b =>
                {
                    b.Property<int>("codigoEdificio")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("CODIGO_EDIFICIO")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("andares")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("ANDARES");

                    b.Property<string>("nomeEdificio")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NOME_EDIFICIO");

                    b.Property<int>("numeroAptoAndar")
                        .HasMaxLength(12)
                        .HasColumnType("int")
                        .HasColumnName("NUMERO__APTO_ANDAR");

                    b.Property<int>("tabelaCidadeId")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("CODIGO_CIDADE");

                    b.HasKey("codigoEdificio")
                        .HasName("CODIGO_EDIFICIO_ID");

                    b.HasIndex("tabelaCidadeId");

                    b.ToTable("TABELA_EDIFICIO");

                    b.HasData(
                        new
                        {
                            codigoEdificio = 1,
                            andares = 5,
                            nomeEdificio = "Edifício Esplanada",
                            numeroAptoAndar = 4,
                            tabelaCidadeId = 1
                        },
                        new
                        {
                            codigoEdificio = 2,
                            andares = 10,
                            nomeEdificio = "Edifício Vera",
                            numeroAptoAndar = 3,
                            tabelaCidadeId = 2
                        },
                        new
                        {
                            codigoEdificio = 3,
                            andares = 5,
                            nomeEdificio = "Edifício Sônia",
                            numeroAptoAndar = 4,
                            tabelaCidadeId = 1
                        },
                        new
                        {
                            codigoEdificio = 4,
                            andares = 7,
                            nomeEdificio = "Edifício Tavares",
                            numeroAptoAndar = 4,
                            tabelaCidadeId = 3
                        },
                        new
                        {
                            codigoEdificio = 5,
                            andares = 12,
                            nomeEdificio = "Edifício Renata",
                            numeroAptoAndar = 2,
                            tabelaCidadeId = 3
                        },
                        new
                        {
                            codigoEdificio = 6,
                            andares = 14,
                            nomeEdificio = "Edifício Tiago",
                            numeroAptoAndar = 4,
                            tabelaCidadeId = 1
                        },
                        new
                        {
                            codigoEdificio = 7,
                            andares = 15,
                            nomeEdificio = "Edifício Sol",
                            numeroAptoAndar = 2,
                            tabelaCidadeId = 1
                        });
                });

            modelBuilder.Entity("testesenior.domain.Entity.TabelaPagamentosCondominio", b =>
                {
                    b.Property<int>("codigoPagamentoCondominio")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("CODIGO_PAGAMENTOS_CONDOMINIO")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dataPagamento")
                        .HasColumnType("date")
                        .HasColumnName("DATA_PAGAMENTO");

                    b.Property<int>("tabelaApartamentoID")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("CODIGO_APARTAMENTO");

                    b.Property<double>("valorPagamento")
                        .HasMaxLength(400)
                        .HasColumnType("float")
                        .HasColumnName("VALOR_PAGAMENTO");

                    b.HasKey("codigoPagamentoCondominio")
                        .HasName("CODIGO_PAGAMENTOS_CONDOMINIO_ID");

                    b.HasIndex("tabelaApartamentoID");

                    b.ToTable("TABELA_PAGAMENTOS_CONDOMINIO");

                    b.HasData(
                        new
                        {
                            codigoPagamentoCondominio = 1,
                            dataPagamento = new DateTime(2011, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            tabelaApartamentoID = 1,
                            valorPagamento = 450.0
                        },
                        new
                        {
                            codigoPagamentoCondominio = 2,
                            dataPagamento = new DateTime(2011, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            tabelaApartamentoID = 2,
                            valorPagamento = 330.0
                        },
                        new
                        {
                            codigoPagamentoCondominio = 3,
                            dataPagamento = new DateTime(2011, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            tabelaApartamentoID = 2,
                            valorPagamento = 250.0
                        },
                        new
                        {
                            codigoPagamentoCondominio = 4,
                            dataPagamento = new DateTime(2011, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            tabelaApartamentoID = 3,
                            valorPagamento = 110.0
                        },
                        new
                        {
                            codigoPagamentoCondominio = 5,
                            dataPagamento = new DateTime(2011, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            tabelaApartamentoID = 4,
                            valorPagamento = 220.0
                        },
                        new
                        {
                            codigoPagamentoCondominio = 6,
                            dataPagamento = new DateTime(2011, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            tabelaApartamentoID = 5,
                            valorPagamento = 540.0
                        },
                        new
                        {
                            codigoPagamentoCondominio = 7,
                            dataPagamento = new DateTime(2011, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            tabelaApartamentoID = 2,
                            valorPagamento = 450.0
                        },
                        new
                        {
                            codigoPagamentoCondominio = 8,
                            dataPagamento = new DateTime(2011, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            tabelaApartamentoID = 3,
                            valorPagamento = 340.0
                        },
                        new
                        {
                            codigoPagamentoCondominio = 9,
                            dataPagamento = new DateTime(2011, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            tabelaApartamentoID = 4,
                            valorPagamento = 220.0
                        });
                });

            modelBuilder.Entity("testesenior.domain.Entity.TabelaApartamento", b =>
                {
                    b.HasOne("testesenior.domain.Entity.TabelaEdificio", "tabelaEdificio")
                        .WithMany()
                        .HasForeignKey("tabelaEdificioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tabelaEdificio");
                });

            modelBuilder.Entity("testesenior.domain.Entity.TabelaEdificio", b =>
                {
                    b.HasOne("testesenior.domain.Entity.TabelaCidade", "tabelaCidade")
                        .WithMany()
                        .HasForeignKey("tabelaCidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tabelaCidade");
                });

            modelBuilder.Entity("testesenior.domain.Entity.TabelaPagamentosCondominio", b =>
                {
                    b.HasOne("testesenior.domain.Entity.TabelaApartamento", "tabelaApartamento")
                        .WithMany()
                        .HasForeignKey("tabelaApartamentoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tabelaApartamento");
                });
#pragma warning restore 612, 618
        }
    }
}
