using EntityFrameworkTest.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Data
{
    public class DataContext : DbContext
    {
        private readonly string connectionString;
        public DataContext() : base()
        {

        }

        public DataContext(DbContextOptions<DataContext> options, DbContextCustomOptions customOptions) : base(options)
        {
            connectionString = customOptions.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
            
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<House> Houses { get; set; }
    }
}
