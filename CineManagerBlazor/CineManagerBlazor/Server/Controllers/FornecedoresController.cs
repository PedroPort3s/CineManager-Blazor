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
    public class FornecedoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FornecedoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Fornecedores
        [HttpGet]
        public async Task<ActionResult<Fornecedor[]>> GetFornecedor()
        {
            return await _context.Fornecedor.ToArrayAsync();
        }

        // GET: api/Fornecedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> GetFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedor.Include(x => x.ListaEndereco).Include(x => x.ListaTelefone).
                Include(x => x.ListaEmail).FirstOrDefaultAsync(x => x.Id == id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return fornecedor;
        }

        // PUT: api/Fornecedores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedor(int id, AtualizarFornecedorDTO fornDTO)
        {
            if (id != fornDTO.Fornecedor.Id)
            {
                return BadRequest();
            }

            foreach(string idString in fornDTO.EndRemover.Split(',')) {
                int idInt = Convert.ToInt32(idString);
                if(fornDTO.Fornecedor.ListaEndereco.FirstOrDefault(x => x.Id == idInt) == null) {
                    Endereco end = _context.Endereco.FirstOrDefault(x => x.Id == idInt);
                    _context.Entry(end).State = EntityState.Deleted;
                }
            }

            foreach(var end in fornDTO.Fornecedor.ListaEndereco) {
                if(end.Id == 0) {
                    _context.Entry(end).State = EntityState.Added;
                } else {
                    _context.Entry(end).State = EntityState.Modified;
                }
            }

            _context.Entry(fornDTO.Fornecedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorExists(id))
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

        // POST: api/Fornecedores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Fornecedor>> PostFornecedor(Fornecedor fornecedor)
        {
            _context.Fornecedor.Add(fornecedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFornecedor", new { id = fornecedor.Id }, fornecedor);
        }

        // DELETE: api/Fornecedores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fornecedor>> DeleteFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedor.Include(x => x.ListaEndereco)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            foreach(var end in fornecedor.ListaEndereco) {
                _context.Entry(end).State = EntityState.Deleted;
            }

            _context.Entry(fornecedor).State = EntityState.Deleted;
            _context.SaveChanges();

            return fornecedor;
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedor.Any(e => e.Id == id);
        }
    }
}
