using UKParliament.CodeTest.Core.Dtos;
using UKParliament.CodeTest.Core.Interfaces;

namespace UKParliament.CodeTest.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _iPersonRepository;
    private readonly IPersonMapper _iPersonMapper;

    public PersonService(
        IPersonRepository iPersonRepository, 
        IPersonMapper iPersonMapper)
    {
        _iPersonRepository = iPersonRepository ?? throw new ArgumentNullException(nameof(iPersonRepository));
        _iPersonMapper = iPersonMapper;
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

    public async Task<bool> AddAsync(PersonDto personDto)
    {
        var person = _iPersonMapper.ToEntity(personDto);

        if (person == null) throw new ArgumentNullException(nameof(person));

        return await _iPersonRepository.AddAsync(person);
    }

    public async Task<bool> UpdateAsync(PersonDto personDto)
    {
        var person = _iPersonMapper.ToEntity(personDto);

        if (person == null) throw new ArgumentNullException(nameof(person));

        return await _iPersonRepository.UpdateAsync(person);
    }

    public async Task<bool> DeleteAsync(Guid personId)
    {
        return await _iPersonRepository.DeleteAsync(personId);
    }
}