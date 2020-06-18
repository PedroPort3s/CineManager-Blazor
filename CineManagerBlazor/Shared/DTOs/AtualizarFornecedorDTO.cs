using CineManagerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CineManagerBlazor.Shared.DTOs {
    public class AtualizarFornecedorDTO {
        public Fornecedor Fornecedor { get; set; }
        public Fornecedor FornecedorBase { get; set; }
        public string EndRemover { get; set; }
        public string TelRemover { get; set; }
        public string EmailRemover { get; set; }
    }
}
