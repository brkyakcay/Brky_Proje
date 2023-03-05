using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Obs_Proje.Data;
using Obs_Proje.Models;

namespace Obs_Proje.Controllers
{
    public class OgrencilerController : Controller
    {
        private readonly OBSContext _context;

        public OgrencilerController(OBSContext context)
        {
            _context = context;
        }

        // GET: Ogrenciler
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Ogrenciler.ToListAsync());

            var data = await _context.Ogrenciler
                .Include(x => x.Bolum)
                .Include(x => x.Dersler)
                .ToListAsync();

            var viewData = from ogrenci in data
                           select new OgrenciViewModel()
                           {
                               Id = ogrenci.Id,
                               AdiSoyadi = ogrenci.Adi + " " + ogrenci.Soyadi,
                               OkulNo = ogrenci.OkulNo,
                               BolumAdi = ogrenci.Bolum.Adi,
                               DersSayisi=ogrenci.Dersler.Count(),
                               Dersleri= String.Join(", ", ogrenci.Dersler.Select(ders=>ders.Adi))
                           };

            return View(viewData);
        }

        // GET: Ogrenciler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ogrenciler == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenciler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogrenci == null)
            {
                return NotFound();
            }

            return View(ogrenci);
        }

        // GET: Ogrenciler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ogrenciler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Adi,Soyadi,OkulNo,Id")] Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogrenci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ogrenci);
        }

        // GET: Ogrenciler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ogrenciler == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);
        }

        // POST: Ogrenciler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Adi,Soyadi,OkulNo,Id")] Ogrenci ogrenci)
        {
            if (id != ogrenci.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogrenci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OgrenciExists(ogrenci.Id))
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
            return View(ogrenci);
        }

        // GET: Ogrenciler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ogrenciler == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenciler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogrenci == null)
            {
                return NotFound();
            }

            return View(ogrenci);
        }

        // POST: Ogrenciler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ogrenciler == null)
            {
                return Problem("Entity set 'OBSContext.Ogrenciler'  is null.");
            }
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if (ogrenci != null)
            {
                _context.Ogrenciler.Remove(ogrenci);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OgrenciExists(int id)
        {
          return _context.Ogrenciler.Any(e => e.Id == id);
        }
    }
}
