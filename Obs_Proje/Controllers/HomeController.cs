﻿using Microsoft.AspNetCore.Mvc;
using Obs_Proje.Models;
using System.Diagnostics;

namespace Obs_Proje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var home = new HomePageModel
            //{
            //    OgrenciSayisi = ViewBag.OgrenciSayisi,  
            //    OgretmenSayisi  = ViewBag.OgretmenSayisi,   
            //    DersSayisi = ViewBag.DersSayisi,
            //    PersonelSayisi = ViewBag.PersonelSayisi,    
            //};
            return View();
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