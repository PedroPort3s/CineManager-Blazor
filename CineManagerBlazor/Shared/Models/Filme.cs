using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManagerBlazor.Shared.Models {
    public class Filme {

        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Título")]
        [RegularExpression(@"^(?=.{1,200}$).*", ErrorMessage = "O campo {0} deve conter entre 1 e 200 caracteres")]
        [Column(TypeName = "varchar(200)")]
        public string Titulo { get; set; }

        [Display(Name = "Duração")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Column(TypeName = "int")]        
        [RegularExpression(@"^(\d{1,3})$", ErrorMessage = "O campo {0} deve conter de 1 a 3 dígitos.")]
        public int Duracao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Data de lançamento")]
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime")]
        public DateTime Lancamento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Em cartaz até")]
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime")]
        public DateTime EmCartazAte { get; set; }

        public List<FilmeGenero> Generos { get; set; } = new List<FilmeGenero>();
        public List<FilmeTipo> TiposFilme { get; set; } = new List<FilmeTipo>();
    }
}
