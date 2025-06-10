using FleetManagement.DTOs;
using FleetManagement.Models;
using FleetManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(CreateVehicleDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);


            _vehicleService.InsertVehicle(dto);
            return RedirectToAction("ListAll", "Vehicles");
        }

        
        [HttpGet]
        public IActionResult EditColor(string chassisSeries, uint chassisNumber)
        {
            var vehicle = _vehicleService.ListVehicles()
                .FirstOrDefault(v => v.ChassisSeries == chassisSeries && v.ChassisNumber == chassisNumber);

            if (vehicle == null)
                return NotFound();
                        
            return View(vehicle);
        }

        [HttpPost]
        public IActionResult EditColor(VehicleDto vehicle)
        {
            var chassis = new ChassisId { ChassisSeries = vehicle.ChassisSeries, ChassisNumber = vehicle.ChassisNumber };
                       
            _vehicleService.UpdateVehicle(chassis, vehicle.Color);
            return RedirectToAction("ListAll", "Vehicles");          
        }

        
        [HttpGet]
        public IActionResult ListAll()
        {
            var vehicles = _vehicleService.ListVehicles();
            return View(vehicles);
        }

        [HttpGet]
        public IActionResult FindByChassis()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FindByChassis(SearchVehicleDto search)
        {
            var vehicle = _vehicleService.ListVehicles()
                .FirstOrDefault(v => v.ChassisSeries == search.ChassisSeries && v.ChassisNumber == search.ChassisNumber);

            if (vehicle == null)
            {                
                return View();
            }
            
            return RedirectToAction("EditColor", "Vehicles", vehicle);
        }
    }
}
