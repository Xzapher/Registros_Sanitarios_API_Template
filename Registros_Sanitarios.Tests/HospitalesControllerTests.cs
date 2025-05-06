using Microsoft.AspNetCore.Mvc;
using Moq;
using RegistrosSanitarios.API.Controllers;
using RegistrosSanitarios.Domain.Entities;

namespace RegistrosSanitarios.Tests.HospitalesControllerTests
{
    public class HospitalesControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfHospitales()
        {
            var mockService = new Mock<IHospitalService>();
            mockService
                .Setup(service => service.GetAllAsync())
                .ReturnsAsync(new List<Hospital>
                {
                    new Hospital { Id = 1, Nombre = "Hospital A" },
                    new Hospital { Id = 2, Nombre = "Hospital B" }
                });

            var controller = new HospitalesController(mockService.Object);

            var result = await controller.GetHospitales();

            var actionResult = Assert.IsType<ActionResult<IEnumerable<Hospital>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var hospitales = Assert.IsType<List<Hospital>>(okResult.Value);
            Assert.Equal(2, hospitales.Count);
        }
    }
}
