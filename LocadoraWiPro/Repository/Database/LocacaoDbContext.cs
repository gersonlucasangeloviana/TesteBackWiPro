using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Database
{
   public class LocacaoDbContext : DbContext
    {
        protected LocacaoDbContext(DbContextOptions options) : base(options) { }

        public LocacaoDbContext(DbContextOptions<LocacaoDbContext> options) : this((DbContextOptions)options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Locacao> Locacacoes { get; set; }
    }
}
