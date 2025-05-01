using Microsoft.AspNetCore.Mvc;
using Moq;
using RegistrosSanitarios.API.Controllers;
using RegistrosSanitarios.Domain.Entities;
using RegistrosSanitarios.Domain.Services;

namespace RegistrosSanitarios.Tests.HospitalesControllerTests
{
    public class HospitalesControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfHospitales()
        {
            var mockService = new Mock<IHospitaleService>();
            mockService
                .Setup(service => service.GetAllAsync())
                .ReturnsAsync(new List<Hospitale>
                {
                    new Hospitale { Id = 1, Nombre = "Hospital A" },
                    new Hospitale { Id = 2, Nombre = "Hospital B" }
                });

            var controller = new HospitalesController(mockService.Object);

            var result = await controller.GetHospitales();

            var actionResult = Assert.IsType<ActionResult<IEnumerable<Hospitale>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var hospitales = Assert.IsType<List<Hospitale>>(okResult.Value);
            Assert.Equal(2, hospitales.Count);
        }
    }
}
