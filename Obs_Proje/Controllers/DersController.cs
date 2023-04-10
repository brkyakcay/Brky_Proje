using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Obs_Proje.Data;

namespace Obs_Proje.Controllers
{
    public class DersController : Controller
    {
        private readonly OBSContext _context;

        public DersController(OBSContext context)
        {
            _context = context;
        }

        // GET: Ders
        public async Task<IActionResult> Index()
        {
            var oBSContext = _context.Dersler.Include(d => d.Bolum).Include(d => d.Ogretmen);
            return View(await oBSContext.ToListAsync());
        }

        // GET: Ders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dersler == null)
            {
                return NotFound();
            }

            var ders = await _context.Dersler
                .Include(d => d.Bolum)
                .Include(d => d.Ogretmen)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ders == null)
            {
                return NotFound();
            }

            return View(ders);
        }

        // GET: Ders/Create
        public IActionResult Create()
        {
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "Id", "Id");
            ViewData["OgretmenId"] = new SelectList(_context.Ogretmenler, "Id", "Id");
            return View();
        }

        // POST: Ders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Adi,BolumId,OgretmenId,Id")] Ders ders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "Id", "Id", ders.BolumId);
            ViewData["OgretmenId"] = new SelectList(_context.Ogretmenler, "Id", "Id", ders.OgretmenId);
            return View(ders);
        }

        // GET: Ders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dersler == null)
            {
                return NotFound();
            }

            var ders = await _context.Dersler.FindAsync(id);
            if (ders == null)
            {
                return NotFound();
            }
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "Id", "Id", ders.BolumId);
            ViewData["OgretmenId"] = new SelectList(_context.Ogretmenler, "Id", "Id", ders.OgretmenId);
            return View(ders);
        }

        // POST: Ders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Adi,BolumId,OgretmenId,Id")] Ders ders)
        {
            if (id != ders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DersExists(ders.Id))
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
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "Id", "Id", ders.BolumId);
            ViewData["OgretmenId"] = new SelectList(_context.Ogretmenler, "Id", "Id", ders.OgretmenId);
            return View(ders);
        }

        // GET: Ders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dersler == null)
            {
                return NotFound();
            }

            var ders = await _context.Dersler
                .Include(d => d.Bolum)
                .Include(d => d.Ogretmen)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ders == null)
            {
                return NotFound();
            }

            return View(ders);
        }

        // POST: Ders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dersler == null)
            {
                return Problem("Entity set 'OBSContext.Dersler'  is null.");
            }
            var ders = await _context.Dersler.FindAsync(id);
            if (ders != null)
            {
                _context.Dersler.Remove(ders);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DersExists(int id)
        {
          return _context.Dersler.Any(e => e.Id == id);
        }
    }
}
