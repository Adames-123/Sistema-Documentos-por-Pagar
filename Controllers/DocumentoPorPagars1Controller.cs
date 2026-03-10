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
    public class DocumentoPorPagars1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DocumentoPorPagars1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DocumentoPorPagars1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentoPorPagar>>> GetDocumentosPorPagar()
        {
            return await _context.DocumentosPorPagar.ToListAsync();
        }

        // GET: api/DocumentoPorPagars1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentoPorPagar>> GetDocumentoPorPagar(int id)
        {
            var documentoPorPagar = await _context.DocumentosPorPagar.FindAsync(id);

            if (documentoPorPagar == null)
            {
                return NotFound();
            }

            return documentoPorPagar;
        }

        // PUT: api/DocumentoPorPagars1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentoPorPagar(int id, DocumentoPorPagar documentoPorPagar)
        {
            if (id != documentoPorPagar.IdDocumento)
            {
                return BadRequest();
            }

            _context.Entry(documentoPorPagar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentoPorPagarExists(id))
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

        // POST: api/DocumentoPorPagars1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DocumentoPorPagar>> PostDocumentoPorPagar(DocumentoPorPagar documentoPorPagar)
        {
            _context.DocumentosPorPagar.Add(documentoPorPagar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocumentoPorPagar", new { id = documentoPorPagar.IdDocumento }, documentoPorPagar);
        }

        // DELETE: api/DocumentoPorPagars1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentoPorPagar(int id)
        {
            var documentoPorPagar = await _context.DocumentosPorPagar.FindAsync(id);
            if (documentoPorPagar == null)
            {
                return NotFound();
            }

            _context.DocumentosPorPagar.Remove(documentoPorPagar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocumentoPorPagarExists(int id)
        {
            return _context.DocumentosPorPagar.Any(e => e.IdDocumento == id);
        }
    }
}
