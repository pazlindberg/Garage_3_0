using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage_3._0.Data;
using Garage_3._0.Models;

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

        public IActionResult Park()
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
            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.Id == id);
        }


        public async Task<IActionResult> Filter(string regNrSearch, string vehicleTypeIdSearch)
        {
            var model = string.IsNullOrWhiteSpace(regNrSearch) ?
                _context.Vehicle :
                _context.Vehicle.Where(m => m.RegNr.ToLower().Contains(regNrSearch.ToLower()));

            model = vehicleTypeIdSearch == null ?
                model :
                model.Where(m => vehicleTypeIdSearch == null ? 
                    m.VehicleTypeId == null :  //always false
                    m.VehicleTypeId.ToString() == vehicleTypeIdSearch);


            return View(nameof(Index), await model.ToListAsync());
        }



        public JsonResult GetRegNr(string email)
        {
            var memberId= _context.Member.Where(x => x.Email == email).Select(x => x.Id).FirstOrDefault();
            var ddlRegNr = _context.Vehicle.Where(x => x.MemberId == memberId).ToList(); //dropdownlist
            List<SelectListItem> liRegNr = new List<SelectListItem>();

            liRegNr.Add(new SelectListItem { Text = "--Select State--", Value = "0", });
            if (ddlRegNr != null)
            {
                foreach (var x in ddlRegNr)
                {
                    liRegNr.Add(new SelectListItem { Text = x.RegNr, Value = x.Id.ToString() });
                }
            }
            return Json(new SelectList(liRegNr, "Value", "Text", new Newtonsoft.Json.JsonSerializerSettings()));
        }
    }
}
