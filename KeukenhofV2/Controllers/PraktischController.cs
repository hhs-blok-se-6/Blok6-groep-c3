using KeukenhofV2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofV2.Controllers
{
    public class PraktischController : Controller
    {
        private readonly KeukenhofContext _context;

        public PraktischController(KeukenhofContext context)
        {
            _context = context;
        }
        [Route("/Praktisch")]
        [Route("/Praktisch/Index")]
        public async Task<IActionResult> Praktisch()
        {
            var PraktischContent = from pc in _context.PraktischContent select pc;

            return View("Praktisch", await PraktischContent.AsNoTracking().ToListAsync());
        }

        [Authorize]
        [Route("/Praktisch/Edit")]
        public async Task<IActionResult> Edit()
        {
            var PraktischContent = from pc in _context.PraktischContent select pc;

            return View("EditPraktisch", await PraktischContent.AsNoTracking().ToListAsync());
        }


        public async Task<IActionResult> Toegankelijkheid()
        {
            var ToegankelijkheidContent = from tc in _context.ToegankelijkheidContent select tc;

            return View("Praktischepaginas/Toegankelijkheid", await ToegankelijkheidContent.AsNoTracking().ToListAsync());
        }

        [Authorize]
        [Route("/Toegankelijkheid/Edit")]
        public async Task<IActionResult> ToegankelijkheidEdit()
        {
            var toegankelijkheidContent = from hc in _context.ToegankelijkheidContent select hc;

            return View("Praktischepaginas/EditToegankelijkheid", await toegankelijkheidContent.AsNoTracking().ToListAsync());
        }
    }
}