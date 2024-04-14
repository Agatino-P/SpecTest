using SpecTest.Domain.Model;

namespace SpecTest.Domain.Ports;
public interface IPersonRepository
{
    Task Add(Person person);
    Task<IList<Person>> GetAll();
    Task<Person?> Get(Guid id);
    Task<Person?> GetByFName(string fname);
}
