using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyThrillRideTrackerApp5.Models;

namespace MyThrillRideTrackerApp5.Controllers
{
    public class VisitRidesController : Controller
    {
        private readonly ThrillRideTrackerDbContext _context;

        public VisitRidesController(ThrillRideTrackerDbContext context)
        {
            _context = context;
        }

        // GET: VisitRides
        public async Task<IActionResult> Index()
        {
            var thrillRideTrackerDbContext = _context.VisitRides
                .Include(v => v.Ride)
                .Include(v => v.Visit);
            return View(await thrillRideTrackerDbContext.ToListAsync());
        }

        // GET: VisitRides/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitRide = await _context.VisitRides
                .Include(v => v.Ride)
                .Include(v => v.Visit)
                .FirstOrDefaultAsync(m => m.VisitRideId == id);
            if (visitRide == null)
            {
                return NotFound();
            }

            return View(visitRide);
        }

        // GET: VisitRides/Create
        public IActionResult Create()
        {
            var visitsList = (from p in _context.Parks
                              join v in _context.Visits
                              on p.ParkId equals v.ParkId
                              orderby v.VisitDate descending
                              select new
                              {
                                  p.Name,
                                  v.VisitId,
                                  ParkDisplayName = p.Name + " " + v.VisitDate.ToShortDateString()
                              }).ToList();
           
            ViewData["VisitId"] = new SelectList(visitsList, "VisitId", "ParkDisplayName");
            ViewData["RideId"] = new SelectList(_context.Rides, "RideId", "Name");
           
            return View();
        }

        // POST: VisitRides/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VisitRideId,VisitId,RideId,VisitRideRating,VisitRideComments")] VisitRide visitRide)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitRide);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RideId"] = new SelectList(_context.Rides, "RideId", "RideId", visitRide.RideId);
            ViewData["VisitId"] = new SelectList(_context.Visits, "VisitId", "VisitId", visitRide.VisitId);
            return View(visitRide);
        }

        // GET: VisitRides/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitRide = await _context.VisitRides.FindAsync(id);
            if (visitRide == null)
            {
                return NotFound();
            }
            ViewData["RideId"] = new SelectList(_context.Rides, "RideId", "RideId", visitRide.RideId);
            ViewData["VisitId"] = new SelectList(_context.Visits, "VisitId", "VisitId", visitRide.VisitId);
            return View(visitRide);
        }

        // POST: VisitRides/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VisitRideId,VisitId,RideId,VisitRideRating,VisitRideComments")] VisitRide visitRide)
        {
            if (id != visitRide.VisitRideId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitRide);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitRideExists(visitRide.VisitRideId))
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
            ViewData["RideId"] = new SelectList(_context.Rides, "RideId", "RideId", visitRide.RideId);
            ViewData["VisitId"] = new SelectList(_context.Visits, "VisitId", "VisitId", visitRide.VisitId);
            return View(visitRide);
        }

        // GET: VisitRides/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitRide = await _context.VisitRides
                .Include(v => v.Ride)
                .Include(v => v.Visit)
                .FirstOrDefaultAsync(m => m.VisitRideId == id);
            if (visitRide == null)
            {
                return NotFound();
            }

            return View(visitRide);
        }

        // POST: VisitRides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitRide = await _context.VisitRides.FindAsync(id);
            _context.VisitRides.Remove(visitRide);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitRideExists(int id)
        {
            return _context.VisitRides.Any(e => e.VisitRideId == id);
        }
    }
}
