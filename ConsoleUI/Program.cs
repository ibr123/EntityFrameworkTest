using EntityFrameworkTest.Application;
using EntityFrameworkTest.Application.Entities.Person.Commands;
using EntityFrameworkTest.Application.Extensions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

Console.WriteLine("Hello, World!");
const string connectionString = "Server=.\\SQLExpress;Database=EFSevenTest;Trusted_Connection=true;TrustServerCertificate=true;";

IHost host = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDataContext(connectionString);
    services.RegisterDependencies();
    services.AddMediatR(configurations => configurations.RegisterServicesFromAssembly(typeof(IApplicationAssymblyHolder).GetTypeInfo().Assembly));
}).Build();


IMediator mediator = new Mediator(host.Services);

await mediator.Send(new CreatePerson()
{
    Person = new EntityFrameworkTest.Data.Entities.Person()
    {
        FamilyName = "ibr",
        FirstName = " hamdeh",
        Id = Guid.NewGuid(),
    }
});

host.Run();
Console.WriteLine("******** Finished ********");
