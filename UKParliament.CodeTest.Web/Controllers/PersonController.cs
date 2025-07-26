using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Core.Dtos;
using UKParliament.CodeTest.Core.Interfaces;

namespace UKParliament.CodeTest.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _iPersonService;

    public PersonController(IPersonService iPersonService)
    {
        _iPersonService = iPersonService;
    }

    [Route("{personId:Guid}")]
    [HttpGet]
    public async Task<ActionResult<PersonDto>> GetById(Guid personId)
    {
        try
        {
            var personDto = await _iPersonService.GetByIdAsync(personId);

            return StatusCode(StatusCodes.Status200OK, personDto);
        }
        catch (Exception ex)
        {
            // Log the exception (not implemented here)

            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
    }

    [Route("getall")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonDto>>> GetAll()
    {
        try
        {
            var persons = await _iPersonService.GetAllAsync();

            return StatusCode(StatusCodes.Status200OK, persons);
        }
        catch (Exception ex)
        {
            // Log the exception (not implemented here)

            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }     
    }

    [Route("add")]
    [HttpPost]
    public async Task<ActionResult<PersonDto>> Add(PersonDto personViewModel)
    {
        try
        {
            var person = await _iPersonService.AddAsync(personViewModel);

            return StatusCode(StatusCodes.Status200OK, person);
        }
        catch (Exception ex)
        {
            // Log the exception (not implemented here)

            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
    }

    [Route("update")]
    [HttpPut]
    public async Task<ActionResult<PersonDto>> Update(PersonDto personDto)
    {
        try
        {
            var person = await _iPersonService.UpdateAsync(personDto);

            return base.StatusCode(StatusCodes.Status200OK, person);
        }
        catch (Exception ex)
        {
            // Log the exception (not implemented here)

            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
    }

    [Route("delete/{personId:Guid}")]
    [HttpDelete]
    public async Task<ActionResult<bool>> Delete(Guid personId)
    {
        try
        {
            await _iPersonService.DeleteAsync(personId);

            return base.StatusCode(StatusCodes.Status200OK, true);
        }
        catch (Exception ex)
        {
            // Log the exception (not implemented here)

            return base.StatusCode(StatusCodes.Status200OK, false);
        }
    }
}