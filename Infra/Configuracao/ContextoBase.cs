﻿using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Configuracao
{
    public class ContextoBase : IdentityDbContext<ApplicationUser>
    {
        public ContextoBase(DbContextOptions options) : base(options){}

        public DbSet<SistemaFinanceiro> SistemaFinanceiro { get; set; }
        public DbSet<UsuarioSistemaFinanceiro> UsuarioSistemaFinanceiro { get; set; }
        public DbSet<Despesa> Despesa { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            return "Server=.\\SQLEXPRESS;Database=FINANCEIRO_2023;Integrated Security=SSPI;TrustServerCertificate=True";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }
    }
}
