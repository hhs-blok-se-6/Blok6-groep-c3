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
    public class BereikbaarheidController : Controller
    {
        private readonly KeukenhofContext _context;

        public BereikbaarheidController(KeukenhofContext context)
        {
            _context = context;
        }

        [Route("/Bereikbaarheid")]
        public async Task<IActionResult> Bereikbaarheid()
        {
            var BereikbaarheidContent = from bc in _context.BereikbaarheidContent select bc;

            return View("Bereikbaarheid", await BereikbaarheidContent.AsNoTracking().ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Edit()
        {
            var bereikbaarheidContent = from bc in _context.BereikbaarheidContent select bc;

            return View("EditBereikbaarheid", await bereikbaarheidContent.AsNoTracking().ToListAsync());
        }
    }
}