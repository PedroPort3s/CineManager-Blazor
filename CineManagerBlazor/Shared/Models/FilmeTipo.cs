using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineManagerBlazor.Shared.Models {
    public class FilmeTipo {
        public int filmeId { get; set; }
        public int tipoFilmeId { get; set; }

        public Filme Filme { get; set; }
        public TipoFilme TipoFilme { get; set; }
    }
}
