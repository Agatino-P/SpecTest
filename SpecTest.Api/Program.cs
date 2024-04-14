using SpecTest.Infrastructure.ServiceExtensions;
using SpecTest.Infrastructure.DbContextes;

namespace SpecTest.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbServices();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();
        //using (var scope = app.Services.CreateScope())
        //{
        //    SpecTestDbContext? dbContext = app.Services.GetService<SpecTestDbContext>();
        //}

        new SpecTestDbContext().Database.EnsureCreated();
        app.Run();
    }
}
