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
        [Fact]
        public async Task GetAll_ReturnsCorrectListOfPersonDtos()
        {
            // Arrange
            var mockRepo = new Mock<IPersonRepository>();
            var mockMapper = new Mock<IPersonMapper>();
             
            // Setup
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(TestDataPersons.GetTestPersonEntities());
            mockMapper.Setup(mapper => mapper.ToListDto(It.IsAny<IEnumerable<Person>>())).Returns(TestDataPersons.GetTestPersonDtos());

            var service = new PersonService(
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
