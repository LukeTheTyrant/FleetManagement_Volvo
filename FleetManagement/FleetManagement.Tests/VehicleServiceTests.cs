using FleetManagement.DTOs;
using FleetManagement.Models;
using FleetManagement.Models.Enums;
using FleetManagement.Repositories;
using FleetManagement.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Tests
{
    [TestClass]
    public class VehicleServiceTests
    {
        private Mock<IVehicleRepository> _mockRepo;
        private VehicleService _service;

        [TestInitialize]
        public void Setup()
        {
            _mockRepo = new Mock<IVehicleRepository>();
            _service = new VehicleService(_mockRepo.Object);
        }

        [TestMethod]
        public void InsertVehicle_ShouldCallInsert_WhenChassisIsUnique()
        {
            // Arrange
            var dto = new CreateVehicleDto
            {
                ChassisSeries = "ABC",
                ChassisNumber = 123,
                Color = "Red"
            };

            _mockRepo.Setup(r => r.HasVehicle(It.IsAny<ChassisId>())).Returns(false);

            // Act
            _service.InsertVehicle(dto);

            // Assert
            _mockRepo.Verify(r => r.AddVehicle(It.Is<Vehicle>(v =>
                v.ChassisId.ChassisSeries == "ABC" &&
                v.ChassisId.ChassisNumber == 123
            )), Times.Once);
        }


        [TestMethod]
        public void ListVehicles_ShouldReturnAll()
        {
            List<Vehicle> vehicles;
            // Arrange
            vehicles =
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

            _mockRepo.Setup(r => r.GetAllVehicles()).Returns(vehicles);

            // Act
            var result = _service.ListVehicles();

            // Assert
            Assert.AreEqual(3, result.Count());            
        }        
    }
}
