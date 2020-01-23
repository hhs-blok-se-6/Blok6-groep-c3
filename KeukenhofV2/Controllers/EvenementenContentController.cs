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
    public class EvenementenContentController : Controller
    {
        private readonly KeukenhofContext _context;

        public EvenementenContentController(KeukenhofContext context)
        {
            _context = context;
        }

        // GET: EvenementenContent
        public async Task<IActionResult> Index()
        {
            return View(await _context.EvenementenContent.ToListAsync());
        }

        // GET: EvenementenContent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evenementenContent = await _context.EvenementenContent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evenementenContent == null)
            {
                return NotFound();
            }

            return View(evenementenContent);
        }

      
        // GET: EvenementenContent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evenementenContent = await _context.EvenementenContent.FindAsync(id);
            if (evenementenContent == null)
            {
                return NotFound();
            }
            return View(evenementenContent);
        }

        // POST: EvenementenContent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Content")] EvenementenContent evenementenContent)
        {
            if (id != evenementenContent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evenementenContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvenementenContentExists(evenementenContent.Id))
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
            return View(evenementenContent);
        }
        

        private bool EvenementenContentExists(int id)
        {
            return _context.EvenementenContent.Any(e => e.Id == id);
        }
    }
}
