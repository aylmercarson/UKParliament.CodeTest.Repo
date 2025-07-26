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

        public async Task<Person> AddAsync(Person person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));

            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));
            _context.People.Update(person); 
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task DeleteAsync(Guid personId)
        {
            var person = await _context.People.FindAsync(personId);

            _context.People.Remove(person);

            await _context.SaveChangesAsync();
        }
    }
}