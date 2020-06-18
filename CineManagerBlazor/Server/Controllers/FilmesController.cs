using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineManagerBlazor.Shared.Models;
using CineManagerBlazor.Shared.DTOs;
using AutoMapper;
using CineManagerBlazor.Server.Data;
using Microsoft.AspNetCore.Authorization;

namespace CineManagerBlazor.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FilmesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Filmes
        [HttpGet]
        public async Task<ActionResult<Filme[]>> GetFilme()
        {
            return await _context.Filme.ToArrayAsync();
        }

        // GET: api/Filmes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalhesFilmeDTO>> GetFilme(int id)
        {
            var filme = await _context.Filme.Where(x => x.Id == id)
                .Include(x => x.Generos).ThenInclude(x => x.Genero)
                .Include(x => x.TiposFilme).ThenInclude(x => x.TipoFilme)
                .FirstOrDefaultAsync();

            if (filme == null)
            {
                return NotFound();
            }

            DetalhesFilmeDTO DTO = new DetalhesFilmeDTO();
            DTO.Filme = filme;
            DTO.Generos = filme.Generos.Select(x => x.Genero).ToList();
            DTO.TiposFilme = filme.TiposFilme.Select(x => x.TipoFilme).ToList();

            return DTO;
        }

        // PUT: api/Filmes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<ActionResult> PutFilme(Filme filme)
        {
            try
            {              
                var listGenRemove = await _context.FilmeGeneros.Where(x => x.filmeId == filme.Id).ToListAsync();

                var listTipoRemove = await _context.FilmesTipo.Where(x => x.filmeId == filme.Id).ToListAsync();

                _context.RemoveRange(listGenRemove);
                _context.RemoveRange(listTipoRemove);

                _context.Filme.Update(filme);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok();
                }
                else
                {
                    throw new System.Exception("Não foi possivel atualizar o filme");
                }
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // POST: api/Filmes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<int>> PostFilme(Filme filme)
        {
            try
            {
                _context.Filme.Add(filme);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
            

            return filme.Id;
        }

        // DELETE: api/Filmes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Filme>> DeleteFilme(int id)
        {
            var filme = await _context.Filme.FindAsync(id);
            if (filme == null)
            {
                return NotFound();
            }

            _context.Filme.Remove(filme);
            await _context.SaveChangesAsync();

            return filme;
        }

        [HttpGet("atualizar/{id}")]
        public async Task<ActionResult<AtualizarFilmeDTO>> PutGet(int id)
        {
            var filmeResult = await GetFilme(id);

            if (filmeResult.Result is NotFoundResult)
            {
                return NotFound();
            }

            DetalhesFilmeDTO filmeDetail = filmeResult.Value;
            List<int> idsGenerosSelecionados = filmeDetail.Generos.Select(x => x.Id).ToList();
            List<int> idsTiposSelecionados = filmeDetail.TiposFilme.Select(x => x.Id).ToList();
            List<Genero> generosNaoSelecionados = await _context.Generos.Where(x => !idsGenerosSelecionados.Contains(x.Id)).ToListAsync();
            List<TipoFilme> tipoFilmeSelecionados = await _context.TipoFilmes.Where(x => !idsTiposSelecionados.Contains(x.Id)).ToListAsync();

            AtualizarFilmeDTO atualizarFilme = new AtualizarFilmeDTO();
            atualizarFilme.Filme = filmeDetail.Filme;
            atualizarFilme.GenerosSelecionados = filmeDetail.Generos;
            atualizarFilme.GenerosNaoSelecionados = generosNaoSelecionados;
            atualizarFilme.tiposDoFilme = tipoFilmeSelecionados;

            return atualizarFilme;
        }

        private bool FilmeExists(int id)
        {
            return _context.Filme.Any(e => e.Id == id);
        }
    }
}
