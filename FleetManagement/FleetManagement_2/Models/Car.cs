using FleetManagement.Models.Enums;

namespace FleetManagement.Models
{
    public class Car : Vehicle
    {
        public override VehicleType VehicleType => VehicleType.Car;

        public override int PassengersNumber => 4;
    }
}
