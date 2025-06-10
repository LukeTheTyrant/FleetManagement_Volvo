using FleetManagement.Models;
using FleetManagement.Models.Enums;

namespace FleetManagement.DTOs
{
    public class CreateVehicleDto
    {
        public VehicleType Type { get; set; }
        public string Color { get; set; }
        public string ChassisSeries { get; set; }
        public uint ChassisNumber { get; set; }
    }
}
