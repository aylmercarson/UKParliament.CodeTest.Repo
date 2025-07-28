using UKParliament.CodeTest.Core.Dtos;
using UKParliament.CodeTest.Core.Entities;

namespace UKParliament.CodeTest.Core.Interfaces
{
    public interface IPersonService
    {
        /// <summary>
        /// Gets a person by their ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<PersonDto> GetByIdAsync(Guid id);

        /// <summary>
        /// returns a list of person dtos
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<PersonDto>> GetAllAsync();

        /// <summary>
        /// add a single person to the d/base
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(PersonDto person);

        /// <summary>
        /// update a single person in the d/base
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public Task<bool> UpdateAsync(PersonDto person);

        /// <summary>
        /// Deletes a person by their ID.
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public Task<bool> DeleteAsync(Guid personId);

    }
}