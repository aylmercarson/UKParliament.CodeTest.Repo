using UKParliament.CodeTest.Core.Entities;

namespace UKParliament.CodeTest.Core.Interfaces
{
    public interface IDepartmentRepository
    {
        public Task<IEnumerable<Department>> GetAllAsync();

        public Task<string> GetDepartmentNameById(int id);
    }
}
