using BookStore.WebApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApp.Controllers
{
    public class CampaignController : Controller
    {
        private readonly BookStoreContext _context;

        public CampaignController(BookStoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

