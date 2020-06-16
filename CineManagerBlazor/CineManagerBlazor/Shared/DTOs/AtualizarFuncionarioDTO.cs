using CineManagerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CineManagerBlazor.Shared.DTOs {
    public class AtualizarFuncionarioDTO {
        public Funcionario Funcionario { get; set; }
        public Funcionario FuncionarioBase { get; set; }
        public string EndRemover { get; set; }
        public string TelRemover { get; set; }
    }
}
