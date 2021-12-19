using CRUDMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMVC.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<Destino> Destinos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-JHJ515G;Initial Catalog=CRUDMVC;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pacote>(table =>
            {
                /* A tabela destinos deveria ter 2 chaves estrangeiras, mas eu não soube fazer por aqui. Fiz manualmente no SQLServer */
                table.ToTable("Pacotes");
                table.HasKey(prop => prop.Id);
                table.Property(prop => prop.Id_cliente).HasColumnType("int");
                table.Property(prop => prop.Id_destino).HasColumnType("int");
                table.Property(prop => prop.DataCompra).HasColumnType("date");
                table.Property(prop => prop.DataViagem).HasColumnType("date");
                table.Property(prop => prop.Preco).HasColumnType("money");
            });

            modelBuilder.Entity<Destino>(table =>
            {
                table.ToTable("Destinos");
                table.HasKey(prop => prop.Id);
                table.Property(prop => prop.Titulo).HasMaxLength(20).IsRequired();
                table.Property(prop => prop.Descricao).HasMaxLength(200).IsRequired();
                table.Property(prop => prop.Promo).HasMaxLength(3);
                table.Property(prop => prop.Tipo).HasMaxLength(3);
                table.Property(prop => prop.Preco).HasColumnType("money");
            });

            modelBuilder.Entity<Cliente>(table =>
            {
                table.ToTable("Clientes");
                table.HasKey(prop => prop.Id);
                table.Property(prop => prop.Nome).HasMaxLength(40).IsRequired();
                table.Property(prop => prop.Endereco).HasMaxLength(200).IsRequired();
                table.Property(prop => prop.Telefone).HasMaxLength(11).IsRequired();
                table.Property(prop => prop.CPF).HasColumnType("char(11)").IsRequired();
                table.Property(prop => prop.Sexo).HasColumnType("char(1)");
                table.Property(prop => prop.Idade).HasColumnType("int");
            });
        }

    }
}