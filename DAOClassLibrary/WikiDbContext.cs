using System;
using System.Collections.Generic;
using System.Text;
using ModelClassLibrary;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace DAOClassLibrary
{
    public class WikiDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=wikimakerdb;user=root;password=");
        }

        public DbSet<Usuario> GetUsuarios { get; set; }
        public DbSet<Documento> GetDocumentos { get; set; }
        public DbSet<DocTemporario> GetDocTemporarios { get; set; }
        public DbSet<ImagensDoc> GetImagens { get; set; }
    }
}
