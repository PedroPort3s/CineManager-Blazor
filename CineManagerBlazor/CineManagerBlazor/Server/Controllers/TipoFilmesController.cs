using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineManagerBlazor.Server;
using CineManagerBlazor.Shared.Models;

namespace CineManagerBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoFilmesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoFilmesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoFilmes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoFilme>>> GetTipoFilmes()
        {
            PreencherTiposFilme();

            return await _context.TipoFilmes.ToListAsync();
        }

        // GET: api/TipoFilmes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoFilme>> GetTipoFilme(int id)
        {
            var tipoFilme = await _context.TipoFilmes.FindAsync(id);

            if (tipoFilme == null)
            {
                return NotFound();
            }

            return tipoFilme;
        }

        // PUT: api/TipoFilmes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoFilme(int id, TipoFilme tipoFilme)
        {
            if (id != tipoFilme.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoFilme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoFilmeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TipoFilmes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoFilme>> PostTipoFilme(TipoFilme tipoFilme)
        {
            _context.TipoFilmes.Add(tipoFilme);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoFilme", new { id = tipoFilme.Id }, tipoFilme);
        }

        // DELETE: api/TipoFilmes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoFilme>> DeleteTipoFilme(int id)
        {
            var tipoFilme = await _context.TipoFilmes.FindAsync(id);
            if (tipoFilme == null)
            {
                return NotFound();
            }

            _context.TipoFilmes.Remove(tipoFilme);
            await _context.SaveChangesAsync();

            return tipoFilme;
        }

        private bool TipoFilmeExists(int id)
        {
            return _context.TipoFilmes.Any(e => e.Id == id);
        }

        public void PreencherTiposFilme()
        {
            if (_context.TipoFilmes.Count() == 0)
            {
                TipoFilme objfilme1 = new TipoFilme();
                objfilme1.NomeTipoFilme = "2D";
                _context.TipoFilmes.Add(objfilme1);

                TipoFilme objfilme2 = new TipoFilme();
                objfilme2.NomeTipoFilme = "3D";
                _context.TipoFilmes.Add(objfilme2);

                TipoFilme objfilme3 = new TipoFilme();
                objfilme3.NomeTipoFilme = "4D";
                _context.TipoFilmes.Add(objfilme3);

                TipoFilme objfilme4 = new TipoFilme();
                objfilme4.NomeTipoFilme = "4DX";
                _context.TipoFilmes.Add(objfilme4);

                TipoFilme objfilme5 = new TipoFilme();
                objfilme5.NomeTipoFilme = "IMAX";
                _context.TipoFilmes.Add(objfilme5);

                TipoFilme objfilme6 = new TipoFilme();
                objfilme6.NomeTipoFilme = "Macro XE";
                _context.TipoFilmes.Add(objfilme6);

                TipoFilme objfilme7 = new TipoFilme();
                objfilme7.NomeTipoFilme = "XD";
                _context.TipoFilmes.Add(objfilme7);

                TipoSala objtiposala1 = new TipoSala();
                objtiposala1.Tipo = "2D";
                _context.TipoSala.Add(objtiposala1);

                TipoSala objtiposala2 = new TipoSala();
                objtiposala2.Tipo = "3D";
                _context.TipoSala.Add(objtiposala2);

                TipoSala objtiposala3 = new TipoSala();
                objtiposala3.Tipo = "4D";
                _context.TipoSala.Add(objtiposala3);

                TipoSala objtiposala4 = new TipoSala();
                objtiposala4.Tipo = "4DX";
                _context.TipoSala.Add(objtiposala4);

                TipoSala objtiposala5 = new TipoSala();
                objtiposala5.Tipo = "IMAX";
                _context.TipoSala.Add(objtiposala5);

                TipoSala objtiposala6 = new TipoSala();
                objtiposala6.Tipo = "Macro XE";
                _context.TipoSala.Add(objtiposala6);

                TipoSala objtiposala7 = new TipoSala();
                objtiposala7.Tipo = "XD";
                _context.TipoSala.Add(objtiposala7);

                _context.SaveChanges();
            }
        }
    }
}
