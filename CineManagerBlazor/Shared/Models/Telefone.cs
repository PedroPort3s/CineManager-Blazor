using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManagerBlazor.Shared.Models {
    public class Telefone {
        public int Id { get; set; }

        [Column(TypeName = "varchar(10)")]
        //[Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Tipo { get; set; }

        [Display(Name = "DDD")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Column(TypeName = "int")]
        //[RegularExpression(@"^(\d{1,2})$", ErrorMessage = "O campo {0} deve conter entre 1 e 2 dígitos.")]
        public int DDD { get; set; } = 41;

        [Display(Name = "Número")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Column(TypeName = "bigint")]
        [RegularExpression(@"^(\d{8,9})$", ErrorMessage = "O campo {0} deve conter entre 8 e 9 dígitos.")]
        public long Numero { get; set; }

        [Column(TypeName = "varchar(5)")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [RegularExpression(@"^(\d{1,5})$", ErrorMessage = "O campo {0} deve conter entre 1 e 5 dígitos.")]
        public string DDI { get; set; } = "55";
    }
}
