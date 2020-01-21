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
    public class ParkController : Controller
    {

        private readonly KeukenhofContext _context;

        public ParkController(KeukenhofContext context)
        {
            _context = context;
        }

        [Route("/Park")]
        public IActionResult Park()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Edit()
        {
            var evenementContent = from pc in _context.EvenementenContent select pc;

            return View("EditPark", await evenementContent.AsNoTracking().ToListAsync());
        }

    }
}