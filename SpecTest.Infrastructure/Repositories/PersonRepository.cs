using Microsoft.EntityFrameworkCore;
using SpecTest.Domain.Model;
using SpecTest.Domain.Ports;
using SpecTest.Infrastructure.DbContextes;

namespace SpecTest.Infrastructure.Repositories;
public class PersonRepository : IPersonRepository
{
    private readonly SpecTestDbContext dbContex;

    public PersonRepository(SpecTestDbContext dbContex)
    {
        this.dbContex = dbContex;
    }
    public async Task Add(Person person)
    {
        dbContex.Add(person);
        await dbContex.SaveChangesAsync();
    }

    public async Task<Person?> Get(Guid id)
    {
        return await dbContex.PersonSet.FindAsync(id);
    }

    public async Task<IList<Person>> GetAll()
    {
        return await dbContex.PersonSet.ToListAsync();
    }

    public async Task<Person?> GetByFName(string fname)
    {
        Person? person = await dbContex.PersonSet.FirstOrDefaultAsync(p => p.First == fname);
        return person;
    }
}
