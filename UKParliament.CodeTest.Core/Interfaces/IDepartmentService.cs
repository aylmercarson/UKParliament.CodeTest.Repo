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

        public Task<string> GetDepartmentNameByIdAsync(int id);
    }
}
