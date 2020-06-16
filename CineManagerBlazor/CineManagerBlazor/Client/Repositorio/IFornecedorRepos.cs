using CineManagerBlazor.Shared.DTOs;
using CineManagerBlazor.Shared.Models;
using System.Threading.Tasks;

namespace CineManagerBlazor.Client.Repositorio {
    public interface IFornecedorRepos {
        Task<Fornecedor> GetFornecedor(int id);
        Task<int> CriarFornecedor(Fornecedor forn);
        Task AtualizarFornecedor(AtualizarFornecedorDTO forn);
        Task DeletarFornecedor(int id);
    }
}
