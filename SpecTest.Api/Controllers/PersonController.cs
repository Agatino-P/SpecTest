using Microsoft.AspNetCore.Mvc;
using SpecTest.Domain.Model;
using SpecTest.Domain.Ports;
using SpecTest.Infrastructure.Repositories;

namespace SpecTest.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonRepository personRepository;
    private readonly ISpecPersonRepository specPersonRepository;
    private readonly ILogger<PersonController> _logger;

    public PersonController(IPersonRepository personRepository, ISpecPersonRepository specPersonRepository, ILogger<PersonController> logger)
    {
        this.personRepository = personRepository;
        this.specPersonRepository = specPersonRepository;
        _logger = logger;
    }

    [HttpGet("by-id/{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        Person? person = await personRepository.Get(id);
        return person == null ? NotFound() : Ok(person);
    }

    [HttpGet("by-fname/{fname}")]
    public async Task<IActionResult> GetById(string fname)
    {
        Person? person = await personRepository.GetByFName(fname);
        return person == null ? NotFound() : Ok(person);
    }

    [HttpGet("by-spec-fname/{first}")]
    public async Task<IActionResult> GetBySpecId(string first)
    {
        Person? person = await specPersonRepository.GetByFirst(first);
        return person == null ? NotFound() : Ok(person);
    }


    [HttpGet]
        public async Task<IActionResult> GetAll()
    {
        return Ok(await personRepository.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> Add(Person person)
    {
        await personRepository.Add(person);
        return Ok(person);
    }

}
