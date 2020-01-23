using KeukenhofV2.Data;
using KeukenhofV2.ViewModel;
using KeukenhofV2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
