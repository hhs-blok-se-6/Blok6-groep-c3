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
    public class CardContentController : Controller
    {
        private readonly KeukenhofContext _context;

        public CardContentController(KeukenhofContext context)
        {
            _context = context;
        }

        // GET: CardContent
        public async Task<IActionResult> Index()
        {
            return View(await _context.CardContent.ToListAsync());
        }

        // GET: CardContent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardContent = await _context.CardContent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardContent == null)
            {
                return NotFound();
            }

            return View(cardContent);
        }



        // GET: CardContent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardContent = await _context.CardContent.FindAsync(id);
            if (cardContent == null)
            {
                return NotFound();
            }
            return View(cardContent);
        }

        // POST: CardContent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Page,Image,Tag,Date,Title,Button1,Link,Theme")] CardContent cardContent)
        {
            if (id != cardContent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardContentExists(cardContent.Id))
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
            return View(cardContent);
        }



        private bool CardContentExists(int id)
        {
            return _context.CardContent.Any(e => e.Id == id);
        }
    }
}
