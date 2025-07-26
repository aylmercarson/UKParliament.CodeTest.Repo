using UKParliament.CodeTest.Core.Entities;

namespace UKParliament.CodeTest.Core.Interfaces
{
    public interface IPersonRepository
    {
        /// <summary>
        /// Gets a person by their ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Person> GetByIdAsync(Guid id);

        /// <summary>
        /// Gets all persons in the repository.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Person>> GetAllAsync();

        /// <summary>
        /// Adds a new person to the repository.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public Task<Person> AddAsync(Person person);

        /// <summary>
        /// Updates an existing person.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public Task<Person> UpdateAsync(Person person);

        /// <summary>
        /// Deletes a person by their ID.
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public Task DeleteAsync(Guid personId);
    }
}
