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
    [Autorize]
    public class PraktischContentController : Controller
    {
        private readonly KeukenhofContext _context;

        public PraktischContentController(KeukenhofContext context)
        {
            _context = context;
        }

        // GET: PraktischContent
        public async Task<IActionResult> Index()
        {
            return View(await _context.PraktischContent.ToListAsync());
        }

        // GET: PraktischContent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var praktischContent = await _context.PraktischContent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (praktischContent == null)
            {
                return NotFound();
            }

            return View(praktischContent);
        }


        // GET: PraktischContent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var praktischContent = await _context.PraktischContent.FindAsync(id);
            if (praktischContent == null)
            {
                return NotFound();
            }
            return View(praktischContent);
        }

        // POST: PraktischContent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Content")] PraktischContent praktischContent)
        {
            if (id != praktischContent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(praktischContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PraktischContentExists(praktischContent.Id))
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
            return View(praktischContent);
        }

      


        private bool PraktischContentExists(int id)
        {
            return _context.PraktischContent.Any(e => e.Id == id);
        }
    }
}
