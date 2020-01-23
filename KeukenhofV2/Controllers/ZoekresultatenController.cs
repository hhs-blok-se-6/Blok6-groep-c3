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

        
        /*
        // GET: ZoekResultaten
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZoekResultaten.ToListAsync());
        }
        */
        [Route("/Zoekresultaten")]
        public async Task<IActionResult> Index(string searchVal)
        {
            
            if (searchVal == null)
            {
                var collection = await _context.ZoekResultaten.ToListAsync();
                return View(collection);
            }
            else
            {

                ViewData["SearchVal"] = searchVal;

                var result = await _context.ZoekResultaten.Where(w => w.Content.Contains(searchVal)).ToListAsync();

                return View(result);
            }

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
