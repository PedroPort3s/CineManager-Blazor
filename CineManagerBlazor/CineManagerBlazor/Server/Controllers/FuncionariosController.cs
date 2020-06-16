using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineManagerBlazor.Server;
using CineManagerBlazor.Shared.Models;
using CineManagerBlazor.Shared.DTOs;

namespace CineManagerBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FuncionariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Funcionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionario()
        {
            return await _context.Funcionario.Include(x => x.ListaEndereco).
                Include(x => x.ListaTelefone).ToListAsync();
        }

        // GET: api/Funcionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> GetFuncionario(int id)
        {
            var funcionario = await _context.Funcionario.
                Include(x => x.ListaEndereco).Include(x => x.ListaTelefone).
                FirstOrDefaultAsync(x => x.Id == id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return funcionario;
        }

        // PUT: api/Funcionarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionario(int id, AtualizarFuncionarioDTO funcDTO)
        {
            if (id != funcDTO.Funcionario.Id)
            {
                return BadRequest();
            }

            foreach (string idString in funcDTO.EndRemover.Split(',')) {
                int idInt = Convert.ToInt32(idString);
                Endereco end = _context.Endereco.FirstOrDefault(x => x.Id == idInt);
                _context.Entry(end).State = EntityState.Deleted;
            }
            foreach (string idString in funcDTO.TelRemover.Split(',')) {
                int idInt = Convert.ToInt32(idString);
                Telefone tel = _context.Telefone.FirstOrDefault(x => x.Id == idInt);
                _context.Entry(tel).State = EntityState.Deleted;
            }

            foreach (var end in funcDTO.Funcionario.ListaEndereco) {
                _context.Entry(end).State = EntityState.Added;
            }
            foreach (var tel in funcDTO.Funcionario.ListaTelefone) {
                _context.Entry(tel).State = EntityState.Added;
            }

            _context.Entry(funcDTO.Funcionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(id))
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

        // POST: api/Funcionarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Funcionario>> PostFuncionario(Funcionario funcionario)
        {
            _context.Funcionario.Add(funcionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuncionario", new { id = funcionario.Id }, funcionario);
        }

        // DELETE: api/Funcionarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Funcionario>> DeleteFuncionario(int id)
        {
            var funcionario = await _context.Funcionario.Include(x => x.ListaEndereco).
                Include(x => x.ListaTelefone).FirstOrDefaultAsync(x => x.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            foreach (var end in funcionario.ListaEndereco) {
                _context.Entry(end).State = EntityState.Deleted;
            }
            foreach (var tel in funcionario.ListaTelefone) {
                _context.Entry(tel).State = EntityState.Deleted;
            }


            _context.Entry(funcionario).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return funcionario;
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionario.Any(e => e.Id == id);
        }
    }
}
