using CineManagerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CineManagerBlazor.Client.Helpers
{
    public class RepositorioInMemory : IRepository
    {
        private readonly IHttpService http;

        public RepositorioInMemory(IHttpService httpService)
        {
            this.http = httpService;
        }

        public async Task<Filme[]> GetFilmes()
        {
            var response = await http.Get<Filme[]>("api/filmes");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task<Fornecedor[]> GetFornecedores()
        {
            var response = await http.Get<Fornecedor[]>("api/fornecedores");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

    }
}
