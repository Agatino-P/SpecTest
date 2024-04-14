using Ardalis.Specification.EntityFrameworkCore;
using SpecTest.Domain.Model;
using SpecTest.Domain.Specifications;
using SpecTest.Infrastructure.DbContextes;

namespace SpecTest.Infrastructure.Repositories;
public class SpecPersonRepository : RepositoryBase<Person>, ISpecPersonRepository
{
    private readonly SpecTestDbContext dbContext;

    public SpecPersonRepository(SpecTestDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Person?> GetByFirst(string first)
    {
        return await this.FirstOrDefaultAsync(new PersonByNameSpecification(first));
    }
}