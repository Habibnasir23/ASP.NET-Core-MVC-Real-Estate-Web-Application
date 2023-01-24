using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RealEstatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RealEstates
        public async Task<IActionResult> Index()
        {
              return View(await _context.RealEstate.ToListAsync());
        }

        // GET: RealEstates/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // PoST: RealEstates/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchProperty)
        {
            // j => j.RealEstate.Contains(SearchProperty)) this is an anonymous function
            return View("Index", await _context.RealEstate.Where(j => j.propAvailable.Contains(SearchProperty)).ToListAsync());
        }

        

        // GET: RealEstates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RealEstate == null)
            {
                return NotFound();
            }

            var realEstate = await _context.RealEstate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realEstate == null)
            {
                return NotFound();
            }

            return View(realEstate);
        }

        // GET: RealEstates/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: RealEstates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,propAvailable,roomsAvailable,rent")] RealEstate realEstate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(realEstate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (!ModelState.IsValid)
            {
                foreach (var modelStateVal in ViewData.ModelState.Values)
                {
                    foreach (var error in modelStateVal.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
            }
            return View(realEstate);
        }

        // GET: RealEstates/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RealEstate == null)
            {
                return NotFound();
            }

            var realEstate = await _context.RealEstate.FindAsync(id);
            if (realEstate == null)
            {
                return NotFound();
            }
            return View(realEstate);
        }

        // POST: RealEstates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,propAvailable,roomsAvailable,rent")] RealEstate realEstate)
        {
            if (id != realEstate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(realEstate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RealEstateExists(realEstate.Id))
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
            return View(realEstate);
        }

        // GET: RealEstates/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RealEstate == null)
            {
                return NotFound();
            }

            var realEstate = await _context.RealEstate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realEstate == null)
            {
                return NotFound();
            }

            return View(realEstate);
        }

        // POST: RealEstates/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RealEstate == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RealEstate'  is null.");
            }
            var realEstate = await _context.RealEstate.FindAsync(id);
            if (realEstate != null)
            {
                _context.RealEstate.Remove(realEstate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RealEstateExists(int id)
        {
          return _context.RealEstate.Any(e => e.Id == id);
        }
    }
}
