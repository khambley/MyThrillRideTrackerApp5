using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using MyThrillRideTrackerApp5.Models;
using MyThrillRideTrackerApp5.Processors;

namespace MyThrillRideTrackerApp5.Controllers
{
    public class ParksController : Controller
    {
        private readonly ThrillRideTrackerDbContext _context;
        
        public ParksController(ThrillRideTrackerDbContext context)
        {
            _context = context;
        }

        // GET: Parks
        public async Task<IActionResult> Index()
        {
            IEnumerable<Park> parksList = await _context.Parks.Include(p => p.ImageFiles).ToListAsync();
            return View(parksList);
        }

        // GET: Parks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var park = await _context.Parks
                .FirstOrDefaultAsync(m => m.ParkId == id);
            if (park == null)
            {
                return NotFound();
            }

            return View(park);
        }

        // GET: Parks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParkId,Name,Description,City,State,WebsiteLink,ParkMapLink")] Park park, List<IFormFile> files)
        {
            //This is a comment
            if (ModelState.IsValid)
            {
                // 1. Save the park model first, creates a unique id for the inserted park.
                _context.Add(park);
                await _context.SaveChangesAsync();

                // 2. Save the ImageFiles in Images folder and get new Filenames.
                var newFileNames = ImageProcessor.SaveImageFilesToDrive(files);

                // 3. Save FileName and path in db.
                foreach (var newfileName in newFileNames)
				{
                    var imageFileName = new ImageFileName()
                    {
                        FileName = newfileName,
                        ParkId = park.ParkId
                    };
                    _context.ImageFileNames.Add(imageFileName);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(park);
        }

        // GET: Parks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var park = await _context.Parks.FindAsync(id);
            if (park == null)
            {
                return NotFound();
            }
            return View(park);
        }

        // POST: Parks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParkId,Name,Description,City,State,WebsiteLink,ParkMapLink")] Park park)
        {
            if (id != park.ParkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(park);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkExists(park.ParkId))
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
            return View(park);
        }

        // GET: Parks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var park = await _context.Parks
                .FirstOrDefaultAsync(m => m.ParkId == id);
            if (park == null)
            {
                return NotFound();
            }

            return View(park);
        }

        // POST: Parks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var park = await _context.Parks.FindAsync(id);
            _context.Parks.Remove(park);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkExists(int id)
        {
            return _context.Parks.Any(e => e.ParkId == id);
        }
    }
}
