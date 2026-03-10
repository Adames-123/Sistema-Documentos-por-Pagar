using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Documentos_por_Pagar.Data;
using Sistema_Documentos_por_Pagar.Models;

namespace Sistema_Documentos_por_Pagar.Controllers
{
    public class ConceptosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConceptosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ConceptosPago.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Concepto concepto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(concepto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(concepto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var concepto = await _context.ConceptosPago.FindAsync(id);
            if (concepto == null) return NotFound();
            return View(concepto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Concepto concepto)
        {
            if (id != concepto.IdConcepto) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(concepto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(concepto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var concepto = await _context.ConceptosPago.FindAsync(id);
            if (concepto == null) return NotFound();

            _context.ConceptosPago.Remove(concepto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}