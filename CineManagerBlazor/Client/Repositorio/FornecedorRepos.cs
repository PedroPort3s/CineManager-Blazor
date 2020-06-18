using CineManagerBlazor.Client.Helpers;
using CineManagerBlazor.Shared.DTOs;
using CineManagerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineManagerBlazor.Client.Repositorio {
    public class FornecedorRepos : IFornecedorRepos {

        private readonly IHttpService httpService;
        private string url = "api/fornecedores";

        public FornecedorRepos(IHttpService httpService) {
            this.httpService = httpService;
        }

        public async Task<Fornecedor> GetFornecedor(int id) {
            return await httpService.GetHelper<Fornecedor>($"{url}/{id}");
        }
        public async Task<int> CriarFornecedor(Fornecedor forn) {
            var response = await httpService.Post<Fornecedor, int>(url, forn);
            if (!response.Success) {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task AtualizarFornecedor(AtualizarFornecedorDTO fornDTO) {
            var response = await httpService.Put($"{url}/{fornDTO.Fornecedor.Id}", fornDTO);

            if (!response.Success) {
                throw new ApplicationException(await response.GetBody());
            }
        }


        public async Task DeletarFornecedor(int id) {
            var response = await httpService.Delete($"{url}/{id}");

            if (!response.Success) {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
