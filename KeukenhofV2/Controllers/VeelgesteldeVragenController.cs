using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeukenhofV2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeukenhofV2.Controllers
{
    public class VeelgesteldeVragenController : Controller
    {
        private readonly KeukenhofContext _context;

        public VeelgesteldeVragenController(KeukenhofContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> VeelgesteldeVragen()
        {
            var veelgesteldevragenContent = from vc in _context.VeelgesteldeVragen select vc;
            return View("VeelgesteldeVragen", await veelgesteldevragenContent.AsNoTracking().ToListAsync());
        }
    }
}