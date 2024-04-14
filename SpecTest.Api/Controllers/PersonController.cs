using Microsoft.AspNetCore.Mvc;
using SpecTest.Domain.Model;
using SpecTest.Domain.Ports;

namespace SpecTest.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonRepository personRepository;
    private readonly ILogger<PersonController> _logger;

    public PersonController(IPersonRepository personRepository, ILogger<PersonController> logger)
    {
        this.personRepository = personRepository;
        _logger = logger;
    }

    [HttpGet(Name = "GetPeople")]
    public async Task<IList<Person>> GetAll()
    {
        return await personRepository.GetAll();
    }

    [HttpPost(Name = "AddPerson")]
    public async Task Add(Person person)
    {
        await personRepository.Add(person);
    }

}
