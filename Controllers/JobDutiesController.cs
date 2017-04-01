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
    public class JobDutiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobDutiesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: JobDuties
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.JobDuty.Include(j => j.Employer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: JobDuties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobDuty = await _context.JobDuty.SingleOrDefaultAsync(m => m.ID == id);
            if (jobDuty == null)
            {
                return NotFound();
            }

            return View(jobDuty);
        }

        // GET: JobDuties/Create
        public IActionResult Create()
        {
            ViewData["WorkExperienceID"] = new SelectList(_context.WorkExperience, "ID", "ID");
            return View();
        }

        // POST: JobDuties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Responsibilities,WorkExperienceID")] JobDuty jobDuty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobDuty);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["WorkExperienceID"] = new SelectList(_context.WorkExperience, "ID", "ID", jobDuty.WorkExperienceID);
            return View(jobDuty);
        }

        // GET: JobDuties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobDuty = await _context.JobDuty.SingleOrDefaultAsync(m => m.ID == id);
            if (jobDuty == null)
            {
                return NotFound();
            }
            ViewData["WorkExperienceID"] = new SelectList(_context.WorkExperience, "ID", "ID", jobDuty.WorkExperienceID);
            return View(jobDuty);
        }

        // POST: JobDuties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Responsibilities,WorkExperienceID")] JobDuty jobDuty)
        {
            if (id != jobDuty.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobDuty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobDutyExists(jobDuty.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["WorkExperienceID"] = new SelectList(_context.WorkExperience, "ID", "ID", jobDuty.WorkExperienceID);
            return View(jobDuty);
        }

        // GET: JobDuties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobDuty = await _context.JobDuty.SingleOrDefaultAsync(m => m.ID == id);
            if (jobDuty == null)
            {
                return NotFound();
            }

            return View(jobDuty);
        }

        // POST: JobDuties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobDuty = await _context.JobDuty.SingleOrDefaultAsync(m => m.ID == id);
            _context.JobDuty.Remove(jobDuty);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool JobDutyExists(int id)
        {
            return _context.JobDuty.Any(e => e.ID == id);
        }
    }
}
