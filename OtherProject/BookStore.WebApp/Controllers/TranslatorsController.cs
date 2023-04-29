using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.WebApp.Data.Entities;
using BookStore.WebApp.Models;

namespace BookStore.WebApp.Controllers
{
    public class TranslatorsController : Controller
    {
        private readonly BookStoreContext _context;

        public TranslatorsController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: Translators
        public async Task<IActionResult> Index()
        {
            var bookStoreContext = from translator in _context.Translators.Include(x => x.Books)
                                   select new TranslatorViewModel()
                                   {
                                       Id = translator.Id,
                                       FullName = translator.FullName,
                                       BookCount = translator.Books.Count(),
                                       Email = translator.EMail
                                   };
            return View(await bookStoreContext.ToListAsync());
        }

        // GET: Translators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Translators == null)
            {
                return NotFound();
            }

            var translator = await _context.Translators
                .FirstOrDefaultAsync(m => m.Id == id);
            if (translator == null)
            {
                return NotFound();
            }

            return View(translator);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EMail,Name,MiddleName,Surname,Id,CreatedDate")] Translator translator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(translator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(translator);
        }

        // GET: Translators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Translators == null)
            {
                return NotFound();
            }

            var translator = await _context.Translators.FindAsync(id);
            if (translator == null)
            {
                return NotFound();
            }
            return View(translator);
        }

        // POST: Translators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EMail,Name,MiddleName,Surname,Id,CreatedDate")] Translator translator)
        {
            if (id != translator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(translator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TranslatorExists(translator.Id))
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
            return View(translator);
        }

        // GET: Translators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Translators == null)
            {
                return NotFound();
            }

            var translator = await _context.Translators
                .FirstOrDefaultAsync(m => m.Id == id);
            if (translator == null)
            {
                return NotFound();
            }

            return View(translator);
        }

        // POST: Translators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Translators == null)
            {
                return Problem("Entity set 'BookStoreContext.Translators'  is null.");
            }
            var translator = await _context.Translators.FindAsync(id);
            if (translator != null)
            {
                _context.Translators.Remove(translator);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TranslatorExists(int id)
        {
          return _context.Translators.Any(e => e.Id == id);
        }
    }
}
