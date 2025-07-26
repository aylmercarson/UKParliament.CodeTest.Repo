using UKParliament.CodeTest.Core.Entities;

namespace UKParliament.CodeTest.Core.Interfaces
{
    public interface IPersonRepository
    {
        public Task<Person> GetByIdAsync(Guid id);

        public Task<IEnumerable<Person>> GetAllAsync();

        public Task<Person> AddAsync(Person person);

        public Task<Person> UpdateAsync(Person person);

        public Task DeleteAsync(Guid personId);
    }
}
