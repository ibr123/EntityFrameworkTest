using MediatR;
using entities = EntityFrameworkTest.Data.Entities;

namespace EntityFrameworkTest.Application.Entities.Person.Commands
{
    public class CreatePerson : IRequest<bool>
    {
        public entities.Person Person { get; set; }
    }
}
