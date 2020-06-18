using CineManagerBlazor.Shared.Models;
using System.Collections.Generic;

namespace CineManagerBlazor.Shared.DTOs
{
    public class AtualizarFilmeDTO
    {
        public Filme Filme{ get; set; }
        public List<TipoFilme> tiposDoFilme { get; set; }
        public List<Genero> GenerosSelecionados { get; set; }
        public List<Genero> GenerosNaoSelecionados { get; set; }
    }
}
