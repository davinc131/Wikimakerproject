using System;
using System.Collections.Generic;
using System.Text;
using ModelClassLibrary;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace DAOClassLibrary
{
    public class WikiDbContext:DbContext
    {


        public DbSet<Usuario> GetUsuarios { get; set; }
        public DbSet<Documento> GetDocumentos { get; set; }
        public DbSet<DocTemporario> GetDocTemporarios { get; set; }
        public DbSet<ImagensDoc> GetImagens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=Wikimakerdb;Username=postgres;Password=leonardoiot");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().Property(f => f.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Documento>().Property(f => f.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<DocTemporario>().Property(f => f.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ImagensDoc>().Property(f => f.Id).ValueGeneratedOnAdd();
        }
    }
}
