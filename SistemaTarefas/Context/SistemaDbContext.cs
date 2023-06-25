using System;
using System.Buffers.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaTarefas.Entities;
using Microsoft.CodeAnalysis;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Npgsql;


#nullable disable
namespace SistemaTarefas.Context
{
    public partial class SistemaDbContext : DbContext
    {
        public SistemaDbContext()
        {
        }

        public SistemaDbContext(DbContextOptions<SistemaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Projeto> Projects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Tarefa> Tarefas { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=es2;Username=postgres;Password=eduardo");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.Property(e => e.idproject).ValueGeneratedOnAdd()
                    .UseIdentityColumn();

                entity.Property(e => e.nomecliente).HasDefaultValueSql(null);
                
                 entity.Property(e => e.precohora).HasDefaultValueSql(null);
            });

            modelBuilder.Entity<Tarefa>(entity =>
            {
                entity.ToTable("tarefas"); // Set the table name

                entity.HasKey(e => e.id_tarefa); // Set the primary key

                entity.Property(e => e.id_tarefa)
                    .HasColumnName("id_tarefa");

                entity.Property(e => e.hora_inicio)
                    .HasColumnName("hora_inicio")
                    .HasColumnType("date");

                entity.Property(e => e.hora_fim)
                    .HasColumnName("hora_fim")
                    .HasColumnType("date");

                entity.Property(e => e.estado)
                    .HasColumnName("estado");

                entity.Property(e => e.descricao)
                    .HasColumnName("descricao");

                entity.Property(e => e.precohora)
                    .HasColumnName("precohora");

                entity.Property(e => e.id_projeto)
                    .HasColumnName("id_projeto");

                entity.Property(e => e.Username)
                    .HasColumnName("utilizador");

                entity.Property(e => e.nome_projeto)
                    .HasColumnName("nome_projeto");
                
                
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users"); // Set the table name

                entity.HasKey(e => e.idUser);

                entity.Property(e => e.idUser)
                    .HasColumnName("idUser");

                entity.Property(e => e.email)
                    .HasColumnName("email")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.password)
                    .HasColumnName("password")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.nhoras)
                    .HasColumnName("nhoras");
            });
        }

        public string GetProjectNameById(int? projectId)
        {
            var project = Projects.FirstOrDefault(p => p.idproject == projectId);
            return project?.nomeProjeto;
        }
    }
}
