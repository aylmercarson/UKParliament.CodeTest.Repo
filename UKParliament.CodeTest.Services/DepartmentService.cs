using UKParliament.CodeTest.Core.Dtos;
using UKParliament.CodeTest.Core.Entities;
using UKParliament.CodeTest.Core.Interfaces;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Services.Mappers;

namespace UKParliament.CodeTest.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _iDepartmentRepository;

        public DepartmentService(IDepartmentRepository iDepartmentRepository)
        {
            _iDepartmentRepository = iDepartmentRepository ?? throw new ArgumentNullException(nameof(iDepartmentRepository));
        }

        public async Task<IEnumerable<Department>> GetAllAsync() => await _iDepartmentRepository.GetAllAsync();

        public async Task<string> GetDepartmentNameByIdAsync(int id)
        {
            return await _iDepartmentRepository.GetDepartmentNameById(id);
        }
    }
}
