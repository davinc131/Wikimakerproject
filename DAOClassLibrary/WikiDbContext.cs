using System;
using System.Collections.Generic;
using System.Text;
using ModelClassLibrary;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAOClassLibrary
{
    public class WikiDbContext:IdentityDbContext
    {
        public WikiDbContext(DbContextOptions<WikiDbContext> options)
            :base(options)
        { }

        public DbSet<Usuario> GetUsuarios { get; set; }
        public DbSet<Documento> GetDocumentos { get; set; }
        public DbSet<DocTemporario> GetDocTemporarios { get; set; }
        public DbSet<ImagensDoc> GetImagens { get; set; }
    }
}
