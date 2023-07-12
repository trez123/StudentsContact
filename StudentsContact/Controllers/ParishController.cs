using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentsContact.Models;

namespace StudentsContact.Controllers
{
    public class ParishController : Controller
    {
        private readonly StudentsDbContext _context;

        public ParishController(StudentsDbContext context)
        {
            _context = context;
        }

        // GET: Parish
        public async Task<IActionResult> Index()
        {
              return _context.Parish != null ? 
                          View(await _context.Parish.ToListAsync()) :
                          Problem("Entity set 'StudentsDbContext.Parish'  is null.");
        }

        // GET: Parish/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Parish == null)
            {
                return NotFound();
            }

            var parish = await _context.Parish
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parish == null)
            {
                return NotFound();
            }

            return View(parish);
        }

        // GET: Parish/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parish/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StateParish")] Parish parish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parish);
        }

        // GET: Parish/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Parish == null)
            {
                return NotFound();
            }

            var parish = await _context.Parish.FindAsync(id);
            if (parish == null)
            {
                return NotFound();
            }
            return View(parish);
        }

        // POST: Parish/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StateParish")] Parish parish)
        {
            if (id != parish.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParishExists(parish.Id))
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
            return View(parish);
        }

        // GET: Parish/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Parish == null)
            {
                return NotFound();
            }

            var parish = await _context.Parish
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parish == null)
            {
                return NotFound();
            }

            return View(parish);
        }

        // POST: Parish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Parish == null)
            {
                return Problem("Entity set 'StudentsDbContext.Parish'  is null.");
            }
            var parish = await _context.Parish.FindAsync(id);
            if (parish != null)
            {
                _context.Parish.Remove(parish);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParishExists(int id)
        {
          return (_context.Parish?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
