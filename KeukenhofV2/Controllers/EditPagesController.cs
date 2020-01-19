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
    public class EditPagesController : Controller
    {
        private readonly KeukenhofContext _context;

        public EditPagesController(KeukenhofContext context)
        {
            _context = context;
        }

        // GET: EditPages
        public async Task<IActionResult> Index()
        {
            return View(await _context.EditPagesModel.ToListAsync());
        }

        // GET: EditPages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editPagesModel = await _context.EditPagesModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (editPagesModel == null)
            {
                return NotFound();
            }

            return View(editPagesModel);
        }

        // GET: EditPages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EditPages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Controller,Action")] EditPagesModel editPagesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editPagesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(editPagesModel);
        }

        // GET: EditPages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editPagesModel = await _context.EditPagesModel.FindAsync(id);
            if (editPagesModel == null)
            {
                return NotFound();
            }
            return View(editPagesModel);
        }

        // POST: EditPages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Controller,Action")] EditPagesModel editPagesModel)
        {
            if (id != editPagesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editPagesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditPagesModelExists(editPagesModel.Id))
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
            return View(editPagesModel);
        }

        // GET: EditPages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editPagesModel = await _context.EditPagesModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (editPagesModel == null)
            {
                return NotFound();
            }

            return View(editPagesModel);
        }

        // POST: EditPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var editPagesModel = await _context.EditPagesModel.FindAsync(id);
            _context.EditPagesModel.Remove(editPagesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditPagesModelExists(int id)
        {
            return _context.EditPagesModel.Any(e => e.Id == id);
        }
    }
}
