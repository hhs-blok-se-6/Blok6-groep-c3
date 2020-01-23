using KeukenhofV2.Data;
using KeukenhofV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofV2.Controllers
{
    [Autorize]
    public class PrivacyContentController : Controller
    {
        private readonly KeukenhofContext _context;

        public PrivacyContentController(KeukenhofContext context)
        {
            _context = context;
        }

        // GET: PrivacyContent
        public async Task<IActionResult> Index()
        {
            return View(await _context.PrivacyContent.ToListAsync());
        }

        // GET: PrivacyContent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privacyContent = await _context.PrivacyContent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (privacyContent == null)
            {
                return NotFound();
            }

            return View(privacyContent);
        }


        // GET: PrivacyContent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privacyContent = await _context.PrivacyContent.FindAsync(id);
            if (privacyContent == null)
            {
                return NotFound();
            }
            return View(privacyContent);
        }

        // POST: PrivacyContent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Content")] PrivacyContent privacyContent)
        {
            if (id != privacyContent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(privacyContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrivacyContentExists(privacyContent.Id))
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
            return View(privacyContent);
        }
        private bool PrivacyContentExists(int id)
        {
            return _context.PrivacyContent.Any(e => e.Id == id);
        }
    }
}
