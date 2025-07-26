using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Core.Entities;
using UKParliament.CodeTest.Core.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UKParliament.CodeTest.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _iDepartmentService;

        public DepartmentController(IDepartmentService iDepartmentService)
        {
            _iDepartmentService = iDepartmentService;
        }

        [Route("getall")]
        [HttpGet]
        public async Task<IEnumerable<Department>> GetAll()
        {
            try
            {
                return await _iDepartmentService.GetAllAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return null;
            }
        }
    }
}
