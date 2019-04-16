using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndustryLocationSelector.Data;
using IndustryLocationSelector.Data.Entity;

namespace IndustryLocationSelector.Controllers
{
    public class OrganizationTypesController : Controller
    {
        private readonly ILSContext _context;

        public OrganizationTypesController(ILSContext context)
        {
            _context = context;
        }

        // GET: OrganizationType
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrganizationType.ToListAsync());
        }

        // GET: OrganizationType/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationType = await _context.OrganizationType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizationType == null)
            {
                return NotFound();
            }

            return View(organizationType);
        }

        // GET: OrganizationType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrganizationType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] OrganizationType organizationType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizationType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizationType);
        }

        // GET: OrganizationType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationType = await _context.OrganizationType.FindAsync(id);
            if (organizationType == null)
            {
                return NotFound();
            }
            return View(organizationType);
        }

        // POST: OrganizationType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] OrganizationType organizationType)
        {
            if (id != organizationType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizationType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationTypeExists(organizationType.Id))
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
            return View(organizationType);
        }

        // GET: OrganizationType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationType = await _context.OrganizationType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizationType == null)
            {
                return NotFound();
            }

            return View(organizationType);
        }

        // POST: OrganizationType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizationType = await _context.OrganizationType.FindAsync(id);
            _context.OrganizationType.Remove(organizationType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizationTypeExists(int id)
        {
            return _context.OrganizationType.Any(e => e.Id == id);
        }
    }
}
