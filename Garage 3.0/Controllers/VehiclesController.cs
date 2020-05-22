using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage_3._0.Data;
using Garage_3._0.Models;
using Microsoft.AspNetCore.Routing;

namespace Garage_3._0.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly Garage_3_0Context _context;

        public VehiclesController(Garage_3_0Context context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehicle.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult CreateVehicle()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateVehicle([Bind("Id,RegNr,ParkingSpaceId,VehicleTypeId,MemberId,NrOfWheels,Color,Brand,Model,TimeOfArrival")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                TempData["UserMessage"] = "Save vehicle successful";
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegNr,ParkingSpaceId,VehicleTypeId,MemberId,NrOfWheels,Color,Brand,Model,TimeOfArrival")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                    TempData["UserMessage"] = "Update vehicle successful";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
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
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            var v = new Receipt();
            
            var memberId = vehicle.MemberId;
            var member = await _context.Member.FindAsync(memberId);
            v.FullName = $"{member.FirstName} {member.LastName}";
            v.ParkedTime = vehicle.TimeInGarage;

            var timeInGarage = DateTime.Now.Subtract(vehicle.TimeOfArrival);
            int mins = timeInGarage.Hours * 60;
            mins += timeInGarage.Minutes;
            mins += timeInGarage.Days * 24 * 60;
            const int minuteFee = 2;
            int cost = mins * minuteFee;

            var routeValues = new RouteValueDictionary  {
                { "FullName", v.FullName },
                { "ParkedTime", vehicle.TimeInGarage },
                { "RegNr", vehicle.RegNr },
                { "Cost", cost }};

            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Receipt),routeValues);
        }

        public IActionResult Receipt(Receipt r)
        {
            return View(r);
        }
    
        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Filter(string regNrSearch)
        {
            var model = string.IsNullOrWhiteSpace(regNrSearch) ?
                _context.Vehicle :
                _context.Vehicle.Where(m => m.RegNr.ToLower().Contains(regNrSearch.ToLower()));

            //model = genre == null ?
            //    model :
            //    model.Where(m => m.Genre == (Genre)genre);

            return View(nameof(Index), await model.ToListAsync());
        }
    }
}