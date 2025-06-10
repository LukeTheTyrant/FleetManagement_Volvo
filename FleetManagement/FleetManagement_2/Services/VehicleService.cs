using FleetManagement.DTOs;
using FleetManagement.Models;
using FleetManagement.Models.Enums;
using FleetManagement.Repositories;

namespace FleetManagement.Services
{
    public class VehicleService :IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public void InsertVehicle(CreateVehicleDto dto)
        {
            var chassis = new ChassisId
            {
                ChassisNumber = dto.ChassisNumber,
                ChassisSeries = dto.ChassisSeries
            };

            if (_vehicleRepository.HasVehicle(chassis))
                throw new InvalidOperationException("ChassisId already exists");

            Vehicle newVehicle = dto.Type switch
            {
                VehicleType.Car => new Car(),
                VehicleType.Truck => new Truck(),
                VehicleType.Bus => new Bus()
            };

            newVehicle.ChassisId = chassis;
            newVehicle.Color = dto.Color;

            _vehicleRepository.AddVehicle(newVehicle);
        }

        public void UpdateVehicle(ChassisId chassisId, string color)
        {
            _vehicleRepository.EditVehicle(chassisId, color);
        }

        public IEnumerable<VehicleDto> ListVehicles()
        {
            return _vehicleRepository.GetAllVehicles().Select(v => new VehicleDto
            {
                Type = Enum.GetName(typeof(VehicleType), v.VehicleType),
                Color = v.Color,
                ChassisNumber = v.ChassisId.ChassisNumber,
                ChassisSeries = v.ChassisId.ChassisSeries,
                PassengersNumber = v.PassengersNumber
            });
        }      
    }
}
