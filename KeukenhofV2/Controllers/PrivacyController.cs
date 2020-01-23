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
    public class PrivacyController : Controller
    {

        private readonly KeukenhofContext _context;

        public PrivacyController(KeukenhofContext context)
        {
            _context = context;
        }

        [Route("/Privacy")]
        [Route("/Privacy/Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Edit()
        {
            var privacyContent = from pc in _context.PrivacyContent select pc;

            return View("EditPrivacy", await privacyContent.AsNoTracking().ToListAsync());
        }
    }
}