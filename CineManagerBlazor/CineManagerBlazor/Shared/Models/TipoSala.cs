using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CineManagerBlazor.Shared.Models
{
    public class TipoSala
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Tipo de Sala")]
        [Column(TypeName = "varchar(20)")]
        public string Tipo { get; set; }
    }
}
