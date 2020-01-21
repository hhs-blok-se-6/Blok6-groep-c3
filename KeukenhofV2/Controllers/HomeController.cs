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
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public async Task<IActionResult> Home()
        {
            var homeContent = from hc in _context.HomeContent select hc;
            
            

            return View(await homeContent.AsNoTracking().ToListAsync());
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
