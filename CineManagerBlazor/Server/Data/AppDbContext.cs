using CineManagerBlazor.Server.Models;
using CineManagerBlazor.Shared.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineManagerBlazor.Server.Data
{
    public class AppDbContext : ApiAuthorizationDbContext<IdentityUser>
    {
        public AppDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmeGenero>().HasKey(x => new { x.filmeId, x.generoId });
            modelBuilder.Entity<FilmeTipo>().HasKey(x => new { x.filmeId, x.tipoFilmeId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Filme> Filme { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<TipoSala> TipoSala { get; set; }
        public DbSet<Sessao> Sessao { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<TipoFilme> TipoFilmes { get; set; }
        public DbSet<FilmeTipo> FilmesTipo { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<FilmeGenero> FilmeGeneros { get; set; }
    }
}
