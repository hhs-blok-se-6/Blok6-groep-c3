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
    public class BereikbaarheidContentController : Controller
    {
        private readonly KeukenhofContext _context;

        public BereikbaarheidContentController(KeukenhofContext context)
        {
            _context = context;
        }

        // GET: BereikbaarheidContent
        public async Task<IActionResult> Index()
        {
            return View(await _context.BereikbaarheidContent.ToListAsync());
        }

        // GET: BereikbaarheidContent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bereikbaarheidContent = await _context.BereikbaarheidContent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bereikbaarheidContent == null)
            {
                return NotFound();
            }

            return View(bereikbaarheidContent);
        }

        // GET: BereikbaarheidContent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bereikbaarheidContent = await _context.BereikbaarheidContent.FindAsync(id);
            if (bereikbaarheidContent == null)
            {
                return NotFound();
            }
            return View(bereikbaarheidContent);
        }

        // POST: BereikbaarheidContent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Content")] BereikbaarheidContent bereikbaarheidContent)
        {
            if (id != bereikbaarheidContent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bereikbaarheidContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BereikbaarheidContentExists(bereikbaarheidContent.Id))
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
            return View(bereikbaarheidContent);
        }

        private bool BereikbaarheidContentExists(int id)
        {
            return _context.BereikbaarheidContent.Any(e => e.Id == id);
        }
    }
}
