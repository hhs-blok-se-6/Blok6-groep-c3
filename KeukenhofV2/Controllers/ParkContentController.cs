using KeukenhofV2.Data;
using KeukenhofV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofV2.Controllers
{
    [Authorize]
    public class ParkContentController : Controller
    {
        private readonly KeukenhofContext _context;

        public ParkContentController(KeukenhofContext context)
        {
            _context = context;
        }

        // GET: ParkContent
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParkContent.ToListAsync());
        }

        // GET: ParkContent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkContent = await _context.ParkContent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkContent == null)
            {
                return NotFound();
            }

            return View(parkContent);
        }


        // GET: ParkContent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkContent = await _context.ParkContent.FindAsync(id);
            if (parkContent == null)
            {
                return NotFound();
            }
            return View(parkContent);
        }

        // POST: ParkContent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Content")] ParkContent parkContent)
        {
            if (id != parkContent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkContentExists(parkContent.Id))
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
            return View(parkContent);
        }


        private bool ParkContentExists(int id)
        {
            return _context.ParkContent.Any(e => e.Id == id);
        }
    }
}
