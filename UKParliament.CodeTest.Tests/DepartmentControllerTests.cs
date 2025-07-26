using Moq;
using UKParliament.CodeTest.Core.Entities;
using UKParliament.CodeTest.Core.Interfaces;
using UKParliament.CodeTest.Tests.TestData;
using UKParliament.CodeTest.Web.Controllers;
using Xunit;

namespace UKParliament.CodeTest.Tests
{
    public class DepartmentControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsCorrectListOfDepartments()
        {
            // Arrange
            var mockService = new Mock<IDepartmentService>();
            mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(TestDataDepartments.GetTestDepartments());

            var controller = new DepartmentController(mockService.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            var departments = Assert.IsType<IEnumerable<Department>>(result, exactMatch: false);
            Assert.Equal(3, departments.Count());
        }
    }
}
