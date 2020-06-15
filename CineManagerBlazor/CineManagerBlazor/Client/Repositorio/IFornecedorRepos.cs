using CineManagerBlazor.Shared.DTOs;
using CineManagerBlazor.Shared.Models;
using System.Threading.Tasks;

namespace CineManagerBlazor.Client.Repositorio {
    public interface IFornecedorRepos {
        Task<int> CriarFornecedor(Fornecedor forn);
        Task DeletarFornecedor(int id);
        Task AtualizarFornecedor(AtualizarFornecedorDTO forn);
        Task<Fornecedor> GetFornecedor(int id);
    }
}
