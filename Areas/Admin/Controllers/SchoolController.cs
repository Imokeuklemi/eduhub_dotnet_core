#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eduhub.Data;
using eduhub.Models;

namespace eduhub.Areas_Admin_Controller
{
    [Area("admin")]
    public class SchoolController : Controller
    {
        private readonly EdumisContext _context;

        public SchoolController(EdumisContext context)
        {
            _context = context;
        }

        // GET: School
        public async Task<IActionResult> Index()
        {
            return View(await _context.Schools.ToListAsync());
        }

        // GET: School/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.Schools
                .FirstOrDefaultAsync(m => m.Code == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // GET: School/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: School/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,SchoolName")] School school)
        {
            if (ModelState.IsValid)
            {
                _context.Add(school);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(school);
        }

        // GET: School/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.Schools.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }
            return View(school);
        }

        // POST: School/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Code,SchoolName")] School school)
        {
            if (id != school.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(school);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolExists(school.Code))
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
            return View(school);
        }

        // GET: School/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.Schools
                .FirstOrDefaultAsync(m => m.Code == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // POST: School/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var school = await _context.Schools.FindAsync(id);
            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolExists(string id)
        {
            return _context.Schools.Any(e => e.Code == id);
        }
    }
}
