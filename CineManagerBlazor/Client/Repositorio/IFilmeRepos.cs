using CineManagerBlazor.Shared.DTOs;
using CineManagerBlazor.Shared.Models;
using System.Threading.Tasks;

namespace CineManagerBlazor.Client.Repositorio
{
    public interface IFilmeRepos
    {
        Task<int> CriarFilme(Filme filme);
        Task DeletarFilme(int Id);
        Task<DetalhesFilmeDTO> GetDetalhesFilmeDTO(int id);
        //Task<IndexPageDTO> GetIndexPageDTO();
        Task<AtualizarFilmeDTO> GetFilmeAtualizar(int id);
        //Task<PaginatedResponse<List<Movie>>> GetMoviesFiltered(FilterMoviesDTO filterMoviesDTO);
        Task AtualizarFilme(Filme filme);
    }
}
