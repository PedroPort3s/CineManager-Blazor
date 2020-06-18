using CineManagerBlazor.Shared.DTOs;
using CineManagerBlazor.Shared.Models;
using System.Threading.Tasks;

namespace CineManagerBlazor.Client.Repositorio {
    interface IFuncionarioRepos {
        Task<int> CriarFuncionario(Funcionario forn);
        Task DeletarFuncionario(int id);
        Task AtualizarFuncionario(AtualizarFuncionarioDTO forn);
        Task<Funcionario> GetFuncionario(int id);
    }
}
