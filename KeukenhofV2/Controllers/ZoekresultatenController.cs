using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KeukenhofV2.Data;
using KeukenhofV2.Models;

namespace KeukenhofV2.Controllers
{
    public class ZoekResultatenController : Controller
    {
        private readonly KeukenhofContext _context;

        public ZoekResultatenController(KeukenhofContext context)
        {
            _context = context;
        }

        private IQueryable<ZoekResultaten> GetLijst()
        {
            return _context.ZoekResultaten;
        }

        public IQueryable<ZoekResultaten> Filter(IQueryable<ZoekResultaten> lijst, string searchVal)
        {
            ViewData["CurrentFilter"] = searchVal;
            if (!String.IsNullOrEmpty(searchVal))
            {
                lijst = lijst.Where(s => s.Content.ToLower().Contains(searchVal.ToLower()) 
                || s.Location.ToLower().Contains(searchVal.ToLower()));

                
            }

            return lijst;

        }


        public async Task<IActionResult> Index(string searchVal)
        {
            //Oude versie, met zoek functionaliteit zoals ik die had bedacht
            //Nieuw versie (van Karel) is stukken beter

            if (searchVal == null)
            {
                var collection = await _context.ZoekResultaten.ToListAsync();
                return View(collection);
            }
            else
            {

                ViewData["SearchVal"] = searchVal;

               // var result = await _context.ZoekResultaten.Where(w => w.Content.Contains(searchVal)).ToListAsync();


                var result = from item in _context.ZoekResultaten
                             where (item.Content.ToLower().Contains(searchVal.ToLower()))
                             && (item.Location.ToLower().Contains(searchVal.ToLower()))
                             select item;
                //var result = await item from _context.ZoekResultaten.Where(w => w.Content.Contains(searchVal)).ToListAsync();

                return View(await result.AsNoTracking().ToListAsync());
            }

        }

       
        [Route("/Zoekresultaten")]
       
        [Route("/Zoekresultaten/Index")]
        public async Task<IActionResult> Zoekresultaten(string newSearchVal, string searchVal, 
                                                            int? pagina)
        {

            if (String.IsNullOrEmpty(newSearchVal))
                newSearchVal = searchVal;

            else
                pagina = 1;

            IQueryable<ZoekResultaten> lijst = GetLijst();
            lijst = Filter(lijst, newSearchVal);
            int counter = 0; 
            foreach(var item in lijst)
            {
                if(item.Type == "h1" || item.Type == "h2" ||
              item.Type == "h3" || item.Type == "h4" ||
              item.Type == "h5" || item.Type == "p" ||
              item.Type == "label")
                {
                    counter++;
                }
            }
            ViewData["Counter"] = counter + " zoekresultaten";

            return View(await Paging(lijst, pagina));
        }

        private async Task<PaginatedList<ZoekResultaten>> Paging(IQueryable<ZoekResultaten> lijst, int? pagina)
        {
            pagina = pagina ?? 1;
            ViewData["CurrentPage"] = pagina;
            int aantalItemsPerPagina = 8;
            return await PaginatedList<ZoekResultaten>.CreateAsync(lijst.AsNoTracking(), (int)pagina, aantalItemsPerPagina);
        }

        // GET: ZoekResultaten/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoekResultaten = await _context.ZoekResultaten
                .FirstOrDefaultAsync(m => m.Sid == id);
            if (zoekResultaten == null)
            {
                return NotFound();
            }

            return View(zoekResultaten);
        }

        // GET: ZoekResultaten/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZoekResultaten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sid,Id,Type,Content,Location")] ZoekResultaten zoekResultaten)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zoekResultaten);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zoekResultaten);
        }

        // GET: ZoekResultaten/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoekResultaten = await _context.ZoekResultaten.FindAsync(id);
            if (zoekResultaten == null)
            {
                return NotFound();
            }
            return View(zoekResultaten);
        }

        // POST: ZoekResultaten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Sid,Id,Type,Content,Location")] ZoekResultaten zoekResultaten)
        {
            if (id != zoekResultaten.Sid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zoekResultaten);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZoekResultatenExists(zoekResultaten.Sid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(zoekResultaten);
        }

        // GET: ZoekResultaten/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoekResultaten = await _context.ZoekResultaten
                .FirstOrDefaultAsync(m => m.Sid == id);
            if (zoekResultaten == null)
            {
                return NotFound();
            }

            return View(zoekResultaten);
        }

        // POST: ZoekResultaten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var zoekResultaten = await _context.ZoekResultaten.FindAsync(id);
            _context.ZoekResultaten.Remove(zoekResultaten);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZoekResultatenExists(string id)
        {
            return _context.ZoekResultaten.Any(e => e.Sid == id);
        }
    }
}
