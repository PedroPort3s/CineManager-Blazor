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
    public class GenerosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GenerosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Generos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genero>>> GetGeneros()
        {
            PreencherGeneros();

            return await _context.Generos.ToListAsync();
        }

        // GET: api/Generos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genero>> GetGenero(int id)
        {
            var genero = await _context.Generos.FindAsync(id);

            if (genero == null)
            {
                return NotFound();
            }

            return genero;
        }

        // PUT: api/Generos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenero(int id, Genero genero)
        {
            if (id != genero.Id)
            {
                return BadRequest();
            }

            _context.Entry(genero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneroExists(id))
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

        // POST: api/Generos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Genero>> PostGenero(Genero genero)
        {
            _context.Generos.Add(genero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenero", new { id = genero.Id }, genero);
        }

        // DELETE: api/Generos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Genero>> DeleteGenero(int id)
        {
            var genero = await _context.Generos.FindAsync(id);
            if (genero == null)
            {
                return NotFound();
            }

            _context.Generos.Remove(genero);
            await _context.SaveChangesAsync();

            return genero;
        }

        private bool GeneroExists(int id)
        {
            return _context.Generos.Any(e => e.Id == id);
        }

        private void PreencherGeneros()
        {
            if (_context.Generos.Count() == 0)
            {
                Genero obj1 = new Genero();
                obj1.Nome = "Ação";
                _context.Generos.Add(obj1);

                Genero obj2 = new Genero();
                obj2.Nome = "Animação";
                _context.Generos.Add(obj2);

                Genero obj3 = new Genero();
                obj3.Nome = "Aventura";
                _context.Generos.Add(obj3);

                Genero obj4 = new Genero();
                obj4.Nome = "Cinema de arte";
                _context.Generos.Add(obj4);

                Genero obj5 = new Genero();
                obj5.Nome = "Chanchada";
                _context.Generos.Add(obj5);

                Genero obj6 = new Genero();
                obj6.Nome = "Comédia";
                _context.Generos.Add(obj6);
                Genero obj7 = new Genero();
                obj7.Nome = "Comédia romântica";
                _context.Generos.Add(obj7);

                Genero obj8 = new Genero();
                obj8.Nome = "Comédia dramática";
                _context.Generos.Add(obj8);

                Genero obj9 = new Genero();
                obj9.Nome = "Comédia de ação";
                _context.Generos.Add(obj9);
                Genero obj10 = new Genero();
                obj10.Nome = "Dança";
                _context.Generos.Add(obj10);

                Genero obj11 = new Genero();
                obj11.Nome = "Documentário";
                _context.Generos.Add(obj11);

                Genero obj12 = new Genero();
                obj12.Nome = "Docuficção";
                _context.Generos.Add(obj12);
                Genero obj13 = new Genero();
                obj13.Nome = "Drama";
                _context.Generos.Add(obj13);

                Genero obj14 = new Genero();
                obj14.Nome = "Espionagem";
                _context.Generos.Add(obj14);

                Genero obj15 = new Genero();
                obj15.Nome = "Faroeste";
                _context.Generos.Add(obj15);
                Genero obj16 = new Genero();
                obj16.Nome = "Fantasia científica";
                _context.Generos.Add(obj16);

                Genero obj17 = new Genero();
                obj17.Nome = "Ficção científica";
                _context.Generos.Add(obj17);

                Genero obj18 = new Genero();
                obj18.Nome = "Filmes de guerra";
                _context.Generos.Add(obj18);

                Genero obj19 = new Genero();
                obj19.Nome = "Musical";
                _context.Generos.Add(obj19);

                Genero obj20 = new Genero();
                obj20.Nome = "Filme policial";
                _context.Generos.Add(obj20);

                Genero obj21 = new Genero();
                obj21.Nome = "Romance";
                _context.Generos.Add(obj21);

                Genero obj22 = new Genero();
                obj22.Nome = "Seriado";
                _context.Generos.Add(obj22);

                Genero obj23 = new Genero();
                obj23.Nome = "Suspense";
                _context.Generos.Add(obj23);

                Genero obj24 = new Genero();
                obj24.Nome = "Terror";
                _context.Generos.Add(obj24);

                Genero obj25 = new Genero();
                obj25.Nome = "Pornográfico";
                _context.Generos.Add(obj25);

            }

            _context.SaveChanges();
        }
    }
}
