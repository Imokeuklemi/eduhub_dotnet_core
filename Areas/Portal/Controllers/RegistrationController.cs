#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using eduhub.Data;
using eduhub.Models;

namespace eduhub.Areas.Portal.Controllers
{
    [Route("admission")]
    [Authorize]
    [Area("Portal")]
    public class RegistrationController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly EdumisContext _context;

        public RegistrationController(
            EdumisContext context,
            UserManager<IdentityUser> userManager
        )
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Registration
        public async Task<IActionResult> Index()
        {
            var EdumisContext = _context.Students
                .Include(s => s.CourseApprovedNavigation)
                .Include(s => s.LgaOfOriginNavigation);
            return View(await EdumisContext.ToListAsync());
        }


        // GET: Registration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.CourseApprovedNavigation)
                .Include(s => s.LgaOfOriginNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }


        [Route("student")]
        // GET: Registration/Create
        public IActionResult Create()
        {
            ViewData["Email"] = User.FindFirstValue(ClaimTypes.Email);
            ViewData["Programme"] = new SelectList(_context.Programmes, "Id", "ProgName");
            ViewData["CourseOfStudy"] = new SelectList(_context.Departments, "Id", "DeptName");
            ViewData["AlternateCourseOfStudy"] = new SelectList(
                _context.Departments,
                "Id",
                "DeptName"
            );
            ViewData["LgaOfOrigin"] = new SelectList(_context.Locals, "Id", "Name");
            ViewData["LgaOfOriginNavigationId"] = new SelectList(_context.Locals, "Id", "Id");
            return View();
        }

        // POST: Registration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind(
                "Id,RegistrationNumber,Surname,FirstName,MiddleName,MaidenName,DateOfBirth,Sex,MaritalStatus,Email,MobileNumber,ZipCode,CtOfOrigin,LgaOfOrigin,CreatedAt,ModifiedAt,Programme,CourseOfStudy,AlternateCourseOfStudy,ModeOfStudy,CourseApproved,CourseApprovedNavigationId,LgaOfOriginNavigationId"
            )]
                Student student
        )
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();

                TempData["Pid"] = student.Id;

                return RedirectToAction("Create", "Qualifications");
            }
            ViewData["Email"] = User.FindFirstValue(ClaimTypes.Email);
            ViewData["Programme"] = new SelectList(_context.Programmes, "Id", "ProgName");
            ViewData["CourseOfStudy"] = new SelectList(_context.Departments, "Id", "DeptName");
            ViewData["AlternateCourseOfStudy"] = new SelectList(
                _context.Departments,
                "Id",
                "DeptName"
            );
            ViewData["CourseApproved"] = new SelectList(
                _context.DeptProgs,
                "Id",
                "Id",
                student.CourseApproved
            );
            ViewData["LgaOfOrigin"] = new SelectList(
                _context.Locals,
                "Id",
                "Name",
                student.LgaOfOrigin
            );
            return View(student);
        }

        // GET: Registration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["CourseApprovedNavigationId"] = new SelectList(
                _context.DeptProgs,
                "Id",
                "Id",
                student.CourseApprovedNavigationId
            );
            ViewData["LgaOfOriginNavigationId"] = new SelectList(
                _context.Locals,
                "Id",
                "Id",
                student.LgaOfOriginNavigationId
            );
            return View(student);
        }




        // POST: Registration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind(
                "Id,RegistrationNumber,Surname,FirstName,MiddleName,MaidenName,DateOfBirth,Sex,MaritalStatus,Email,MobileNumber,ZipCode,CtOfOrigin,LgaOfOrigin,CreatedAt,ModifiedAt,Programme,CourseOfStudy,AlternateCourseOfStudy,ModeOfStudy,CourseApproved,CourseApprovedNavigationId,LgaOfOriginNavigationId"
            )]
                Student student
        )
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            ViewData["CourseApprovedNavigationId"] = new SelectList(
                _context.DeptProgs,
                "Id",
                "Id",
                student.CourseApprovedNavigationId
            );
            ViewData["LgaOfOriginNavigationId"] = new SelectList(
                _context.Locals,
                "Id",
                "Id",
                student.LgaOfOriginNavigationId
            );
            return View(student);
        }

        // GET: Registration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.CourseApprovedNavigation)
                .Include(s => s.LgaOfOriginNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
