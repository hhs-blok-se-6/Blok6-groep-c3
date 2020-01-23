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
    public class ToegankelijkheidContentController : Controller
    {
        private readonly KeukenhofContext _context;

        public ToegankelijkheidContentController(KeukenhofContext context)
        {
            _context = context;
        }

        // GET: ToegankelijkheidContent
      
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToegankelijkheidContent.ToListAsync());
        }

        // GET: ToegankelijkheidContent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toegankelijkheidContent = await _context.ToegankelijkheidContent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toegankelijkheidContent == null)
            {
                return NotFound();
            }

            return View(toegankelijkheidContent);
        }




        // GET: ToegankelijkheidContent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toegankelijkheidContent = await _context.ToegankelijkheidContent.FindAsync(id);
            if (toegankelijkheidContent == null)
            {
                return NotFound();
            }
            return View(toegankelijkheidContent);
        }

        // POST: ToegankelijkheidContent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Content")] ToegankelijkheidContent toegankelijkheidContent)
        {
            if (id != toegankelijkheidContent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toegankelijkheidContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToegankelijkheidContentExists(toegankelijkheidContent.Id))
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
            return View(toegankelijkheidContent);
        }



        private bool ToegankelijkheidContentExists(int id)
        {
            return _context.ToegankelijkheidContent.Any(e => e.Id == id);
        }
    }
}
