using EntityFrameworkTest.Data.Interfaces;

namespace EntityFrameworkTest.Data.Entities
{
    public class House : IDbEntity
    {
        public Guid Id { get; set; }
        public string Location { get; set; }
        public int HouseNumber { get; set; }
        public List<Person> Persons { get; set; }
    }
}
