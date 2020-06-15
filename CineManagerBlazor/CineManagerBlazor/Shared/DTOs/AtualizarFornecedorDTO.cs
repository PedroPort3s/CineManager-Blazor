using CineManagerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CineManagerBlazor.Shared.DTOs {
    public class AtualizarFornecedorDTO {
        public Fornecedor Fornecedor { get; set; }
        public Fornecedor Fornecedor2 { get; set; }
        public string EndRemover { get; set; }
        public List<Endereco> ListEndRemover { get; set; }
        public List<Telefone> ListTelRemover { get; set; }
        public List<Email> ListEmailRemover { get; set; }
    }
}
