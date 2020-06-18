
using CineManagerBlazor.Shared.Models;
using System.Threading.Tasks;

namespace CineManagerBlazor.Client.Helpers
{
    public interface IRepository
    {
        Task<Filme[]> GetFilmes();
        Task<Fornecedor[]> GetFornecedores();
    }
}
