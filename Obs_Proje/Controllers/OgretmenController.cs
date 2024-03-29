﻿using System;
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
            var oBSContext = _context.Ogretmenler
                .Include(o => o.Adres)
                .Include(o => o.Bolum)
                .Include(o => o.Dersler)
                .ToListAsync();

            var viewData = from Ogretmen in await oBSContext
                           select new OgretmenViewModel()
                           {
                               Id = Ogretmen.Id,
                               Adi = Ogretmen.Adi,
                               Soyadi = Ogretmen.Soyadi,
                               SicilNo = Ogretmen.SicilNo,
                               BolumAdi = Ogretmen.Bolum.Adi,
                               VerdigiDersler = String.Join(" , ", Ogretmen.Dersler.Select(ders => ders.Adi))
                           };

            var OgretmenSayisi = _context.Ogretmenler.Count();
            ViewBag.OgretmenSayisi = OgretmenSayisi;

            return View(viewData);  
            //return View(await oBSContext.ToListAsync());
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
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "Id", "Adi");
            return View();
        }

        // POST: Ogretmen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ogretmen ogretmen)
        {
            //[Bind("Adi,Soyadi,SicilNo,BolumId,AdresId,Id")]
            if (ModelState.IsValid)
            {
                _context.Add(ogretmen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdresId"] = new SelectList(_context.Adresler, "Id", "Id", ogretmen.AdresId);
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "Id", "Adi", ogretmen.BolumId, ogretmen.Bolum.Adi);
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

        public IActionResult DersEkle(int id)
        {
            var ogretmen = _context.Ogretmenler
                .Include(it => it.Dersler)
                .FirstOrDefault(m => m.Id == id);

            if (ogretmen != null)
            {
                var ogretmenDers = new OgretmenDersEkleModel();
                ogretmenDers.TamAdi = ogretmen.Adi + " " + ogretmen.Soyadi;
                ogretmenDers.Dersler = ogretmen.Dersler.ToList();

                ViewData["DersId"] = new SelectList(_context.Dersler.Where(x => x.BolumId == ogretmen.BolumId), "Id", "Adi");
                return View(ogretmenDers);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult DersEkle(int id, int dersId)
        {
            var ogretmen = _context.Ogretmenler
                 .Include(it => it.Dersler)
                 .FirstOrDefault(m => m.Id == id);

            if (ogretmen != null)
            {
                if (ogretmen.Dersler.Any(d => d.Id == dersId))
                {
                    TempData["UyariMesaji"] = "Bu ders zaten öğrenciye eklenmiş.";
                    //ViewBag.UyariMesaji = "Bu ders zaten öğrenciye eklenmiş.";
                    return RedirectToAction("DersEkle", new { id });
                }

                var ogretmenDers = new OgretmenDersEkleModel();
                ogretmenDers.TamAdi = ogretmen.Adi + " " + ogretmen.Soyadi;
                var ders = _context.Dersler.Find(dersId);

                ogretmen.Dersler.Add(ders);
                _context.SaveChanges();

                ogretmenDers.Dersler = ogretmen.Dersler.ToList();

                ViewData["DersId"] = new SelectList(_context.Dersler.Where(x => x.BolumId == ogretmen.BolumId), "Id", "Adi");
                TempData["BasariliMesaji"] = "Ders ekleme işlemi başarıyla gerçekleştirildi.";
                return View(ogretmenDers);
            }
            else
                return NotFound();  
        }

        private bool OgretmenExists(int id)
        {
          return _context.Ogretmenler.Any(e => e.Id == id);
        }
    }
}
