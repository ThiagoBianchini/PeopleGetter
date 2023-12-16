using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeopleGetter.Data;
using PeopleGetter.Models;

namespace PeopleGetter.Controllers
{
    public class RoupasController : Controller
    {
        private readonly PeopleGetterContext _context;

        public RoupasController(PeopleGetterContext context)
        {
            _context = context;
        }

        // GET: Roupas
        public async Task<IActionResult> Index()
        {
              return _context.Roupas != null ? 
                          View(await _context.Roupas.ToListAsync()) :
                          Problem("Entity set 'PeopleGetterContext.Roupas'  is null.");
        }

        // GET: Roupas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Roupas == null)
            {
                return NotFound();
            }

            var roupas = await _context.Roupas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roupas == null)
            {
                return NotFound();
            }

            return View(roupas);
        }

        // GET: Roupas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roupas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nome,descricao,tamanho,valor,dataCriacao")] Roupas roupas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roupas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roupas);
        }

        // GET: Roupas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Roupas == null)
            {
                return NotFound();
            }

            var roupas = await _context.Roupas.FindAsync(id);
            if (roupas == null)
            {
                return NotFound();
            }
            return View(roupas);
        }

        // POST: Roupas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nome,descricao,tamanho,valor,dataCriacao")] Roupas roupas)
        {
            if (id != roupas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roupas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoupasExists(roupas.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(roupas);
        }

        // GET: Roupas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Roupas == null)
            {
                return NotFound();
            }

            var roupas = await _context.Roupas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roupas == null)
            {
                return NotFound();
            }

            return View(roupas);
        }

        // POST: Roupas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Roupas == null)
            {
                return Problem("Entity set 'PeopleGetterContext.Roupas'  is null.");
            }
            var roupas = await _context.Roupas.FindAsync(id);
            if (roupas != null)
            {
                _context.Roupas.Remove(roupas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoupasExists(int id)
        {
          return (_context.Roupas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
