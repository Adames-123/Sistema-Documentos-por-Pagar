using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Documentos_por_Pagar.Data;
using Sistema_Documentos_por_Pagar.Models;

namespace Sistema_Documentos_por_Pagar.Controllers
{
    public class DocumentosPagarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentosPagarController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.DocumentosPagar.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DocumentoPorPagar documento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(documento);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var documento = await _context.DocumentosPagar.FindAsync(id);
            if (documento == null) return NotFound();
            return View(documento);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DocumentoPorPagar documento)
        {
            if (id != documento.IdDocumento) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(documento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(documento);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var documento = await _context.DocumentosPagar.FindAsync(id);
            if (documento == null) return NotFound();

            _context.DocumentosPagar.Remove(documento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}