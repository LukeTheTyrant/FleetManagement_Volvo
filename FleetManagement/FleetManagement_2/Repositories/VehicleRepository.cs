using FleetManagement.Models;
using FleetManagement.Models.Enums;

namespace FleetManagement.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private List<Vehicle> _vehicles;

        public VehicleRepository() 
        { 
            _vehicles =
            [
                new Car()
                {
                    ChassisId = new ChassisId()
                    {
                        ChassisSeries = "1",
                        ChassisNumber = 123
                    },
                    Color = "Blue"                
                },
                new Truck()
                {
                    ChassisId = new ChassisId()
                    {
                        ChassisSeries = "2",
                        ChassisNumber = 456
                    },
                    Color = "Red"
                },
                new Bus()
                {
                    ChassisId = new ChassisId()
                    {
                        ChassisSeries = "3",
                        ChassisNumber = 789
                    },
                    Color = "Yellow"
                },
            ];
        }
        public void AddVehicle(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public void EditVehicle(ChassisId chassisId, string color)
        {
            var vehicle = _vehicles.Find(v => v.ChassisId.ChassisNumber == chassisId.ChassisNumber && v.ChassisId.ChassisSeries == chassisId.ChassisSeries);

            vehicle.Color = color;
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _vehicles;
        }

        public Vehicle GetVehicle(ChassisId chassisId)
        {
            return _vehicles.First(v => v.ChassisId.ChassisNumber == chassisId.ChassisNumber && v.ChassisId.ChassisSeries == chassisId.ChassisSeries);
        }

        public bool HasVehicle(ChassisId chassisId)
        {
            return _vehicles.Exists(v => v.ChassisId.ChassisNumber == chassisId.ChassisNumber && v.ChassisId.ChassisSeries == chassisId.ChassisSeries);
        }
    }
}
