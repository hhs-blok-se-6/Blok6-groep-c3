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
    public class ContactController : Controller
    {

        private readonly KeukenhofContext _context;

        public ContactController(KeukenhofContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Edit()
        {
            var contactContent = from bc in _context.ContactContent select bc;

            return View("EditContact", await contactContent.AsNoTracking().ToListAsync());
        }


    }
}