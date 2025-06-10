using FleetManagement.DTOs;
using FleetManagement.Models;
using FleetManagement.Repositories;

namespace FleetManagement.Services
{
    public interface IVehicleService
    {
        public void InsertVehicle(CreateVehicleDto dto);

        public void UpdateVehicle(ChassisId chassisId, string color);

        public IEnumerable<VehicleDto> ListVehicles();        
    }
}
