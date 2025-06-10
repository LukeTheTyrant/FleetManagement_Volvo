using FleetManagement.Models.Enums;

namespace FleetManagement.Models
{
    public class Bus : Vehicle
    {
        public override VehicleType VehicleType => VehicleType.Bus;

        public override int PassengersNumber => 42;
    }
}
