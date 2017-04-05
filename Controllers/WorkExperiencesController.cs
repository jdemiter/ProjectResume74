using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectResume.Data;
using ProjectResume.Models;

namespace ProjectResume.Controllers
{
    public class WorkExperiencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkExperiencesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: WorkExperiences
        public async Task<IActionResult> Index()
        {
            var workexperience = _context.WorkExperience
                .Include(p => p.person)
                .AsNoTracking();
            return View(await workexperience.ToListAsync());
        }

        // GET: WorkExperiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperience
                .Include(p =>p.person)
                .AsNoTracking()
                .SingleOrDefaultAsync (p => p.PersonID == id);
            if (workExperience == null)
            {
                return NotFound();
            }

            return View(workExperience);
        }

        // GET: WorkExperiences/Create
        public IActionResult Create()
        {
            ViewData["PersonID"] = new SelectList(_context.Person, "PersonID", "Last Name");
            return View();

        }

         // POST: WorkExperiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Employer,Location,JobTitle,EmploymentStartDate,EmploymentEndDate")] WorkExperience workExperience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workExperience);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(workExperience);
        }

        // GET: WorkExperiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperience.SingleOrDefaultAsync(m => m.ID == id);
            if (workExperience == null)
            {
                return NotFound();
            }
            ViewData["ID"] = new SelectList(_context.Person, "ID", "Last Name");
            
            return View(workExperience);
        }

        // POST: WorkExperiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var workexperienceToUpdate = await _context.WorkExperience
                .SingleOrDefaultAsync(w => w.PersonID == id);

            if (await TryUpdateModelAsync<WorkExperience>(workexperienceToUpdate,
                "",
                c => c.Employer, c => c.person))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes." +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction("Index");
            }
            ViewData["ID"] = new SelectList(_context.Person, "ID", "Last Name");
            return View();
        }
                   
           

        // GET: WorkExperiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperience
                .Include(c => c.person)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.PersonID == id);
            if (workExperience == null)
            {
                return NotFound();
            }

            return View(workExperience);
        }

        // POST: WorkExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workExperience = await _context.WorkExperience.SingleOrDefaultAsync(m => m.PersonID == id);
            _context.WorkExperience.Remove(workExperience);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WorkExperienceExists(int id)
        {
            return _context.WorkExperience.Any(e => e.ID == id);
        }
       
    }
}
