using IndustryLocationSelector.Data;
using IndustryLocationSelector.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndustryLocationSelector.Controllers
{
   
    public class OrganizationsController : Controller
    {
        private ILSContext _context;
        public OrganizationsController(ILSContext context)
        {
            _context = context;

        }
        // GET: /<controller>/

        public IActionResult Index()
        {

            return View(_context.Organizations.Include(o => o.OrganizationType).ToList());
        }
        [HttpGet("Organizations/{id}")]
        public IActionResult Details(int? id)
        {

            Organizations org = _context.Organizations.Include(o => o.OrganizationType).SingleOrDefault(o => o.Id == id);

            return View(org);
        }
       
       
        public IActionResult Create()
        {
            var types = _context.OrganizationType;
            ViewBag.OrganizationTypeId = new SelectList(types, "Id", "Name");

            return View("Create");
        }


        
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,OrganizationTypeId,Longitude,Latitude")]Organizations organization)
        {

            if (ModelState.IsValid)
            {

                _context.Organizations.Add(organization);
                int count = _context.SaveChanges();
                organization.OrganizationType = _context.OrganizationType.Single(ot => ot.Id == organization.OrganizationTypeId);
                return View(nameof(Details), organization);
            }

            ViewBag.OrganizationTypeId = new SelectList(_context.OrganizationType, "Id", "Name", organization.OrganizationTypeId);
            ModelState.AddModelError("NoInsertError", "organization cant be created");
            return View(organization);




        }
        
        public IActionResult Edit(int id)
        {
            var data = _context.Organizations.SingleOrDefault(o => o.Id == id);
            if (data == null)
            {
                return NotFound();
            }

            var types = _context.OrganizationType;
            ViewBag.OrganizationTypeId = new SelectList(types, "Id", "Name", data.OrganizationTypeId);

            return View(data);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [Bind("Id,Name,OrganizationTypeId,Longitude,Latitude")]Organizations organizations)
        {
            if (ModelState.IsValid)
            {
                _context.Update(organizations);
                _context.SaveChanges();
                return RedirectToAction(nameof(Details), new { id = organizations.Id });
            }
            ViewBag.OrganizationTypeId = new SelectList(_context.OrganizationType, "Id", "Name", organizations.OrganizationTypeId);
            return View(organizations);
        }

       
        public IActionResult Delete(int id)
        {
            var data = _context.Organizations.Include(o=> o.OrganizationType).SingleOrDefault(o => o.Id == id);
            if (data == null)
            {
                return NotFound();
            }

            
            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed([FromBody]int id)
        {
            var data = _context.Organizations.SingleOrDefault(o => o.Id == id);
            if (data == null)
            {
                return NotFound();
            }

            _context.Organizations.Remove(data);
            _context.SaveChanges();
             data = _context.Organizations.SingleOrDefault(o => o.Id == id);
            if (data == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(nameof(Delete), data.Id);   
            
          
        }

    }
}
