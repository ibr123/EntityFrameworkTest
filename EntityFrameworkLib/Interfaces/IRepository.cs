using Ardalis.Specification;

namespace EntityFrameworkTest.Data.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class
    {
        IQueryable<T> Query { get; set; }
    }
}
