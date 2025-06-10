using FleetManagement.Models.Enums;

namespace FleetManagement.Models
{
    public class Truck : Vehicle
    {
        public override VehicleType VehicleType => VehicleType.Truck;

        public override int PassengersNumber => 1;
    }
}
