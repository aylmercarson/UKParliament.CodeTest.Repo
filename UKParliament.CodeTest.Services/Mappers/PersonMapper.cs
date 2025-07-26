using UKParliament.CodeTest.Core.Dtos;
using UKParliament.CodeTest.Core.Entities;
using UKParliament.CodeTest.Core.Interfaces;

namespace UKParliament.CodeTest.Services.Mappers
{
    public class PersonMapper : IPersonMapper
    {
        public IEnumerable<PersonDto> ToListDto(IEnumerable<Person> source)
        {
            return source.Select(person => new PersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Mobile = person.Mobile,
                DateOfBirth = person.DateOfBirth,
                Department = person.Department
            });
        }

        /// <summary>
        /// maps a single domain entity to a dto
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public PersonDto ToDto(Person person)
        {
            return new PersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Mobile = person.Mobile,
                DateOfBirth = person.DateOfBirth,
                Department = person.Department
            };
        }

        /// <summary>
        /// maps a single dto to a domain entity
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Person ToEntity(PersonDto source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return new Person
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Email = source.Email,
                Mobile = source.Mobile,
                DateOfBirth = source.DateOfBirth,
                Department = source.Department
            };
        }
    }
}
