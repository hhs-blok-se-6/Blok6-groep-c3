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
    public class ContactContentController : Controller
    {
        private readonly KeukenhofContext _context;

        public ContactContentController(KeukenhofContext context)
        {
            _context = context;
        }

        // GET: ContactContent
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactContent.ToListAsync());
        }

        // GET: ContactContent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactContent = await _context.ContactContent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactContent == null)
            {
                return NotFound();
            }

            return View(contactContent);
        }


        // GET: ContactContent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactContent = await _context.ContactContent.FindAsync(id);
            if (contactContent == null)
            {
                return NotFound();
            }
            return View(contactContent);
        }

        // POST: ContactContent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Content")] ContactContent contactContent)
        {
            if (id != contactContent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactContentExists(contactContent.Id))
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
            return View(contactContent);
        }


        private bool ContactContentExists(int id)
        {
            return _context.ContactContent.Any(e => e.Id == id);
        }
    }
}
