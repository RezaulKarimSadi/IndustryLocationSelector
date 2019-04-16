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
    
    public class PlacesController : Controller
    {
        private readonly ILSContext _context;

        public PlacesController(ILSContext context)
        {
            _context = context;
        }

        // GET: Places
        public async Task<IActionResult> Index()
        {
            var iLSContext = _context.Place.Include(p => p.PlaceType);
            return View(await iLSContext.ToListAsync());
        }

        // GET: Places/Details/5
        [HttpGet("Places/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var place = await _context.Place
                .Include(p => p.PlaceType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (place == null)
            {
                return NotFound();
            }

            return View(place);
        }

        // GET: Places/Create
       
      [HttpGet]
        public IActionResult Create()
        {
            var type = _context.PlaceType;
            ViewBag.PlaceTypeId = new SelectList(type, "Id", "Name");
            return View();
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PlaceTypeId")] Place place)
        {
            if (ModelState.IsValid)
            {
                _context.Add(place);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaceTypeId"] = new SelectList(_context.PlaceType, "Id", "Name", place.PlaceTypeId);
            return View(place);
        }

        // GET: Places/Edit/5
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var place = await _context.Place.FindAsync(id);
            if (place == null)
            {
                return NotFound();
            }
            ViewData["PlaceTypeId"] = new SelectList(_context.PlaceType, "Id", "Name", place.PlaceTypeId);
            return View(place);
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PlaceTypeId")] Place place)
        {
            if (id != place.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(place);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaceExists(place.Id))
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
            ViewData["PlaceTypeId"] = new SelectList(_context.PlaceType, "Id", "Name", place.PlaceTypeId);
            return View(place);
        }

        // GET: Places/Delete/5
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var place = await _context.Place
                .Include(p => p.PlaceType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (place == null)
            {
                return NotFound();
            }

            return View(place);
        }

        // POST: Places/Delete/5
        [HttpPost("{id?}")]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var place = await _context.Place.FindAsync(id);
            _context.Place.Remove(place);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaceExists(int id)
        {
            return _context.Place.Any(e => e.Id == id);
        }
    }
}
