using SpecTest.Domain.Model;

namespace SpecTest.Infrastructure.Repositories;
public interface ISpecPersonRepository
{
    Task<Person?> GetByFirst(string first);
}