using KeukenhofV2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofV2.Controllers
{

    public class EvenementenController : Controller
    {
        private readonly KeukenhofContext _context;

        public EvenementenController(KeukenhofContext context)
        {
            _context = context;
        }

        [Route("/Evenementen")]
        public async Task<IActionResult> Evenementen()
        {
            var evenementen = from ec in _context.Evenementen select ec;

            return View("Evenementen", await evenementen.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> BloemenFestival()
        {
            var evenementenContent = from ec in _context.EvenementenContent select ec;

            return View("Evenementenpaginas/BloemenFestival", await evenementenContent.AsNoTracking().ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Edit()
        {
            var evenementContent = from hc in _context.EvenementenContent select hc;

            return View("EditEvenementen", await evenementContent.AsNoTracking().ToListAsync());
        }

    }
}