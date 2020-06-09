using CineManagerBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CineManagerBlazor.Server
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        { }
        public DbSet<Filme> Filme { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<TipoSala> TipoSala { get; set; }
        public DbSet<Sessao> Sessao { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<TipoFilme> TipoFilmes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<FilmeTipoFilme> FilmeTiposFilme { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<FilmeGenero> FilmeGeneros { get; set; }
    }
}
