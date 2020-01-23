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
    public class FeaturedContentController : Controller
    {
        private readonly KeukenhofContext _context;

        public FeaturedContentController(KeukenhofContext context)
        {
            _context = context;
        }

        // GET: FeaturedContent
        public async Task<IActionResult> Index()
        {
            return View(await _context.FeaturedContent.ToListAsync());
        }

        // GET: FeaturedContent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featuredContent = await _context.FeaturedContent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (featuredContent == null)
            {
                return NotFound();
            }

            return View(featuredContent);
        }


        // GET: FeaturedContent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featuredContent = await _context.FeaturedContent.FindAsync(id);
            if (featuredContent == null)
            {
                return NotFound();
            }
            return View(featuredContent);
        }

        // POST: FeaturedContent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Page,Image,Text,Link,Theme")] FeaturedContent featuredContent)
        {
            if (id != featuredContent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(featuredContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeaturedContentExists(featuredContent.Id))
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
            return View(featuredContent);
        }



        private bool FeaturedContentExists(int id)
        {
            return _context.FeaturedContent.Any(e => e.Id == id);
        }
    }
}
