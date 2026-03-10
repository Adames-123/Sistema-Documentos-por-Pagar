using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaCuentasPorPagarAPI.Data;
using SistemaCuentasPorPagarAPI.Models;

namespace SistemaCuentasPorPagarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Conceptoes1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Conceptoes1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Conceptoes1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concepto>>> Getpayment_concepts()
        {
            return await _context.payment_concepts.ToListAsync();
        }

        // GET: api/Conceptoes1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Concepto>> GetConcepto(int id)
        {
            var concepto = await _context.payment_concepts.FindAsync(id);

            if (concepto == null)
            {
                return NotFound();
            }

            return concepto;
        }

        // PUT: api/Conceptoes1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConcepto(int id, Concepto concepto)
        {
            if (id != concepto.IdConcepto)
            {
                return BadRequest();
            }

            _context.Entry(concepto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConceptoExists(id))
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

        // POST: api/Conceptoes1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Concepto>> PostConcepto(Concepto concepto)
        {
            _context.payment_concepts.Add(concepto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConcepto", new { id = concepto.IdConcepto }, concepto);
        }

        // DELETE: api/Conceptoes1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcepto(int id)
        {
            var concepto = await _context.payment_concepts.FindAsync(id);
            if (concepto == null)
            {
                return NotFound();
            }

            _context.payment_concepts.Remove(concepto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConceptoExists(int id)
        {
            return _context.payment_concepts.Any(e => e.IdConcepto == id);
        }
    }
}
