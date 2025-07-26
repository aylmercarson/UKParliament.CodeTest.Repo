using UKParliament.CodeTest.Core.Dtos;
using UKParliament.CodeTest.Core.Entities;

namespace UKParliament.CodeTest.Tests.TestData
{
    public static class TestDataPersons
    {
        /// <summary>
        /// returns a list of PersonDto objects for testing purposes
        /// </summary>
        /// <returns></returns>
        public static List<PersonDto> GetTestPersonDtos()
        {
            var personDtos = new List<PersonDto>();

            personDtos.Add(new PersonDto()
             {
                Id = Guid.NewGuid(),
                FirstName = "Wilma",
                LastName = "Flintstone",
                Email = "",
                Mobile = "",
                DateOfBirth = new DateTime(1990, 1, 1),
                Department = 1
            });

            personDtos.Add(new PersonDto()
            {
                Id = Guid.NewGuid(),
                FirstName = "Fred",
                LastName = "Flintstone",
                Email = "",
                Mobile = "",
                DateOfBirth = new DateTime(1990, 1, 1),
                Department = 1
            });

            return personDtos;
        }

        /// <summary>
        /// returns a list of domain objects for testing purposes
        /// </summary>
        /// <returns></returns>
        public static List<Person> GetTestPersonEntities()
        {
            var persons = new List<Person>();

            persons.Add(new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Wilma",
                LastName = "Flintstone",
                Email = "",
                Mobile = "",
                DateOfBirth = new DateTime(1990, 1, 1),
                Department = 1
            });

            persons.Add(new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Fred",
                LastName = "Flintstone",
                Email = "",
                Mobile = "",
                DateOfBirth = new DateTime(1990, 1, 1),
                Department = 1
            });

            return persons;
        }

        /// <summary>
        /// returns a single domain object for testing purposes
        /// </summary>
        /// <returns></returns>
        public static Person GetDomainPerson()
        {
            return new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Fred",
                LastName = "Flintstone",
                Email = "",
                Mobile = "",
                DateOfBirth = new DateTime(1990, 1, 1),
                Department = 1
            };
        }

        /// <summary>
        /// gets a single PersonDto object for testing purposes
        /// </summary>
        /// <returns></returns>
        public static PersonDto GetPersonDto()
        {
            return new PersonDto()
            {
                Id = Guid.NewGuid(),
                FirstName = "Fred",
                LastName = "Flintstone",
                Email = "",
                Mobile = "",
                DateOfBirth = new DateTime(1990, 1, 1),
                Department = 1
            };
        }


        public static PersonDto ValidPersonDtoForValidationTests()
        {
            return new PersonDto()
            {
                Id = Guid.NewGuid(),
                FirstName = "Barney",
                LastName = "Rubble",
                Email = "barney@bedrock.com",
                Mobile = "017 666 555 003",
                DateOfBirth = new DateTime(1990, 1, 1),
                Department = 1
            };
        }

        public static PersonDto PersonDtoFailValidationForShortFirstname()
        {
            return new PersonDto()
            {
                Id = Guid.NewGuid(),
                FirstName = "Fred",
                LastName = "Flintstone",
                Email = "fred@bedrock.com",
                Mobile = "017 666 555 003",
                DateOfBirth = new DateTime(1990, 1, 1),
                Department = 1
            };
        }

        public static PersonDto PersonDtoFailValidationForLongFirstname()
        {
            return new PersonDto()
            {
                Id = Guid.NewGuid(),
                FirstName = "FredFredFredFredFredFredFredFred",
                LastName = "Flintstone",
                Email = "fred@bedrock.com",
                Mobile = "017 666 555 003",
                DateOfBirth = new DateTime(1990, 1, 1),
                Department = 1
            };
        }
    }
}
