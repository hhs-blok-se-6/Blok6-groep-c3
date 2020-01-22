using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KeukenhofV2.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using KeukenhofV2.Data;
using Microsoft.EntityFrameworkCore;
using KeukenhofV2.ViewModel;
using KeukenhofV2.ViewModels;

namespace KeukenhofV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly KeukenhofContext _context;

        public HomeController(KeukenhofContext context)
        {
            _context = context;
        }

        public IActionResult Migrate()
        {
            try
            {
                _context.Database.Migrate();
                return RedirectToAction("Home");
            }
            catch (Exception e)
            {
                return RedirectToAction("Foutmelding", new { message = e.Message });
            }
        }

        public IActionResult Foutmelding(string message)
        {
            ViewData["message"] = message;
            return View();
        }

        public IActionResult Home()
        {
            var homeContent = from hc in _context.HomeContent select hc;
            var featuredContent = from fc in _context.FeaturedContent where fc.Page.Equals("Home") select fc;
            var cardContent = from cc in _context.CardContent where cc.Page.Equals("Home") select cc;
            var praktisch = from p in _context.FAQ where p.Page.Equals("Home") select p;

            MiniFaqViewModel pvm = new MiniFaqViewModel()
            {
                Image = "/images/P01Home/Map.png",
                FAQ = praktisch,
                ButtonText = "Download de kaart",
                Theme = "green"
            };

            HomeViewModel cvm = new HomeViewModel()
            {
                HomeContent = homeContent,
                FeaturedContent = featuredContent,
                FeatureRows = 1,
                FeatureColumns = 4,
                CardContent = cardContent,
                CardRows = 1,
                CardColumns = 4,
                MiniFaq = pvm
            };

            return View(cvm);
        }

        [Authorize]
        public async Task<IActionResult> Edit()
        {
            var homeContent = from hc in _context.HomeContent select hc;

            return View("EditHome", await homeContent.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public IActionResult Zoekresultaten(string trefwoord)
        {
            ViewData["trefwoord"] = trefwoord;
            return View();
        }

        public IActionResult Park()
        {
            return RedirectToAction("Index", "Park");
        }

        public IActionResult Login()
        {
            return RedirectToAction("Index", "Login");
        }

        public IActionResult Evenementen()
        {
            return RedirectToAction("Index", "Evenementen");
        }

        public IActionResult Contentpagina()
        {
            return RedirectToAction("Index", "Content");
        }

        public IActionResult Praktisch()
        {
            return RedirectToAction("Index", "Praktisch");
        }

        public IActionResult Bereikbaarheid()
        {
            return RedirectToAction("Index", "Bereikbaarheid");
        }

        public IActionResult VeelgesteldeVragen()
        {
            return RedirectToAction("Index", "VeelgesteldeVragen");
        }

        public IActionResult Contact()
        {
            return RedirectToAction("Index", "Contact");
        }

        public IActionResult Privacy()
        {
            return RedirectToAction("Index", "Privacy");
        }

        public String HomeContent()
        {

            using (var context = _context)
            {
                HomeContent homeContent = new HomeContent
                {


                    Type = "h4",
                    Content = "Kom vandaag nog langs"
                };
                HomeContent homeContent2 = new HomeContent
                {


                    Type = "h4",
                    Content = "Kom vandaag nog langs"
                };


                context.HomeContent.Add(homeContent);
                context.SaveChanges();
            }


            //var homeContent = from s in _context.HomeContent select s;

            //return View(await homeContent.AsNoTracking().ToListAsync());


            return "Gelukt!";
        }
    }
}
