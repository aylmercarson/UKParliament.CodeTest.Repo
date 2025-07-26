using UKParliament.CodeTest.Core.Dtos;
using UKParliament.CodeTest.Core.Entities;
using UKParliament.CodeTest.Services.Mappers;
using Xunit;

namespace UKParliament.CodeTest.Tests
{
    public class MapperTests
    {

        [Fact]
        public void ToDto_ReturnsPersonDto()
        {
            var mapper = new PersonMapper();

            var personToMap = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "trew",
                Mobile = "1234567890",
                DateOfBirth = new DateTime(1990, 1, 1),
                Department = 1
            };

            // Act
            var personDto = mapper.ToDto(personToMap);

            Assert.IsType<PersonDto>(personDto);
            Assert.NotNull(personDto);
            Assert.Equal(personToMap.Id, personDto.Id);
            Assert.Equal(personToMap.FirstName, personDto.FirstName);
            Assert.Equal(personToMap.LastName, personDto.LastName);
            Assert.Equal(personToMap.Email, personDto.Email);
            Assert.Equal(personToMap.Mobile, personDto.Mobile);
            Assert.Equal(personToMap.DateOfBirth, personDto.DateOfBirth);
            Assert.Equal(personToMap.Department, personDto.Department);
        }

        [Fact]
        public void ToEntity_ReturnsPerson()
        {
            var mapper = new PersonMapper();

            var personToMap = new PersonDto
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "trew",
                Mobile = "1234567890",
                DateOfBirth = new DateTime(1990, 1, 1),
                Department = 1
            };

            // Act
            var person = mapper.ToEntity(personToMap);

            Assert.IsType<Person>(person);
            Assert.NotNull(person);
            Assert.Equal(personToMap.Id, person.Id);
            Assert.Equal(personToMap.FirstName, person.FirstName);
            Assert.Equal(personToMap.LastName, person.LastName);
            Assert.Equal(personToMap.Email, person.Email);
            Assert.Equal(personToMap.Mobile, person.Mobile);
            Assert.Equal(personToMap.DateOfBirth, person.DateOfBirth);
            Assert.Equal(personToMap.Department, person.Department);
        }
    }
}
