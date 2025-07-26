using FluentValidation;
using FluentValidation.Results;
using Moq;
using UKParliament.CodeTest.Core.Dtos;
using UKParliament.CodeTest.Core.Entities;
using UKParliament.CodeTest.Core.Interfaces;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Tests.TestData;
using Xunit;

namespace UKParliament.CodeTest.Tests
{
    public class PersonServiceTests
    {
        private readonly ValidationResult? validationResults;

        [Fact]
        public async Task GetAll_ReturnsCorrectListOfPersonDtos()
        {
            // Arrange
            var mockRepo = new Mock<IPersonRepository>();
            var mockMapper = new Mock<IPersonMapper>();
            var mockValidator = new Mock<IValidator<PersonDto>>();
             
            // Setup
            mockValidator.Setup(x => x.Validate(It.IsAny<PersonDto>())).Returns(validationResults!);
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(TestDataPersons.GetTestPersonEntities());
            mockMapper.Setup(mapper => mapper.ToListDto(It.IsAny<IEnumerable<Person>>())).Returns(TestDataPersons.GetTestPersonDtos());

            var service = new PersonService(
                mockValidator.Object, 
                mockRepo.Object, 
                mockMapper.Object);

            // Act
            var personDtos = await service.GetAllAsync();

            // Assert
            var okResult = Assert.IsType<IEnumerable<PersonDto>>(personDtos, exactMatch: false);
            Assert.Equal(2, okResult.Count());
        }
    }
}
