using UKParliament.CodeTest.Core.Entities;

namespace UKParliament.CodeTest.Core.Interfaces
{
    public interface IDepartmentService
    {
        /// <summary>
        /// get a lisxt of all departments in the system. (These are immutable and could be Records)
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Department>> GetAllAsync();

        /// <summary>
        /// Gets a department by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<string> GetDepartmentNameByIdAsync(int id);
    }
}
