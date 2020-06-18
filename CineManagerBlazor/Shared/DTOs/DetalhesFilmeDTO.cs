using CineManagerBlazor.Shared.Models;
using System.Collections.Generic;

namespace CineManagerBlazor.Shared.DTOs
{
    public class DetalhesFilmeDTO
    {
        public Filme Filme{ get; set; }
        public List<Genero> Generos{ get; set; }
        public List<TipoFilme> TiposFilme{ get; set; }
    }
}
