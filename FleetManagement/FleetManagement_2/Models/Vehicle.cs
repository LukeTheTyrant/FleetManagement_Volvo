using FleetManagement.Models.Enums;

namespace FleetManagement.Models
{
    public abstract class Vehicle
    {
        public ChassisId ChassisId { get; set; }
        public string Color { get; set; }
        public abstract VehicleType VehicleType { get; }
        public abstract int PassengersNumber { get; }
    }
}
