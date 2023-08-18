using EntityFrameworkTest.Application.Entities.Person.Commands;
using EntityFrameworkTest.Data.Interfaces;
using MediatR;
using entities = EntityFrameworkTest.Data.Entities;

namespace EntityFrameworkTest.Application.Entities.Person.Handlers
{
    public class CreatePersonHandler : IRequestHandler<CreatePerson, bool>
    {
        private readonly IRepository<entities.Person> _personRepo;
        public bool IsSucceeded { get; set; }

        public CreatePersonHandler(IRepository<entities.Person> personRepo)
        {
            _personRepo = personRepo;
        }

        public async Task<bool> Handle(CreatePerson request, CancellationToken cancellationToken)
        {
            try
            {
                await _personRepo.AddAsync(request.Person);
                await _personRepo.SaveChangesAsync();
                await Console.Out.WriteLineAsync($"Created person entity with the name {request.Person.FirstName} {request.Person.FamilyName}");
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
