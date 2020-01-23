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
    public class HomeContentController : Controller
    {
        private readonly KeukenhofContext _context;

        public HomeContentController(KeukenhofContext context)
        {
            _context = context;
        }

        // GET: HomeContents
        public async Task<IActionResult> Index()
        {
            return View(await _context.HomeContent.ToListAsync());
        }

        // GET: HomeContents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeContent = await _context.HomeContent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeContent == null)
            {
                return NotFound();
            }

            return View(homeContent);
        }

        // GET: HomeContents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeContent = await _context.HomeContent.FindAsync(id);
            if (homeContent == null)
            {
                return NotFound();
            }
            return View(homeContent);
        }

        // POST: HomeContents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Content")] HomeContent homeContent)
        {
            if (id != homeContent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homeContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeContentExists(homeContent.Id))
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
            return View(homeContent);
        }


        private bool HomeContentExists(int id)
        {
            return _context.HomeContent.Any(e => e.Id == id);
        }
    }
}
