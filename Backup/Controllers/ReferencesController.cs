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
    public class ReferencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReferencesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: References
        public async Task<IActionResult> Index()
        {
            return View(await _context.References.ToListAsync());
        }

        // GET: References/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var references = await _context.References.SingleOrDefaultAsync(m => m.ID == id);
            if (references == null)
            {
                return NotFound();
            }

            return View(references);
        }

        // GET: References/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: References/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Address,PhoneNumber,EmailAddress")] References references)
        {
            if (ModelState.IsValid)
            {
                _context.Add(references);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(references);
        }

        // GET: References/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var references = await _context.References.SingleOrDefaultAsync(m => m.ID == id);
            if (references == null)
            {
                return NotFound();
            }
            return View(references);
        }

        // POST: References/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Address,PhoneNumber,EmailAddress")] References references)
        {
            if (id != references.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(references);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferencesExists(references.ID))
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
            return View(references);
        }

        // GET: References/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var references = await _context.References.SingleOrDefaultAsync(m => m.ID == id);
            if (references == null)
            {
                return NotFound();
            }

            return View(references);
        }

        // POST: References/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var references = await _context.References.SingleOrDefaultAsync(m => m.ID == id);
            _context.References.Remove(references);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ReferencesExists(int id)
        {
            return _context.References.Any(e => e.ID == id);
        }
    }
}
