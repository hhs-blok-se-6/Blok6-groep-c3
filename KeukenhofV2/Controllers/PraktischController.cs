using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeukenhofV2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeukenhofV2.Controllers
{
    public class PraktischController : Controller
    {
        private readonly KeukenhofContext _context;

        public PraktischController(KeukenhofContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Toegankelijkheid()
        {
            var toegankelijkheidContents = from tc in _context.EvenementenContent select tc;

            return View("Toegankelijkheid", await toegankelijkheidContents.AsNoTracking().ToListAsync());
        }
    }
}