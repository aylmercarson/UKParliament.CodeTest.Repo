using UKParliament.CodeTest.Core.Entities;

namespace UKParliament.CodeTest.Core.Interfaces
{
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Gets all departments.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Department>> GetAllAsync();

        /// <summary>
        /// Gets a department by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<string> GetDepartmentNameById(int id);
    }
}
