using KeukenhofProject.ViewModels;
using KeukenhofV2.Data;
using KeukenhofV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofProject.Controllers
{
    public class EvenementenController : Controller
    {
        private readonly KeukenhofContext _context;

        public EvenementenController(KeukenhofContext context)
        {
            _context = context;
        }
        [Route("Evenementen")]
        public async Task<IActionResult> Evenementen()
        {
            var evenementenPaginaContent = from ec in _context.EvenementenPagina select ec;
            var evenementen = from evenementenList in _context.Evenementen select evenementenList;

            var model = new EvenementenPaginaViewModel { EvenementenPagina = await evenementenPaginaContent.AsNoTracking().ToListAsync(), Evenementen = await evenementen.AsNoTracking().ToListAsync() };

            return View("Evenementen", model);
        }

        public async Task<IActionResult> BloemenFestival()
        {
            var evenementenContent = from ec in _context.EvenementenContent select ec;

            return View("Evenementenpaginas/BloemenFestival", await evenementenContent.AsNoTracking().ToListAsync());
        }
    }
}
