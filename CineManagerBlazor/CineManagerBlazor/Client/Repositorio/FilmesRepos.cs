using CineManagerBlazor.Client.Helpers;
using CineManagerBlazor.Shared.DTOs;
using CineManagerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineManagerBlazor.Client.Repositorio
{
    public class FilmesRepos : IFilmeRepos
    {

        private readonly IHttpService httpService;
        private string url = "api/filmes";

        public FilmesRepos(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        //public async Task<IndexPageDTO> GetIndexPageDTO()
        //{
        //    return await httpService.GetHelper<IndexPageDTO>(url);
        //}

        public async Task<AtualizarFilmeDTO> GetFilmeAtualizar(int id)
        {
            return await httpService.GetHelper<AtualizarFilmeDTO>($"{url}/atualizar/{id}");
        }

        public async Task<DetalhesFilmeDTO> GetDetalhesFilmeDTO(int id)
        {
            return await httpService.GetHelper<DetalhesFilmeDTO>($"{url}/{id}");
        }

        //public async Task<PaginatedResponse<List<Movie>>> GetMoviesFiltered(FilterMoviesDTO filterMoviesDTO)
        //{
        //    var responseHTTP = await httpService.Post<FilterMoviesDTO, List<Movie>>($"{url}/filter", filterMoviesDTO);
        //    var totalAmountPages = int.Parse(responseHTTP.HttpResponseMessage.Headers.GetValues("totalAmountPages").FirstOrDefault());
        //    var paginatedResponse = new PaginatedResponse<List<Movie>>()
        //    {
        //        Response = responseHTTP.Response,
        //        TotalAmountPages = totalAmountPages
        //    };

        //    return paginatedResponse;
        //}

        public async Task<int> CriarFilme(Filme filme)
        {
            var response = await httpService.Post<Filme, int>(url, filme);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task AtualizarFilme(Filme filme)
        {
            var response = await httpService.Put(url, filme);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task DeletarFilme(int Id)
        {
            var response = await httpService.Delete($"{url}/{Id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
