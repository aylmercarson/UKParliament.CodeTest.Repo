using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Core.Entities;
using UKParliament.CodeTest.Core.Interfaces;

namespace UKParliament.CodeTest.Data
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly PersonManagerContext _context;

        public DepartmentRepository(PersonManagerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllAsync() => await _context.Departments.ToListAsync();

        public async Task<string> GetDepartmentNameById(int id)
        {
            var department = await _context.Departments.Where(x => x.Id == id).SingleOrDefaultAsync();

            return department?.Name ?? throw new KeyNotFoundException($"Department with ID {id} not found.");
        }
    }
}
