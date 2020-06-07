using CineManagerBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineManagerBlazor.Server
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Filme> Filmes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        { }
    }
}
