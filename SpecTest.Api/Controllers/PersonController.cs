using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
