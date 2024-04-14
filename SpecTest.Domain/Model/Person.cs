namespace SpecTest.Domain.Model;
public class Person
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string First { get; set; } = "";
    public string Last { get; set; } = "";
}
