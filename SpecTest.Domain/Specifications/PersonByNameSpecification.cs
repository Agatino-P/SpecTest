using Ardalis.Specification;
using SpecTest.Domain.Model;

namespace SpecTest.Domain.Specifications;

public class PersonByNameSpecification : Specification<Person>
{
    public PersonByNameSpecification(string first)
    {
        Query.Where(c => c.First == first);
    }
}