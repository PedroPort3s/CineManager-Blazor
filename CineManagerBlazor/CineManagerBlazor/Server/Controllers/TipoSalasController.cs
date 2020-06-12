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
    public class TipoSalasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoSalasController(AppDbContext context)
        {
            _context = context;

            PreencherTipoSala();
        }

        // GET: api/TipoSalas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoSala>>> GetTipoSala()
        {
            return await _context.TipoSala.ToListAsync();
        }

        // GET: api/TipoSalas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoSala>> GetTipoSala(int id)
        {
            var tipoSala = await _context.TipoSala.FindAsync(id);

            if (tipoSala == null)
            {
                return NotFound();
            }

            return tipoSala;
        }

        // PUT: api/TipoSalas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoSala(int id, TipoSala tipoSala)
        {
            if (id != tipoSala.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoSala).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoSalaExists(id))
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

        // POST: api/TipoSalas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoSala>> PostTipoSala(TipoSala tipoSala)
        {
            _context.TipoSala.Add(tipoSala);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoSala", new { id = tipoSala.Id }, tipoSala);
        }

        // DELETE: api/TipoSalas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoSala>> DeleteTipoSala(int id)
        {
            var tipoSala = await _context.TipoSala.FindAsync(id);
            if (tipoSala == null)
            {
                return NotFound();
            }

            _context.TipoSala.Remove(tipoSala);
            await _context.SaveChangesAsync();

            return tipoSala;
        }

        private bool TipoSalaExists(int id)
        {
            return _context.TipoSala.Any(e => e.Id == id);
        }

        private void PreencherTipoSala()
        {
            if (_context.TipoSala.Count() == 0)
            {
                TipoSala obj1 = new TipoSala();
                obj1.Tipo = "2D";
                _context.TipoSala.Add(obj1);   
                TipoSala obj2 = new TipoSala();
                obj1.Tipo = "3D";
                _context.TipoSala.Add(obj1); 
                TipoSala obj3 = new TipoSala();
                obj1.Tipo = "4D";
                _context.TipoSala.Add(obj1); 
                TipoSala obj4 = new TipoSala();
                obj1.Tipo = "4DX";
                _context.TipoSala.Add(obj1); 
                TipoSala obj5 = new TipoSala();
                obj1.Tipo = "IMAX";
                _context.TipoSala.Add(obj1);  
                TipoSala obj6 = new TipoSala();
                obj1.Tipo = "XD";
                _context.TipoSala.Add(obj1);
            }

            _context.SaveChanges();

        }

    }
}
