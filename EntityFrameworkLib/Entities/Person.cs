using EntityFrameworkTest.Data.Interfaces;

namespace EntityFrameworkTest.Data.Entities
{
    public class Person : IDbEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
    }
}
