using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KeukenhofV2.Data;
using KeukenhofV2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace KeukenhofV2.Controllers
{
    public class PraktischController : Controller
    {
        private readonly KeukenhofContext _context;

        public PraktischController(KeukenhofContext context)
        {
            _context = context;
        }

        [Route("/Toegankelijkheid")]
        public async Task<IActionResult> Toegankelijkheid()
        {
            var toegankelijkheidContent = from tc in _context.ToegankelijkheidContent select tc;

            return View("Praktischepaginas/Toegankelijkheid", await toegankelijkheidContent.AsNoTracking().ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Edit()
        {
            var toegankelijkheidContent = from hc in _context.ToegankelijkheidContent select hc;

            return View("EditPraktisch", await toegankelijkheidContent.AsNoTracking().ToListAsync());
        }
    }
}