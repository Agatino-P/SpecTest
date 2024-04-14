using Microsoft.EntityFrameworkCore;
using SpecTest.Domain.Model;

namespace SpecTest.Infrastructure.DbContextes;
public  class SpecTestDbContext : DbContext
{
    public DbSet<Person> PersonSet { get;set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SpecTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(connectionString);
    }
}
