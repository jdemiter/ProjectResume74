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
    public class VolunteerExperiencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VolunteerExperiencesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: VolunteerExperiences
        public async Task<IActionResult> Index()
        {
            return View(await _context.VolunteerExperience.ToListAsync());
        }

        // GET: VolunteerExperiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteerExperience = await _context.VolunteerExperience.SingleOrDefaultAsync(m => m.ID == id);
            if (volunteerExperience == null)
            {
                return NotFound();
            }

            return View(volunteerExperience);
        }

        // GET: VolunteerExperiences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VolunteerExperiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,VolunteerOrganization, VolunteerStartDate, VolunteerEndDate, VolunteerDuties")] VolunteerExperience volunteerExperience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(volunteerExperience);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(volunteerExperience);
        }

        // GET: VolunteerExperiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteerExperience = await _context.VolunteerExperience.SingleOrDefaultAsync(m => m.ID == id);
            if (volunteerExperience == null)
            {
                return NotFound();
            }
            return View(volunteerExperience);
        }

        // POST: VolunteerExperiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,VolunteerOrganization, VolunteerStartDate, VolunteerEndDate, VolunteerDuties")] VolunteerExperience volunteerExperience)
        {
            if (id != volunteerExperience.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(volunteerExperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VolunteerExperienceExists(volunteerExperience.ID))
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
            return View(volunteerExperience);
        }

        // GET: VolunteerExperiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteerExperience = await _context.VolunteerExperience.SingleOrDefaultAsync(m => m.ID == id);
            if (volunteerExperience == null)
            {
                return NotFound();
            }

            return View(volunteerExperience);
        }

        // POST: VolunteerExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var volunteerExperience = await _context.VolunteerExperience.SingleOrDefaultAsync(m => m.ID == id);
            _context.VolunteerExperience.Remove(volunteerExperience);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VolunteerExperienceExists(int id)
        {
            return _context.VolunteerExperience.Any(e => e.ID == id);
        }
    }
}
