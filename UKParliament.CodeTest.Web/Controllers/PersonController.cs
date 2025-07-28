using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Core.Dtos;
using UKParliament.CodeTest.Core.Interfaces;

namespace UKParliament.CodeTest.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _iPersonService;
    private readonly IValidator<PersonDto> _validator;

    public PersonController(
        IPersonService iPersonService, 
        IValidator<PersonDto> validator)
    {
        _iPersonService = iPersonService;
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    [Route("{personId:Guid}")]
    [HttpGet]
    public async Task<ActionResult<PersonDto>> GetById(Guid personId)
    {
        try
        {
            var personDto = await _iPersonService.GetByIdAsync(personId);

            if (null == personDto)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Person with ID {personId} not found.");
            }

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
    public async Task<ActionResult<bool>> Add(PersonDto personDto)
    {
        try
        {
            var validationResult = await _validator.ValidateAsync(personDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            if(await _iPersonService.AddAsync(personDto))
            {
                return StatusCode(StatusCodes.Status201Created, true);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add person.");
            }
        }
        catch (Exception ex)
        {
            // Log the exception (not implemented here)

            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
    }

    [Route("update")]
    [HttpPut]
    public async Task<ActionResult<bool>> Update(PersonDto personDto)
    {
        try
        {
            var validationResult = await _validator.ValidateAsync(personDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            if (await _iPersonService.UpdateAsync(personDto))
            {
                return StatusCode(StatusCodes.Status200OK, true);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating person.");
            }
        }
        catch (KeyNotFoundException ex)
        {
            // Log the exception (not implemented here)

            return StatusCode(StatusCodes.Status404NotFound, ex.Message);
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

            return StatusCode(StatusCodes.Status200OK, true);
        }
        catch (KeyNotFoundException ex)
        {
            // Log the exception (not implemented here)

            return StatusCode(StatusCodes.Status404NotFound, ex.Message);
        }
        catch (Exception ex)
        {
            // Log the exception (not implemented here)

            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}