using UKParliament.CodeTest.Core.Dtos;
using UKParliament.CodeTest.Core.Entities;

namespace UKParliament.CodeTest.Core.Interfaces
{
    public interface IPersonMapper
    {
        /// <summary>
        /// Maps a collection of Person domain entities to a collection of Person Dtos.
        /// </summary>
        /// <param name="persons"></param>
        /// <returns></returns>
        public IEnumerable<PersonDto> ToListDto(IEnumerable<Person> persons);

        /// <summary>
        /// Maps a single Person domain entity to a single Person Dto.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public PersonDto ToDto(Person person);

        /// <summary>
        /// map a single Person Dto to a single domain entity
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public Person ToEntity(PersonDto source);
    }
}
