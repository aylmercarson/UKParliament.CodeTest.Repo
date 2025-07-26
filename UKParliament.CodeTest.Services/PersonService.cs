using FluentValidation;
using UKParliament.CodeTest.Core.Dtos;
using UKParliament.CodeTest.Core.Entities;
using UKParliament.CodeTest.Core.Interfaces;

namespace UKParliament.CodeTest.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _iPersonRepository;
    private readonly IPersonMapper _iPersonMapper;
    private readonly IValidator<PersonDto> _validator;

    public PersonService(
        IValidator<PersonDto> validator,
        IPersonRepository iPersonRepository, 
        IPersonMapper iPersonMapper)
    {
        _iPersonRepository = iPersonRepository ?? throw new ArgumentNullException(nameof(iPersonRepository));
        _iPersonMapper = iPersonMapper;
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public async Task<IEnumerable<PersonDto>> GetAllAsync()
    {
        var persons = await _iPersonRepository.GetAllAsync();

        return _iPersonMapper.ToListDto(persons);
    }
    

    public async Task<PersonDto> GetByIdAsync(Guid id)
    {
        var person = await _iPersonRepository.GetByIdAsync(id);

        return _iPersonMapper.ToDto(person);
    }

    public async Task<Person> AddAsync(PersonDto personDto)
    {
        if (personDto == null) throw new ArgumentNullException(nameof(personDto));

        // Validate the person using FluentValidation
        var validationResult = await _validator.ValidateAsync(personDto);

        if (!validationResult.IsValid)
        {
            // Handle validation errors
            throw new ValidationException(validationResult.Errors);
        }

        var person = _iPersonMapper.ToEntity(personDto);

        var addedPerson = await _iPersonRepository.AddAsync(person);

        return addedPerson;
    }

    public async Task<Person> UpdateAsync(PersonDto personDto)
    {
        var person = _iPersonMapper.ToEntity(personDto);

        if (person == null) throw new ArgumentNullException(nameof(person));

        return await _iPersonRepository.UpdateAsync(person);
    }

    public async Task DeleteAsync(Guid personId)
    {
        await _iPersonRepository.DeleteAsync(personId);
    }
}