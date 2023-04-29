using BookStore.WebApp.Data.Entities;
using BookStore.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BookStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookStoreContext _context;

        public HomeController(
            ILogger<HomeController> logger,
            BookStoreContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var lst_book = from bk in _context.Books
                       .Include(it => it.Author)
                       .Include(it => it.Translator)
                       .Include(it => it.Publisher)
                       .Include(it => it.Category)
                           select new BookItemViewModel()
                           {
                               Id = bk.Id,
                               Name = bk.Name,
                               PageCount = bk.PageCount,
                               AuthorName = bk.Author.FullName,
                               TranslatorName = bk.Translator.FullName,
                               PublisherName = bk.Publisher.Name,
                               Category = bk.Category.Name
                           };

            return View(lst_book);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}