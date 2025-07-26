using UKParliament.CodeTest.Core.Dtos;
using UKParliament.CodeTest.Core.Entities;

namespace UKParliament.CodeTest.Core.Interfaces
{
    public interface IPersonMapper
    {
        public IEnumerable<PersonDto> ToListDto(IEnumerable<Person> persons);

        public PersonDto ToDto(Person person);

        /// <summary>
        /// map a single Person Dto to a single domain entity
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public Person ToEntity(PersonDto source);
    }
}
