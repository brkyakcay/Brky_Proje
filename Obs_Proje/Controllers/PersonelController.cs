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
    public class PersonelController : Controller
    {
        private readonly OBSContext _context;

        public PersonelController(OBSContext context)
        {
            _context = context;
        }

        // GET: Personel
        public async Task<IActionResult> Index()
        {
              return View(await _context.PersonelViewModel.ToListAsync());
        }

        // GET: Personel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PersonelViewModel == null)
            {
                return NotFound();
            }

            var personelViewModel = await _context.PersonelViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personelViewModel == null)
            {
                return NotFound();
            }

            return View(personelViewModel);
        }

        // GET: Personel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adi,Soyadı,SicilNo,DepartmanAdi")] PersonelViewModel personelViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personelViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personelViewModel);
        }

        // GET: Personel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PersonelViewModel == null)
            {
                return NotFound();
            }

            var personelViewModel = await _context.PersonelViewModel.FindAsync(id);
            if (personelViewModel == null)
            {
                return NotFound();
            }
            return View(personelViewModel);
        }

        // POST: Personel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adi,Soyadı,SicilNo,DepartmanAdi")] PersonelViewModel personelViewModel)
        {
            if (id != personelViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personelViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonelViewModelExists(personelViewModel.Id))
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
            return View(personelViewModel);
        }

        // GET: Personel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PersonelViewModel == null)
            {
                return NotFound();
            }

            var personelViewModel = await _context.PersonelViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personelViewModel == null)
            {
                return NotFound();
            }

            return View(personelViewModel);
        }

        // POST: Personel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PersonelViewModel == null)
            {
                return Problem("Entity set 'OBSContext.PersonelViewModel'  is null.");
            }
            var personelViewModel = await _context.PersonelViewModel.FindAsync(id);
            if (personelViewModel != null)
            {
                _context.PersonelViewModel.Remove(personelViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonelViewModelExists(int id)
        {
          return _context.PersonelViewModel.Any(e => e.Id == id);
        }
    }
}
