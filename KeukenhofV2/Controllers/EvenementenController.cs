using KeukenhofV2.Data;
using KeukenhofV2.Models;
using KeukenhofV2.ViewModel;
using KeukenhofV2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        private IQueryable<CardContent> GetLijst()
        {
            return from cc in _context.CardContent where cc.Page.Equals("Evenementen") select cc;
        }

        [Route("/Evenementen")]
        [Route("/Evenementen/Index")]
        public async Task<IActionResult> Evenementen()
        {
            var evenementenPaginaContent = from ec in _context.EvenementenPagina select ec;
            var evenementen = from evenementenList in _context.Evenementen select evenementenList;

            var model = new EvenementenPaginaViewModel { EvenementenPagina = await evenementenPaginaContent.AsNoTracking().ToListAsync(), Evenementen = await evenementen.AsNoTracking().ToListAsync() };

            return View("Evenementen", model);
        }

        public async Task<IActionResult> Evenementen(string newSearchVal, string searchVal, int? pagina)
        {

            if (String.IsNullOrEmpty(newSearchVal))
                newSearchVal = searchVal;

            else
                pagina = 1;
            var lijst = GetLijst();
            EvenementenViewModel epvm = new EvenementenViewModel()
            {
                evenementen = lijst,
                Rows = 2,
                Columns = 4
            };


            return View(await Paging(lijst, pagina));
        }

        private async Task<PaginatedList<CardContent>> Paging(IQueryable<CardContent> lijst, int? pagina)
        {
            pagina = pagina ?? 1;
            ViewData["CurrentPage"] = pagina;
            int aantalItemsPerPagina = 8;
            return await PaginatedList<CardContent>.CreateAsync(lijst.AsNoTracking(), (int)pagina, aantalItemsPerPagina);
        }

        public async Task<IActionResult> BloemenFestival()
        {
            var evenementenContent = from ec in _context.EvenementenContent select ec;

            return View("Evenementenpaginas/BloemenFestival", await evenementenContent.AsNoTracking().ToListAsync());
        }

        [Authorize]
        [Route("/Evenementen/Edit")]
        public async Task<IActionResult> Edit()
        {
            var evenementContent = from hc in _context.EvenementenContent select hc;

            return View("EditEvenementen", await evenementContent.AsNoTracking().ToListAsync());
        }
    }
}
