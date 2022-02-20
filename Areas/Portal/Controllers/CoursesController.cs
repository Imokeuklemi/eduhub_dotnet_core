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

namespace eduhub.Areas.Portal.Controllers
{
    [Area("Portal")]
    public class CoursesController : Controller
    {
        private readonly EduhubDBContext _context;

        public CoursesController(EduhubDBContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var eduhubDBContext = _context.Registeredcourses.Include(r => r.Student);
            return View(await eduhubDBContext.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registeredcourse = await _context.Registeredcourses
                .Include(r => r.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registeredcourse == null)
            {
                return NotFound();
            }

            return View(registeredcourse);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind(
                "Id,StudentId,CourseLevel,Semester,CourseCode,Session,AssessmentScore,ExamScore,Alphagrade,GradePoint,Cgp,GradeClass,Status,Remarks,CourseId"
            )]
                Registeredcourse registeredcourse
        )
        {
            if (ModelState.IsValid)
            {
                _context.Add(registeredcourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(
                _context.Students,
                "Id",
                "Id",
                registeredcourse.StudentId
            );
            return View(registeredcourse);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registeredcourse = await _context.Registeredcourses.FindAsync(id);
            if (registeredcourse == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(
                _context.Students,
                "Id",
                "Id",
                registeredcourse.StudentId
            );
            return View(registeredcourse);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind(
                "Id,StudentId,CourseLevel,Semester,CourseCode,Session,AssessmentScore,ExamScore,Alphagrade,GradePoint,Cgp,GradeClass,Status,Remarks,CourseId"
            )]
                Registeredcourse registeredcourse
        )
        {
            if (id != registeredcourse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registeredcourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisteredcourseExists(registeredcourse.Id))
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
            ViewData["StudentId"] = new SelectList(
                _context.Students,
                "Id",
                "Id",
                registeredcourse.StudentId
            );
            return View(registeredcourse);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registeredcourse = await _context.Registeredcourses
                .Include(r => r.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registeredcourse == null)
            {
                return NotFound();
            }

            return View(registeredcourse);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registeredcourse = await _context.Registeredcourses.FindAsync(id);
            _context.Registeredcourses.Remove(registeredcourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisteredcourseExists(int id)
        {
            return _context.Registeredcourses.Any(e => e.Id == id);
        }
    }
}
