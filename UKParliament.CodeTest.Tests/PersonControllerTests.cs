using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UKParliament.CodeTest.Core.Dtos;
using UKParliament.CodeTest.Core.Entities;
using UKParliament.CodeTest.Core.Interfaces;
using UKParliament.CodeTest.Tests.TestData;
using UKParliament.CodeTest.Web.Controllers;
using Xunit;

namespace UKParliament.CodeTest.Tests
{
    public class PersonControllerTests
    {
        private Mock<IPersonService> mockService = new Mock<IPersonService>();
        private Mock<IValidator<PersonDto>> mockValidator = new Mock<IValidator<PersonDto>>();

        [Fact]
        public async Task GetAll_ReturnsCorrectListOfPersonDtos()
        {
            // Arrange
            mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(TestDataPersons.GetTestPersonDtos());

            var controller = new PersonController(
                mockService.Object, 
                mockValidator.Object);

            // Act
            var actionResult = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<ObjectResult>(actionResult.Result);
            var value = Assert.IsType<IEnumerable<PersonDto>>(okResult.Value, exactMatch: false);
            Assert.Equal(2, value.Count());
        }

        [Fact]
        public async Task Add_ReturnsCorrectPersonDto()
        {
            // Arrange
            var personToAdd = TestDataPersons.GetPersonDto();
            var personReturned = TestDataPersons.GetDomainPerson();

            var mockService = new Mock<IPersonService>();
            mockService.Setup(service => service.AddAsync(personToAdd))
                .ReturnsAsync(personReturned);

            mockValidator.Setup(v => v.ValidateAsync(personToAdd, default))
                .ReturnsAsync(new ValidationResult());

            var controller = new PersonController(
                mockService.Object, 
                mockValidator.Object);

            // Act
            var actionResult = await controller.Add(personToAdd);

            // Assert
            var okResult = Assert.IsType<ObjectResult>(actionResult.Result);
            var value = Assert.IsType<Person>(okResult.Value, exactMatch: false);
            Assert.Equal(personToAdd.FirstName, value.FirstName);
        }

        [Fact]
        public async Task Update_ReturnsCorrectPersonDto()
        {
            // Arrange
            var personToUpdate = TestDataPersons.GetPersonDto();
            var personReturned = TestDataPersons.GetDomainPerson();

            var mockService = new Mock<IPersonService>();
            mockService.Setup(service => service.UpdateAsync(personToUpdate))
                .ReturnsAsync(personReturned);

            mockValidator.Setup(v => v.ValidateAsync(personToUpdate, default))
                .ReturnsAsync(new ValidationResult());

            var controller = new PersonController(
                mockService.Object, 
                mockValidator.Object);

            // Act
            var actionResult = await controller.Update(personToUpdate);

            // Assert
            var okResult = Assert.IsType<ObjectResult>(actionResult.Result);
            var value = Assert.IsType<Person>(okResult.Value, exactMatch: false);
            Assert.Equal(personToUpdate.FirstName, value.FirstName);
        }
    }
}
