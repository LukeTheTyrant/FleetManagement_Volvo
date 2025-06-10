using FleetManagement.Models;

namespace FleetManagement.Repositories
{
    public interface IVehicleRepository
    {
        void AddVehicle(Vehicle vehicle);
        void EditVehicle(ChassisId chassisId, string color);
        IEnumerable<Vehicle> GetAllVehicles();
        Vehicle GetVehicle(ChassisId chassisId);
        bool HasVehicle(ChassisId chassisId);
    }
}
