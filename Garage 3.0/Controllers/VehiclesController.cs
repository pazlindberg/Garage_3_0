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
using Garage_3._0.ViewModels;

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

        public async Task<IActionResult> Overview()
        {

            var model = _context.Vehicle
                                .Include(v => v.VehicleType)
                                .Include(v => v.Member)
                                .Select(v => new OverviewViewModel
                                {
                                    Email = v.Member.Email,
                                    TypeName = v.VehicleType.TypeName,
                                    RegNr = v.RegNr,
                                    TimeInGarage = v.TimeInGarage
                                });

            return View(await model.ToListAsync());
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

        public IActionResult Receipt(Receipt r)
        {
            return View(r);
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

                //Member m =_context.Member.FindAsync(vehicle.MemberId);
                
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }


        public async Task<IActionResult> Parking(string regNr)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var vehicle = await _context.Vehicle
                    .FirstOrDefaultAsync(m => m.RegNr == regNr);
                    if (vehicle == null)
                    {
                        TempData["UserMessage"] = "Park vehicle was not successful";
                        return RedirectToAction(nameof(Index));
                    }
                    vehicle.TimeOfArrival = DateTime.Now;
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                    TempData["UserMessage"] = "Park vehicle successful";
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                }
            }
            return View("Park");
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
            TimeSpan timeInGarage;

            if (vehicle.TimeOfArrival != null)
                timeInGarage = DateTime.Now.Subtract((DateTime)vehicle.TimeOfArrival);
            else timeInGarage = DateTime.Now.Subtract(DateTime.Now);
            
            int mins = (timeInGarage.Days * 24 * 60) + (timeInGarage.Hours * 60) + timeInGarage.Minutes;
            const int minuteFee = 2;
            int cost = mins * minuteFee;

            var routeValues = new RouteValueDictionary  {
                { "FullName", v.FullName },
                { "ParkedTime", vehicle.TimeInGarage },
                { "RegNr", vehicle.RegNr },
                { "Cost", cost }};

            _context.Vehicle.Remove(vehicle);
            vehicle.TimeOfArrival = null;
            _context.Update(vehicle);
            //_context.Vehicle.Remove(vehicle);

            await _context.SaveChangesAsync();
            TempData["UserMessage"] = "Unpark vehicle successful";
            return RedirectToAction(nameof(Receipt),routeValues);
        }
    
        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Filter(string regNrSearch, string? vehicleTypeIdSearch)
        {
            var model = string.IsNullOrWhiteSpace(regNrSearch) ?
                _context.Vehicle :
                _context.Vehicle.Where(m => m.RegNr.Trim().ToLower().Contains(regNrSearch.Trim().ToLower()));

            model = vehicleTypeIdSearch == null ?
                model :
                model.Where(m => vehicleTypeIdSearch == null ? 
                    m.VehicleTypeId == null :  //always false
                    m.VehicleTypeId.ToString() == vehicleTypeIdSearch);


            return View(nameof(Index), await model.ToListAsync());
        }



        public JsonResult GetEmail(string email)
        {
            var memberId= _context.Member.Where(x => x.Email == email.Trim()).Select(x => x.Id).FirstOrDefault();
            var ddlRegNr = _context.Vehicle.Where(x => x.TimeOfArrival == null && x.MemberId == memberId).ToList(); //dropdownlist
            List<SelectListItem> liRegNr = new List<SelectListItem>();

            if (ddlRegNr != null)
            {
                foreach (var x in ddlRegNr)
                {
                    liRegNr.Add(new SelectListItem { Text = x.RegNr, Value = x.Id.ToString() });
                }
            }
            return Json(new SelectList(liRegNr, "Value", "Text", new Newtonsoft.Json.JsonSerializerSettings()));
        }

        public bool GetRegNr(string regNr)
        {
            return _context.Vehicle.Any(v => v.TimeOfArrival == null && v.RegNr == regNr.Trim());
        }
    }
}