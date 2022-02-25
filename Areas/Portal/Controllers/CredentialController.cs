#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using Microsoft.EntityFrameworkCore;
using eduhub.Data;
using eduhub.Models;

namespace eduhub.Areas_Portal_Controllers
{
    [Area("Portal")]
    public class CredentialController : Controller
    {
        private readonly EdumisContext _context;

        public CredentialController(EdumisContext context)
        {
            _context = context;
        }

        // GET: Credential
        public async Task<IActionResult> Index()
        {
            var EdumisContext = _context.Credentials.Include(c => c.Student);
            return View(await EdumisContext.ToListAsync());
        }

        // GET: Credential/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credential = await _context.Credentials
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (credential == null)
            {
                return NotFound();
            }

            return View(credential);
        }

        // GET: Credential/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: Credential/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IList<IFormFile> files)
        {
            if (files != null)
            {
                foreach (IFormFile item in files)
                {
                    if (item.Length > 0)
                    {
                        var pid = TempData["pid"];
                        //Getting FileName
                        var fileName = Path.GetFileName(item.FileName);
                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);
                        // concatenating  FileName + FileExtension
                       // concatenating  FileName + FileExtension
                 var newFileName = String.Concat(pid, "_", fileName, fileExtension);

                         // Combines two strings into a path.
                 var filepath = 
new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images")).Root + $@"\{newFileName}";
 using (FileStream fs = System.IO.File.Create(filepath))
                 {
                     item.CopyTo(fs);
                     fs.Flush();
                 }

                        var objfiles = new Credential()
                        {
                            Id = 0,
                            Name = newFileName,
                            FileType = fileExtension,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                            StudentId = 21 // Convert.ToInt32(TempData["pid"])
                        };

                        _context.Credentials.Add(objfiles);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            return View();
        }

        // GET: Credential/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credential = await _context.Credentials.FindAsync(id);
            if (credential == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(
                _context.Students,
                "Id",
                "Id",
                credential.StudentId
            );
            return View(credential);
        }

        // POST: Credential/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,StudentId,Image,FileType,Created,Modified")] Credential credential
        )
        {
            if (id != credential.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(credential);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CredentialExists(credential.Id))
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
                credential.StudentId
            );
            return View(credential);
        }

        // GET: Credential/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credential = await _context.Credentials
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (credential == null)
            {
                return NotFound();
            }

            return View(credential);
        }

        // POST: Credential/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var credential = await _context.Credentials.FindAsync(id);
            _context.Credentials.Remove(credential);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CredentialExists(int id)
        {
            return _context.Credentials.Any(e => e.Id == id);
        }
    }
}
