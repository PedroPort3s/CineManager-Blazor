using CineManagerBlazor.Client.Helpers;
using CineManagerBlazor.Shared.DTOs;
using CineManagerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineManagerBlazor.Client.Repositorio {
    public class FuncionarioRepos : IFuncionarioRepos {

        private readonly IHttpService httpService;
        private string url = "api/funcionarios";

        public FuncionarioRepos(IHttpService httpService) {
            this.httpService = httpService;
        }

        public async Task<Funcionario> GetFuncionario(int id) {
            return await httpService.GetHelper<Funcionario>($"{url}/{id}");
        }

        public async Task<int> CriarFuncionario(Funcionario func) {
            var response = await httpService.Post<Funcionario, int>(url, func);
            if (!response.Success) {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task AtualizarFuncionario(AtualizarFuncionarioDTO func) {
            var response = await httpService.Put($"{url}/{func.Funcionario.Id}", func);

            if (!response.Success) {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async  Task DeletarFuncionario(int id) {
            var response = await httpService.Delete($"{url}/{id}");

            if (!response.Success) {
                throw new ApplicationException(await response.GetBody());
            }
        }

    }
}
