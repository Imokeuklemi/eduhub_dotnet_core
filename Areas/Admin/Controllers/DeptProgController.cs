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
    public class DeptProgController : Controller
    {
        private readonly EdumisContext _context;

        public DeptProgController(EdumisContext context)
        {
            _context = context;
        }

        // GET: DeptProg
        public async Task<IActionResult> Index()
        {
            var eduhubDBContext = _context.DeptProgs.Include(d => d.Department).Include(d => d.Programme);
            return View(await eduhubDBContext.ToListAsync());
        }

        // GET: DeptProg/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deptProg = await _context.DeptProgs
                .Include(d => d.Department)
                .Include(d => d.Programme)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deptProg == null)
            {
                return NotFound();
            }

            return View(deptProg);
        }

        // GET: DeptProg/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id");
            ViewData["ProgrammeId"] = new SelectList(_context.Programmes, "Id", "Id");
            return View();
        }

        // POST: DeptProg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DepartmentId,ProgrammeId")] DeptProg deptProg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deptProg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", deptProg.DepartmentId);
            ViewData["ProgrammeId"] = new SelectList(_context.Programmes, "Id", "Id", deptProg.ProgrammeId);
            return View(deptProg);
        }

        // GET: DeptProg/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deptProg = await _context.DeptProgs.FindAsync(id);
            if (deptProg == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", deptProg.DepartmentId);
            ViewData["ProgrammeId"] = new SelectList(_context.Programmes, "Id", "Id", deptProg.ProgrammeId);
            return View(deptProg);
        }

        // POST: DeptProg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DepartmentId,ProgrammeId")] DeptProg deptProg)
        {
            if (id != deptProg.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deptProg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeptProgExists(deptProg.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", deptProg.DepartmentId);
            ViewData["ProgrammeId"] = new SelectList(_context.Programmes, "Id", "Id", deptProg.ProgrammeId);
            return View(deptProg);
        }

        // GET: DeptProg/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deptProg = await _context.DeptProgs
                .Include(d => d.Department)
                .Include(d => d.Programme)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deptProg == null)
            {
                return NotFound();
            }

            return View(deptProg);
        }

        // POST: DeptProg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deptProg = await _context.DeptProgs.FindAsync(id);
            _context.DeptProgs.Remove(deptProg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeptProgExists(int id)
        {
            return _context.DeptProgs.Any(e => e.Id == id);
        }
    }
}
