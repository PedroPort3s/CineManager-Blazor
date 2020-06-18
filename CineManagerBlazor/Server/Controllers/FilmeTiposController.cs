using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineManagerBlazor.Server;
using CineManagerBlazor.Shared.Models;
using CineManagerBlazor.Server.Data;
using Microsoft.AspNetCore.Authorization;

namespace CineManagerBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeTiposController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FilmeTiposController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/FilmeTipos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmeTipo>>> GetFilmesTipo()
        {
            return await _context.FilmesTipo.ToListAsync();
        }

        // GET: api/FilmeTipos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmeTipo>> GetFilmeTipo(int id)
        {
            var filmeTipo = await _context.FilmesTipo.FindAsync(id);

            if (filmeTipo == null)
            {
                return NotFound();
            }

            return filmeTipo;
        }

        // PUT: api/FilmeTipos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmeTipo(int id, FilmeTipo filmeTipo)
        {
            if (id != filmeTipo.filmeId)
            {
                return BadRequest();
            }

            _context.Entry(filmeTipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmeTipoExists(id))
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

        // POST: api/FilmeTipos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FilmeTipo>> PostFilmeTipo(FilmeTipo filmeTipo)
        {
            _context.FilmesTipo.Add(filmeTipo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FilmeTipoExists(filmeTipo.filmeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFilmeTipo", new { id = filmeTipo.filmeId }, filmeTipo);
        }

        // DELETE: api/FilmeTipos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FilmeTipo>> DeleteFilmeTipo(int id)
        {
            var filmeTipo = await _context.FilmesTipo.FindAsync(id);
            if (filmeTipo == null)
            {
                return NotFound();
            }

            _context.FilmesTipo.Remove(filmeTipo);
            await _context.SaveChangesAsync();

            return filmeTipo;
        }

        private bool FilmeTipoExists(int id)
        {
            return _context.FilmesTipo.Any(e => e.filmeId == id);
        }
    }
}
