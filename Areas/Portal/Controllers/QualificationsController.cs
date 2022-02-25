#nullable disable
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eduhub.Data;
using eduhub.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Claims;

namespace eduhub.Areas.Portal.Controllers
{
    [Authorize]
    [Area("Portal")]
    public class QualificationsController : Controller
    {
        private readonly EdumisContext _context;

        public QualificationsController(EdumisContext context)
        {
            _context = context;
        }

        // GET: Qualifications
        public async Task<IActionResult> Index()
        {
            var EdumisContext = _context.Qualifications.Include(q => q.Student);
            return View(await EdumisContext.ToListAsync());
        }

        // GET: Qualifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualification = await _context.Qualifications
                .Include(q => q.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qualification == null)
            {
                return NotFound();
            }

            return View(qualification);
        }

        // GET: Qualifications/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = 19; // TempData["Pid"];
            TempData.Keep("Pid");

            // ViewData["YearGraduated"] = new SelectList( Enumerable.Range(DateTime.Now.Year, 4), .ToList();

            //Console.WriteLine(Enumerable.Range(DateTime.Now.Year, 4));

            return View();
        }

        // POST: Qualifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,StudentId,Institute,YearGraduated,CertificateObtained,Specialty,ScannedCert")]
                Qualification qualification,
            string submit
        )
        {
            var stId = TempData["StudentId"];
            if (ModelState.IsValid)
            {
                _context.Add(qualification);
                await _context.SaveChangesAsync();
                if (submit == "Add More")
                {
                    ViewData["StudentId"] = new SelectList(
                        _context.Students,
                        "Id",
                        "Id",
                        qualification.StudentId
                    );
                    return View(qualification);
                }
                else
                {
                    var getQual = await _context.Qualifications
                        .Include(q => q.Student)
                        .FirstOrDefaultAsync(m => m.StudentId == Convert.ToInt32(stId));
                    if (getQual != null && getQual.CertificateObtained == "WASCNECO")
                    {
                        TempData["QualificationId"] = getQual.Id;
                        return RedirectToAction("Create", "Subject");
                    }
                    else
                    {
                        return RedirectToAction("Create", "Address");
                    }
                }
            }

            ViewData["StudentId"] = new SelectList(
                _context.Students,
                "Id",
                "Id",
                qualification.StudentId
            );
            return View(qualification);
        }

        // GET: Qualifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualification = await _context.Qualifications.FindAsync(id);
            if (qualification == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(
                _context.Students,
                "Id",
                "Id",
                qualification.StudentId
            );
            return View(qualification);
        }

        // POST: Qualifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,StudentId,Institute,YearGraduated,CertificateObtained,Specialty,ScannedCert")]
                Qualification qualification
        )
        {
            if (id != qualification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qualification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QualificationExists(qualification.Id))
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
                qualification.StudentId
            );
            return View(qualification);
        }

        // GET: Qualifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualification = await _context.Qualifications
                .Include(q => q.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qualification == null)
            {
                return NotFound();
            }

            return View(qualification);
        }

        // POST: Qualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qualification = await _context.Qualifications.FindAsync(id);
            _context.Qualifications.Remove(qualification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QualificationExists(int id)
        {
            return _context.Qualifications.Any(e => e.Id == id);
        }
    }
}
