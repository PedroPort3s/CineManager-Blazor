using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineManagerBlazor.Shared.Models
{
    public class Funcionario
    {
        public Funcionario() {
            ListaEndereco = new List<Endereco>();
            ListaTelefone = new List<Telefone>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Nome completo")]
        [RegularExpression(@"^(?=.{1,100}$).*", ErrorMessage = "O campo {0} deve conter entre 1 e 100 caracteres.")]
        [Column(TypeName = "varchar(100)")]
        public string NomeCompleto{ get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Setor")]
        [RegularExpression(@"^(?=.{1,100}$).*", ErrorMessage = "O campo {0} deve conter entre 1 e 100 caracteres.")]
        [Column(TypeName = "varchar(100)")]
        public string Setor { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[RegularExpression(@"^(\d{14})$", ErrorMessage = "O campo {0} deve conter 11 dígitos")]
        [Column(TypeName = "bigint")]
        public long Cpf { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"^(\d{9})$", ErrorMessage = "O campo {0} deve conter 9 dígitos")]
        [Column(TypeName = "bigint")]
        public long Rg { get; set; }

        [Display(Name = "Salário")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"^(\d{3,8}(\,?\d{1,2}))$", ErrorMessage = "O campo {0} deve conter de 3 a 8 dígitos")]
        [Column(TypeName = "varchar(12)")] 
        public string Salario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Cargo")]
        [RegularExpression(@"^(?=.{1,100}$).*", ErrorMessage = "O campo {0} deve conter entre 1 e 100 caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Turno")]
        [RegularExpression(@"^(?=.{1,100}$).*", ErrorMessage = "O campo {0} deve conter entre 1 e 100 caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string Turno { get; set; }

        public List<Telefone> ListaTelefone { get; set; }
        public List<Endereco> ListaEndereco { get; set; }

        [NotMapped]
        public Telefone Telefone { get; set; }
        [NotMapped]
        [Display(Name = "Endereço")]
        public Endereco Endereco { get; set; }
        [NotMapped]
        public int TelefoneId { get; set; }
        [NotMapped]
        public int EnderecoId { get; set; }
    }
}
