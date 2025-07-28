using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Core.Entities;
using UKParliament.CodeTest.Core.Interfaces;



namespace UKParliament.CodeTest.Data
{
    /// <summary>
    /// Repository for managing Person entities.
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonManagerContext _context;

        public PersonRepository(PersonManagerContext context)
        {
            _context = context;
        }

        public async Task<Person> GetByIdAsync(Guid id)
        {
            return await _context.People.FindAsync(id) 
                   ?? throw new KeyNotFoundException($"Person with ID {id} not found.");
        }

        public async Task<IEnumerable<Person>> GetAllAsync() => await _context.People.ToListAsync();

        public async Task<bool> AddAsync(Person person)
        {
            _context.People.Add(person);
            var result = await _context.SaveChangesAsync();
            return result == 1;
        }

        public async Task<bool> UpdateAsync(Person person)
        {
            var personToBeUpdated = await _context.People.FindAsync(person.Id);

            if (personToBeUpdated == null)
            {
                throw new KeyNotFoundException($"Person with Id {person.Id} not found.");
            }

            _context.People.Update(person); 
            _context.Entry(person).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            return result == 1;
        }

        public async Task<bool> DeleteAsync(Guid personId)
        {
            var person = await _context.People.FindAsync(personId);

            if (person == null)
            {
                throw new KeyNotFoundException($"Person with Id {personId} not found.");
            }

            _context.People.Remove(person);

            var result = await _context.SaveChangesAsync();

            return result == 1;
        }
    }
}