using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.WebApp.Data.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BookStore.WebApp.Models;

namespace BookStore.WebApp.Controllers
{
    public class AddressesController : Controller
    {
        private readonly BookStoreContext _context;

        public AddressesController(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var bookStoreContext = from adr in _context.Addresses.Include(a => a.City).Include(a => a.Publisher)
                                   select new AddressViewModel
                                   {
                                       Id = adr.Id,
                                       Name = adr.Name,
                                       Description = adr.Description,
                                       City = adr.City.Name,
                                       Publisher = adr.Publisher.Name
                                   };
            return View(await bookStoreContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Addresses == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(a => a.City)
                .Include(a => a.Publisher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Set<City>(), "Id", "DisplayName");
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Add(address);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var validationErrors = ModelState.Values.Where(E => E.Errors.Count > 0)
                   .SelectMany(E => E.Errors)
                   .Select(E => E.ErrorMessage)
                   .ToList();
                foreach (var item in validationErrors)
                {
                    ModelState.AddModelError("", item);
                }
            }
            ViewData["CityId"] = new SelectList(_context.Set<City>(), "Id", "DisplayName", address.CityId);
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name", address.PublisherId);
            return View(address);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Addresses == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Set<City>(), "Id", "Name", address.CityId);
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name", address.PublisherId);
            return View(address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Address address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.Id))
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
            ViewData["CityId"] = new SelectList(_context.Set<City>(), "Id", "Name", address.CityId);
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name", address.PublisherId);
            return View(address);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Addresses == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(a => a.City)
                .Include(a => a.Publisher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Addresses == null)
            {
                return Problem("Entity set 'BookStoreContext.Addresses'  is null.");
            }
            var address = await _context.Addresses.FindAsync(id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(int id)
        {
            return (_context.Addresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
