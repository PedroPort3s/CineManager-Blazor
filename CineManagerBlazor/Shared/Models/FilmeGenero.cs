using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineManagerBlazor.Shared.Models
{
    public class FilmeGenero
    {
        public int filmeId { get; set; }
        public int generoId { get; set; }

        public Filme Filme { get; set; }
        public Genero Genero { get; set; }
    }
}
