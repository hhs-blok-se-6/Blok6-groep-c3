using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KeukenhofV2.Data;
using KeukenhofV2.Models;
using Microsoft.AspNetCore.Authorization;

namespace KeukenhofV2.Controllers
{
    [Authorize]
    public class VeelgesteldeVragenContentController : Controller
    {
        private readonly KeukenhofContext _context;

        public VeelgesteldeVragenContentController(KeukenhofContext context)
        {
            _context = context;
        }

        // GET: VeelgesteldeVragenContent
        public async Task<IActionResult> Index()
        {
            return View(await _context.VeelgesteldeVragen.ToListAsync());
        }

        // GET: VeelgesteldeVragenContent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veelgesteldeVragen = await _context.VeelgesteldeVragen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veelgesteldeVragen == null)
            {
                return NotFound();
            }

            return View(veelgesteldeVragen);
        }

       

        // GET: VeelgesteldeVragenContent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veelgesteldeVragen = await _context.VeelgesteldeVragen.FindAsync(id);
            if (veelgesteldeVragen == null)
            {
                return NotFound();
            }
            return View(veelgesteldeVragen);
        }

        // POST: VeelgesteldeVragenContent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Content")] VeelgesteldeVragen veelgesteldeVragen)
        {
            if (id != veelgesteldeVragen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veelgesteldeVragen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeelgesteldeVragenExists(veelgesteldeVragen.Id))
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
            return View(veelgesteldeVragen);
        }

        private bool VeelgesteldeVragenExists(int id)
        {
            return _context.VeelgesteldeVragen.Any(e => e.Id == id);
        }
    }
}
