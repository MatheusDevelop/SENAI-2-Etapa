using FluentAPI_Escola.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentAPI_Escola.Context
{
    public class EducacaoContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Escola> Escola { get; set; }
        public DbSet<EscolaAluno> EscolasAlunos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=.\Sqlexpress;Initial Catalog= Educacao;user id = sa; password = sa132");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasKey(a => a.Id);
            modelBuilder.Entity<Escola>().HasKey(e => e.Id);

            modelBuilder.Entity<EscolaAluno>().HasKey(ea => ea.Id);

            modelBuilder.Entity<EscolaAluno>().Property(ea => ea.IdAluno);
            modelBuilder.Entity<EscolaAluno>().Property(ea => ea.IdEscola);




        }



    }
}
