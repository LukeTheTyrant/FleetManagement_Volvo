using FleetManagement.Models.Enums;

namespace FleetManagement.DTOs
{
    public class VehicleDto
    {
        public string Type { get; set; }
        public string Color { get; set; }
        public string ChassisSeries { get; set; }
        public uint ChassisNumber { get; set; }
        public int PassengersNumber { get; set; }
    }
}
