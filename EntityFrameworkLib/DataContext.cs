using EntityFrameworkTest.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Data
{
    public class DataContext : DbContext
    {
        private string connectionString;
        public DataContext() : base()
        {

        }

        /// <summary>
        /// this constructor is only called when the application is started from the "consoleUI" tier
        /// yet if "update-database" is started it wont be called so the connectionstring wont be passed
        /// </summary>
        /// <param name="options"></param>
        /// <param name="customOptions"></param>
        public DataContext(DbContextOptions<DataContext> options, DbContextCustomOptions customOptions) : base(options)
        {
            connectionString = customOptions.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (connectionString == null)
            {
                connectionString = "Server=.\\SQLExpress;Database=EFSevenTest;Trusted_Connection=true;TrustServerCertificate=true;";
            }
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<House> Houses { get; set; }
    }
}
