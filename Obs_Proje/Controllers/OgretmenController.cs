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
    public class OgretmenController : Controller
    {
        private readonly OBSContext _context;

        public OgretmenController(OBSContext context)
        {
            _context = context;
        }

        // GET: Ogretmen
        public async Task<IActionResult> Index()
        {
            var oBSContext = _context.Ogretmenler.Include(o => o.Adres).Include(o => o.Bolum);
            return View(await oBSContext.ToListAsync());
        }

        // GET: Ogretmen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ogretmenler == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmenler
                .Include(o => o.Adres)
                .Include(o => o.Bolum)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogretmen == null)
            {
                return NotFound();
            }

            return View(ogretmen);
        }

        // GET: Ogretmen/Create
        public IActionResult Create()
        {
            ViewData["AdresId"] = new SelectList(_context.Adresler, "Id", "Id");
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "Id", "Id");
            return View();
        }

        // POST: Ogretmen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Adi,Soyadi,SicilNo,BolumId,AdresId,Id")] Ogretmen ogretmen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogretmen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdresId"] = new SelectList(_context.Adresler, "Id", "Id", ogretmen.AdresId);
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "Id", "Id", ogretmen.BolumId);
            return View(ogretmen);
        }

        // GET: Ogretmen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ogretmenler == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmenler.FindAsync(id);
            if (ogretmen == null)
            {
                return NotFound();
            }
            ViewData["AdresId"] = new SelectList(_context.Adresler, "Id", "Id", ogretmen.AdresId);
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "Id", "Id", ogretmen.BolumId);
            return View(ogretmen);
        }

        // POST: Ogretmen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Adi,Soyadi,SicilNo,BolumId,AdresId,Id")] Ogretmen ogretmen)
        {
            if (id != ogretmen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogretmen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OgretmenExists(ogretmen.Id))
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
            ViewData["AdresId"] = new SelectList(_context.Adresler, "Id", "Id", ogretmen.AdresId);
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "Id", "Id", ogretmen.BolumId);
            return View(ogretmen);
        }

        // GET: Ogretmen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ogretmenler == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmenler
                .Include(o => o.Adres)
                .Include(o => o.Bolum)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogretmen == null)
            {
                return NotFound();
            }

            return View(ogretmen);
        }

        // POST: Ogretmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ogretmenler == null)
            {
                return Problem("Entity set 'OBSContext.Ogretmenler'  is null.");
            }
            var ogretmen = await _context.Ogretmenler.FindAsync(id);
            if (ogretmen != null)
            {
                _context.Ogretmenler.Remove(ogretmen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OgretmenExists(int id)
        {
          return _context.Ogretmenler.Any(e => e.Id == id);
        }
    }
}
